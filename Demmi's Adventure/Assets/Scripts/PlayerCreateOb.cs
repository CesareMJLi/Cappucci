using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreateOb : MonoBehaviour {

	public static int numObjects;
	public GameObject Object;


	// Use this for initialization
	void Start () {
		numObjects = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

		if(Input.GetMouseButtonDown(0)){
			// Debug.Log("CLICK DETECTED");

			int layerMask = LayerMask.GetMask("Background");
			Debug.Log("CURRENT LAYER"+layerMask);

			Vector3 mScreenPos=Input.mousePosition;
			Ray mRay=UnityEngine.Camera.main.ScreenPointToRay(mScreenPos);

			Debug.Log(mRay.ToString());

			RaycastHit mHit;

			if(Physics.Raycast(mRay,out mHit,  Mathf.Infinity,layerMask)){
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
		}

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
