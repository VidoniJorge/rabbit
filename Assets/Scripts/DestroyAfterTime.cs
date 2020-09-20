using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(this.timeToDestroy);
        Destroy(this.gameObject);
    }
}
