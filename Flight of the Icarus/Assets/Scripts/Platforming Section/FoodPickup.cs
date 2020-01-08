using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (other.name == "Ike")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth += 1;
            gameObject.SetActive(false);
        }

        if (other.name == "Otis")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth += 1;
            gameObject.SetActive(false);
        }
    }
}
