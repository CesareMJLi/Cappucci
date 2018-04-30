using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreateOb : MonoBehaviour {

	public Text countText;
	private int numObjects;
	public GameObject Object;


	// Use this for initialization
	void Start () {
		numObjects = 0;
		setNumObjText();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			// Debug.Log("CLICK DETECTED");

			int layerMaskBg = LayerMask.GetMask("Background");
			int layerMastObj = LayerMask.GetMask("Objects");
			// layerMask = ~layerMask;
			// Debug.Log("CURRENT LAYER"+layerMask);
			// Vector3 mScreenPos=Input.mousePosition;
			// Ray mRay=UnityEngine.Camera.main.ScreenPointToRay(mScreenPos);
			// Debug.Log(mRay.ToString());
			// RaycastHit mHit;
			/* 
			if(Physics.Raycast(mRay,out mHit,Mathf.Infinity)){
				Debug.Log("???");
				if(numObjects>0){
						InistantiateSomeObj();
					}
				// if(mHit.collider.gameObject.tag=="Background"){
				// 	Debug.Log("!!!!!");
				// 	if(numObjects>0){
				// 		InistantiateSomeObj();
				// 	}
				// }
			}else{
				Debug.Log("UNFOUDNED CLICKING");
			}
			*/

			RaycastHit2D hitObject =  Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), 
				Vector2.zero, Mathf.Infinity, layerMastObj);
			if(hitObject.collider != null){
				// Debug.Log("HitObject! Current num is "+numObjects);
				Destroy(hitObject.transform.gameObject);
				if(numObjects<3){
					numObjects+=1;
				}
				setNumObjText();
			}
			else{

				RaycastHit2D hitBackground =  Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), 
					Vector2.zero, Mathf.Infinity, layerMaskBg);
				if((hitBackground.collider != null)&&(numObjects>0)){
					// Debug.Log("HitBackGround!! Current num is " + numObjects);
					InistantiateSomeObj();
					setNumObjText();
				}
			}
		}

	}

	void setNumObjText(){
		countText.text = "COUNT:  " + numObjects.ToString();
	}

	void InistantiateSomeObj(){
		Vector3 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z=0;
		// Vector3 spawnPosition = new Vector3();
		// spawnPosition.y = mousePos.y;
		// spawnPosition.x = mousePos.x;
		// Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		Instantiate(Object, mousePos, Quaternion.identity);
		numObjects-=1;
	}
}
