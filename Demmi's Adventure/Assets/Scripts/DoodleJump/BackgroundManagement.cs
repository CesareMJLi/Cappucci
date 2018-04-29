using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManagement : MonoBehaviour {

	public int numObjToBeInstantiates = 3;
	public GameObject objToBeInstantiate;

	void OnMouseDown(){
        // this object was clicked - do something
		Debug.Log("WTF");
     	if(numObjToBeInstantiates>0){
			InistantiateSomeObj();
    	}
  	} 

	void InistantiateSomeObj(){
		Vector3 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z=0;
		Debug.Log("WTF");
		// Vector3 spawnPosition = new Vector3();
		// spawnPosition.y = mousePos.y;
		// spawnPosition.x = mousePos.x;
		// Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		Instantiate(objToBeInstantiate, mousePos, Quaternion.identity);
		numObjToBeInstantiates-=1;
	}
}
