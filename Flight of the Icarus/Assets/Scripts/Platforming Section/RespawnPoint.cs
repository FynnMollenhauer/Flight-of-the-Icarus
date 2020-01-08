using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (other.name == "Ike")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeLastCheckpoint = gameObject.GetComponent<Transform>().position;
        }
        else if (other.name == "Otis")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().otisLastCheckpoint = gameObject.GetComponent<Transform>().position;
        }
    }
}
