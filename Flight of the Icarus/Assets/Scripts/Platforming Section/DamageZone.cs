using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player")) return;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (other.name == "Ike")
		{
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth > 1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth -= 1;
                other.GetComponent<Transform>().position = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeLastCheckpoint;
            }
            else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth <= 1)
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        else if (other.name == "Otis")
        {
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth > 1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth -= 1;
                other.GetComponent<Transform>().position = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeLastCheckpoint;
            }
            else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth <= 1)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    
}
