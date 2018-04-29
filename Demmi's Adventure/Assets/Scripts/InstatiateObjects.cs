using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstatiateObjects : MonoBehaviour {

	public Transform prefab1;
	public Transform prefab2;
	public Transform prefab3;
	public Transform prefab4;

	public Transform target_player;
	Vector3 offset;

	public float time_delay=5.0f;
	public int counter=0;

	private float nextTime;
	// private Transform _transform;

	private float initiate_x;
	private float initiate_y;

    void Start(){
        nextTime=Time.time+time_delay;
		initiate_x = target_player.position.x;
		initiate_y = target_player.position.y+60.0f;
		// _transform = GetComponent<Transform>() as Transform;
    }

	void Update(){
		if(Time.time>nextTime){
			counter+=1;
			if((counter>=5)&&(time_delay>0.5f)){
				counter=0;
				time_delay-=0.1f;
			}
			nextTime = Time.time+time_delay;
			System.Random rnd = new System.Random();
			int prefab_index = rnd.Next(1,5);
			initiate_x = target_player.position.x+(float)(2*rnd.NextDouble());
			initiate_y = target_player.position.y+60.0f;
			
			// Debug.Log ("THE CURRENT x IS " + initiate_x);
			Vector3 initiate_position = new Vector3(initiate_x,initiate_y,0);
			switch(prefab_index){
				case 1:
					Instantiate(prefab1, initiate_position,Quaternion.identity);
					break;
				case 2:
					Instantiate(prefab2, initiate_position,Quaternion.identity);
					// Instantiate(prefab2, new Vector3(0, 50.0f, 0),Quaternion.identity);
					break;
				case 3:
					Instantiate(prefab3, initiate_position,Quaternion.identity);
					// Instantiate(prefab3, new Vector3(0, 50.0f, 0),Quaternion.identity);
					break;
				default:
					Instantiate(prefab4, initiate_position,Quaternion.identity);
					// Instantiate(prefab4, new Vector3(0, 50.0f, 0),Quaternion.identity);
					break;
			}
			
			// public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
			
		}		
	}
}

// example for random
// Random rnd = new Random();
// int month = rnd.Next(1, 13); // creates a number between 1 and 12
// int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
// int card = rnd.Next(52); 