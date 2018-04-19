using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour {

    public float movespeed = 3;
    public Vector3 mousePosition;
    //Transform currentPosition;

    void Awake()
    {
        mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
    }

    // Update is called once per frame
    void Update () {
        Vector3 currentlocation = transform.position;
        transform.Translate((mousePosition - currentlocation) * Time.deltaTime * movespeed);
        Destroy(gameObject, 1);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            print("WASTED");
            Destroy(this.gameObject);
        }
    }
}
