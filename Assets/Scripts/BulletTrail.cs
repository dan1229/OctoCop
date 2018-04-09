using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour {

    public float movespeed = 3;
    //Transform currentPosition;

    void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
        Vector3 currentlocation = transform.position;
        transform.Translate((mousePosition - currentlocation) * Time.deltaTime * movespeed);
        Destroy(gameObject, 1);
	}
}
