using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    int currentScene;
    int nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision newCollision)
    {
        // only do stuff if hit by a projectile
        if (newCollision.gameObject.tag == "Projectile")
        {
            
            currentScene++;

            if (currentScene >= 2)
            {
                currentScene = 0;
                SceneManager.LoadScene(currentScene);
            }

            
            SceneManager.LoadScene(currentScene);
            
        }
    }
}
