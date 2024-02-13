using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    public static Vector3 playerPositionBeforeSceneChange;
    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerPositionBeforeSceneChange = other.transform.position;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
