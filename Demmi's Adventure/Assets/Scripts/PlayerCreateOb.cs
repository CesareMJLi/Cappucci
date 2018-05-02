using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreateOb : MonoBehaviour {

	public Text countText;
	public Text selectedText;

	private List<int> objects_available;
	private int numObjects;
	private int obj_ava_index;
	public GameObject Object;

	public List<GameObject> objects_in_scene;

	// Use this for initialization
	void Start () {
		objects_available = new List<int>();
		obj_ava_index = 0;
		numObjects = 0;
		setNumObjText();
		setSelectedText(true);
	}
	
	// Update is called once per frame
	void Update () {
		//  set selected text use a flag to select the previous or next object in the list
		if(Input.GetKeyDown(KeyCode.Q)){
			setSelectedText(false);
		}else if(Input.GetKeyDown(KeyCode.E)){
			setSelectedText(true);
		}

		if(Input.GetMouseButtonDown(0)){

			int layerMaskBg = LayerMask.GetMask("Background");
			int layerMastObj = LayerMask.GetMask("Objects");

			// if hit object
			RaycastHit2D hitObject =  Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), 
				Vector2.zero, Mathf.Infinity, layerMastObj);
			if(hitObject.collider != null){
				// Debug.Log("HitObject! Current num is "+numObjects);
				// Debug.Log(hitObject.transform.gameObject.tag);
				int objTag = int.Parse(hitObject.transform.gameObject.tag);
				Destroy(hitObject.transform.gameObject);
				if(numObjects<3){
					numObjects+=1;
					objects_available.Add(objTag);
				}else if(numObjects==3){
					objects_available.RemoveAt(0);
					objects_available.Add(objTag);
				}
				setNumObjText();
				setSelectedTextDefault();
				// Debug.Log(objects_available);
			}
			else{
				// if hit background
				RaycastHit2D hitBackground =  Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), 
					Vector2.zero, Mathf.Infinity, layerMaskBg);
				if((hitBackground.collider != null)&&(numObjects>0)){
					// Debug.Log("HitBackGround!! Current num is " + numObjects);
					InstantiateSomeObj();
					setNumObjText();
					setSelectedTextDefault();
				}
				// Debug.Log(objects_available);
			}
		}

	}

	void setNumObjText(){
		string txt = " ";
		foreach (var i in objects_available) {
    		txt += i.ToString() + "  ";
			// Debug.Log(txt);
		}
		countText.text = "CURRENT OBJECTS : " + txt;
	}

	void setSelectedText(bool flag){
		if (flag){
			if (numObjects>0){
				if (obj_ava_index>=objects_available.Count-1){
					obj_ava_index = 0;
				}else{
					obj_ava_index +=1;
				}
				selectedText.text = "Selected Objects: "+ objects_available[obj_ava_index].ToString();
			}else{
				selectedText.text = "Selected Objects: ";
				obj_ava_index = 0;
			}
		}else{
			if (numObjects>0){
				if (obj_ava_index<=0){
					obj_ava_index = objects_available.Count-1;
				}else{
					obj_ava_index -=1;
				}
				selectedText.text = "Selected Objects: "+ objects_available[obj_ava_index].ToString();
			}else{
				selectedText.text = "Selected Objects: ";
				obj_ava_index = 0;
			}
		}
	}

	void setSelectedTextDefault(){
		obj_ava_index = 0;
		if (numObjects>0){
			selectedText.text = "Selected Objects: " + objects_available[obj_ava_index].ToString();
		}else{
			selectedText.text = "Selected Objects: ";
		}
		
	}

	void InstantiateSomeObj(){
		Vector3 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z=0;

		int objTag = objects_available[obj_ava_index];
		objects_available.RemoveAt(obj_ava_index);
		// GameObject go = GameObject.FindWithTag(objTag.ToString());
		foreach (GameObject go in objects_in_scene){
			if (int.Parse(go.tag) == objTag){
				Instantiate(go, mousePos, Quaternion.identity);
				break;
			}
		}
		numObjects-=1;
	}
}
