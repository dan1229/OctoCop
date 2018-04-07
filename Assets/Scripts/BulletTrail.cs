using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour {

    public float movespeed = 1;
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
        transform.Translate(mousePosition * Time.deltaTime * movespeed);
        Destroy(gameObject, 1);
	}
}
