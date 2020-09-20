using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static bool playCreated;
    void Start()
    {
        if (!playCreated)
        {
            playCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
