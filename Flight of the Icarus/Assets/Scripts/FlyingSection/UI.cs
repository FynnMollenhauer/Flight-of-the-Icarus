using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text health;
    public Text antigrav;
    public Text passengers;
    public Button seeControls;
    public Image controls;

    public bool controlsActive;

    void Update()
    {
        health.text = "Health: " + GameObject.FindGameObjectWithTag("Player").GetComponent<ContraptionController>().health;
        antigrav.text = "Antigrav: " + GameObject.FindGameObjectWithTag("Player").GetComponent<ContraptionController>().antigravCollected;
        passengers.text = "Townspeople: " + (3 - GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallenPassengers);

    }

    public void ShowControls()
    {
        if (controlsActive == true)
        {
            controls.gameObject.SetActive(false);
            controlsActive = false;
        }
        else if (controlsActive == false)
        {
            controls.gameObject.SetActive(true);
            controlsActive = true;
        }
    } 
}
