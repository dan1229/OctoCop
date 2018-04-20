using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_for_scene : MonoBehaviour
{
    public float timer = 1f;

    public void Start() {}
	
	// Update is called once per frame
	public void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
