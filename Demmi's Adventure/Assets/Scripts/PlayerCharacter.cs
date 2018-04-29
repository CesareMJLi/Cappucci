using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// reference from https://zhuanlan.zhihu.com/p/30941395
public class PlayerCharacter : MonoBehaviour {

	[Header("Player Speed")]
	[Range(0.0f,30.0f)]
	public float curSpeed = 15.0f;
	[Header("Player Jump")]
	[Range(0.0f,1000.0f)]
	public float jumpHeight = 700.0f;

    float checkDistance = 1.5f;
	
	bool isGrounded = true;
    public bool isDead = false;

    LayerMask groundLayer; //地面层
    LayerMask enemyLayer; //敌人层

	private Transform _transform;
	private Animator _animator;
	private Rigidbody2D _rigidbody2D;

	private Vector2 check_ground;

    void Start ()
    {
        Init();
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal"); //获取玩家在水平方向上的输入
        if (!isDead)
        { 
			if (h>0){
				_animator.SetTrigger("PlayerWalkRight");
			}else if (h<0){
				_animator.SetTrigger("PlayerWalkLeft");
			}
            Move(h); 
        }
        CheckIsGrounded();
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    //初始化函数
    void Init()
    {
		_rigidbody2D = GetComponent<Rigidbody2D>() as Rigidbody2D;
        _animator = GetComponent<Animator>() as Animator;
		_transform = GetComponent<Transform>() as Transform;

        groundLayer = 1 << LayerMask.NameToLayer("Ground");
        enemyLayer = 1 << LayerMask.NameToLayer("Enemy");     
    }

    //玩家移动函数，运用Unity2D物理自带函数实现
    void Move(float dic)
    {
        _rigidbody2D.velocity = new Vector2(dic * curSpeed, _rigidbody2D.velocity.y);
    }
    
    void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, jumpHeight));
    }

    //射线检测是否接触地面，只有当接触地面的时候才可以跳跃以免出现n连跳的情况
    void CheckIsGrounded()
    {
		if (Physics2D.Raycast(this.transform.position, Vector2.down, checkDistance, groundLayer.value)){
			isGrounded = true;
			// Debug.Log("IS GROUNDED");
		} else{
            // anim.SetBool("IsGrounded", false);
            isGrounded = false;
			// Debug.Log("NOT GROUNDED");
        }
    }

    //运用2D相交圆检测脚下是否有怪物
    // void CheckHit()
    // {
    //     var check = checkPoint.position;
    //     var hit = Physics2D.OverlapCircle(check, 0.07f, enemyLayer.value);

    //     if (hit != null)
    //     {
    //         if (hit.CompareTag("Normal")) //若踩中普通怪物，则给予玩家一个反弹力，并触发怪物的死亡效果
    //         {
    //             Debug.Log("Hit Normal!");
    //             rig2d.velocity = new Vector2(rig2d.velocity.x, 5f);
    //             hit.GetComponentInParent<EnemyCharacter>().isHit = true;
    //         }
    //         else if (hit.CompareTag("Special")) //若踩中特殊怪物（乌龟），则在敌人相关代码中做对应变化
    //         {
    //             hitCount += 1;
    //             if (hitCount == 1)
    //             {
    //                 rig2d.velocity = new Vector2(rig2d.velocity.x, 5f);
    //                 hit.GetComponentInParent<EnemyCharacter>().GetHit(1);
    //             }
    //         }
    //     }
    // }

    public void Die()
    {
        Debug.Log("Player Die!");
        isDead = true;
        _rigidbody2D.velocity = new Vector2(0, 0);
    }

}
