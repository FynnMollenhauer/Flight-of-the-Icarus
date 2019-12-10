using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text health;
    public Text antigrav;
    public Text passengers;

    void Start()
    {
        
    }


    void Update()
    {
        health.text = "Health:" + GameObject.FindGameObjectWithTag("Player").GetComponent<ContraptionController>().health;
        antigrav.text = "Antigrav:" + GameObject.FindGameObjectWithTag("Player").GetComponent<ContraptionController>().antigravCollected;
        passengers.text = "Townspeople:" + (3 - GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallenPassengers);

    }
}
