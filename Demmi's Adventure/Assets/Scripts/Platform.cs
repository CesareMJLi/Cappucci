using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce = 20f;

	void OnCollisionEnter2D(Collision2D collision){

		if (collision.relativeVelocity.y <= 0f){
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

			if (rb!=null){
				// rd.addForce();
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
		}	
	}

	// when the object is clicked cancell this object
	
	// void Update(){
	// 	if(Input.GetMouseButtonDown(0)){
	// 		this.gameObject.SetActive(false);
    // 	}
	// }
	// this is a mistake, cuz when it detects a click of the mouse anywhere in the screen
	// all the platform objects would be disabled

	void OnMouseDown(){
        // this object was clicked - do something
     	Destroy (this.gameObject);
  	}   
}
