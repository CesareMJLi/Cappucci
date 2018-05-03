using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	// public static int numObjects;
	public float jumpForce = 20f;
	// public GameObject player;


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

	// when the object is far away from the player, destroy it.

	void Update(){
		if (this.gameObject.transform.position.y<DoodlePlayer.player.position.y-33.0f){
			Destroy(this.gameObject);
		}
	}
}
