using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player")) return;

        if (other.name == "Ike")
		{
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth > 1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth -= 1;
                other.GetComponent<Transform>().position = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeLastCheckpoint;
            }
            else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth <= 1)
            {
                reloadScene();
            }
        }

        else if (other.name == "Otis")
        {
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth > 1)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth -= 1;
                other.GetComponent<Transform>().position = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().otisLastCheckpoint;
            }
            else if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth <= 1)
            {
                reloadScene();
            }
        }
    }


    public void reloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth = 4;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth = 2;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeAntigrav = 0;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().otisAntigrav = 0;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().keysCollected = 0;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().bigButtonActivations = 0;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().bigButtonTarget = GameObject.FindGameObjectWithTag("BigButtonTarget");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().bigButtonTarget1 = GameObject.FindGameObjectWithTag("BigButtonTarget1");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeLastCheckpoint = new Vector3(3, -1.5f, -65.5f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().otisLastCheckpoint = new Vector3(3, -1.5f, -65.5f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().flashlightPickedUp = false;

        SceneManager.LoadScene(sceneName);
    }
    
}
