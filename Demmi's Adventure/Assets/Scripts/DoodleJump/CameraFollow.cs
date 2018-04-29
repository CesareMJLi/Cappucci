using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// public Transform target;
	// public float smoothSpeed =.3f;

	// // private Vector3 currentVelocity;
	
	// void LateUpdate () {
	// 	if (target.position.y > transform.position.y){
	// 		// Debug.Log("WTF");
	// 		Vector3 newPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	// 		// transfrom.position = Vector3.SmoothDamp(transfrom.position,newPos,currentVelocity, smoothSpeed);
	// 		transform.position = Vector3.Lerp(transform.position,newPos,smoothSpeed);
	// 	}
	// }

	public Transform target;
	public float smoothing=5f;

	Vector3 offset;

	void Start(){
		offset = transform.position - target.position;
	}

	void FixedUpdate(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
