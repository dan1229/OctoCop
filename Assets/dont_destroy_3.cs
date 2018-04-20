using System.Collections;
using UnityEngine;

public class dont_destroy_3 : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music_lvl3");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
