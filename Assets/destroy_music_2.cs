using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_music_2: MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music_lvl1");
        if (objs.Length > 0)
            Destroy(objs[0]);
    }
}
