using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().keysCollected += 1;

        gameObject.SetActive(false);
    }

}
