using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDebris : MonoBehaviour
{
    int resetAmount;
    int fallChance;
    int fallenPassengers;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        resetAmount = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ResetAmount;
        fallChance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallChance;
        fallenPassengers = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallenPassengers;

        if ((resetAmount / fallChance >= Random.Range(0.0f, 1.2f)) && (fallenPassengers <= 2) && (other.gameObject.GetComponent<ContraptionController>().health >= 2))
        {
           other.gameObject.GetComponent<ContraptionController>().passengers[fallenPassengers].GetComponent<Rigidbody>().useGravity = true;
           GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallenPassengers += 1;
        }

        other.gameObject.GetComponent<ContraptionController>().damageTaken += 1;
        gameObject.SetActive(false);
    }
}
