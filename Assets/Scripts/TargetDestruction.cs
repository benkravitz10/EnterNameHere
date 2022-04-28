using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestruction : MonoBehaviour
{

    float deathTimer;
    


    // Start is called before the first frame update
    void Start()
    {
        deathTimer = Random.Range(1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer = deathTimer - Time.deltaTime;

        if(deathTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
