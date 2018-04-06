using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMovement : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float movespeed;
    private float moveVelocity;
    private Animator myAnimation;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //moveVelocity = movespeed;
        //myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        myAnimation.SetFloat("Speed", vertical);
        var horizontal = Input.GetAxis("Horizontal");
        myAnimation.SetFloat("Speed", horizontal);
        if (myRigidBody.velocity.x == 0) { 
            moveVelocity = movespeed;
            myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GroundLayer")
        {
            moveVelocity = -movespeed;
            myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
        }
    }
}
