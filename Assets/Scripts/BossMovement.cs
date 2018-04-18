using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    [SerializeField]
    private float movespeed;
    private float moveVelocity;
    private Animator myAnimation;

    // Use this for initialization
    void Start()
    {

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        myAnimation.SetFloat("Speed", vertical);
        var horizontal = Input.GetAxis("Horizontal");
        myAnimation.SetFloat("Speed", horizontal);
        if (myRigidBody.velocity.x == 0)
        {
            moveVelocity = movespeed;
            myRigidBody.velocity = new Vector2(moveVelocity, myRigidBody.velocity.y);
        }
        if (myRigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
        else if (myRigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-3f, 3f, 3f);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Destroyable")
        {
            Destroy(col.gameObject);
        }
    }
}

