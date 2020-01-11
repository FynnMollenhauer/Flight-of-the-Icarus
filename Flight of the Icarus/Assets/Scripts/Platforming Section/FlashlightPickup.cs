using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().flashlightPickedUp = true;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().activeItem = 2;

        gameObject.SetActive(false);
    }
}
