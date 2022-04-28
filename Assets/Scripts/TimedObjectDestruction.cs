using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestruction : MonoBehaviour
{
    public float timeOut = 2.0f;

    public bool detachChildren = false;

    private void Awake()
    {
        Invoke("DestroyNow", timeOut);
    }

    private void DestroyNow()
    {
        if(detachChildren)
        {
            transform.DetachChildren();
        }

        Destroy(gameObject);
    }
}
