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
		_animator = GetComponent<Animator>() as Animator;
		if(player != null)
			Destroy(this.gameObject);
		else
			player = transform;
	}

	// Use this for initialization
	void Start () {
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

}
