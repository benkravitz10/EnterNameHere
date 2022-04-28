using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float power = 100f;

    public GameObject projectile;

    public AudioClip shootAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            if(projectile)
            {
                GameObject nProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
                nProjectile.SetActive(true);
                
                if(!nProjectile.GetComponent<Rigidbody>())
                {
                    nProjectile.AddComponent<Rigidbody>();
                }

                nProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                if(shootAudio)
                {
                    if(nProjectile.GetComponent<AudioSource>())
                    {
                        nProjectile.GetComponent<AudioSource>().PlayOneShot(shootAudio);
                    }

                    else
                    {
                        AudioSource.PlayClipAtPoint(shootAudio, nProjectile.transform.position);
                    }
                }
            }
        }
    }
}
