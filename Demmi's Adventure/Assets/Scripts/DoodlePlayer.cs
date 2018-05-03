using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DoodlePlayer : MonoBehaviour {

	public static Transform player = null;

	float movement = 0f;
	public float movementSpeed = 10f;

	private Animator _animator;

	Rigidbody2D _rigidbody;

	void Awake(){
		
		if(player != null)
			Destroy(this.gameObject);
		else
			player = transform;
	}

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>() as Animator;
		_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal")*movementSpeed;
		
		if (movement>0){
			_animator.SetTrigger("PlayerWalkRight");
		}else if (movement<0){
			_animator.SetTrigger("PlayerWalkLeft");
		}

		CrossScreen();
		GameOverJudgement();
	}

	void FixedUpdate(){
		Vector2 velocity = _rigidbody.velocity;
		velocity.x =movement;
		_rigidbody.velocity = velocity;
	}

	void GameOverJudgement(){
		// Debug.Log("GAMEOVER");
		if (player.position.y<InfiniteLevelGenerator.deadline){
			Time.timeScale = 0.0f;
		}
	}

	void CrossScreen(){
		if((player.position.x>18.0f)||(player.position.x<-18.0f)){
			player.position = new Vector3(-player.position.x,player.position.y,player.position.z);
			// Debug.Log("OUT OF SCREEN");
		}
	}
}
