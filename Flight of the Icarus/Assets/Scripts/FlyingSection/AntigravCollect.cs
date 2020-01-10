using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntigravCollect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "PlatformingLevel")
        {
            if (other.name == "Ike")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeAntigrav += 1;
            }
            else if (other.name == "Otis")
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().otisAntigrav += 1;
            }
        }

        else
        {
            other.gameObject.GetComponent<ContraptionController>().antigravCollected += 1;
        }
        
        gameObject.SetActive(false);
    }


}
