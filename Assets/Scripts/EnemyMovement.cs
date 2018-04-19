using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMovement : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float movespeed;
    private float moveVelocity;
    private Animator myAnimation;
    bool shot;
    int count;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myRigidBody.velocity.x == 0 && !shot) { 
            moveVelocity = movespeed;
            myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
        }
        if (myRigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (myRigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (shot)
        {
            count++;
            if (count == 10)
            {
                shot = false;
                count = 0;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "GroundLayer")
        {
            movespeed *= -1;
        }
        if(col.gameObject.tag == "Bullet")
        {
            moveVelocity = 0;
            myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
            shot = true;
        }
    }
}
