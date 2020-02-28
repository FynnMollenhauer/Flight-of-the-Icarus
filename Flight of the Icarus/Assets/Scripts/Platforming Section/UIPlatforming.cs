using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class UIPlatforming : MonoBehaviour
{
    public Text ikeHealth;
    public Text otisHealth;
    public Text ikeAntigrav;
    public Text otisAntigrav;
    public Text keysCollected;
    public Text activeItem;
    public Text activePlayer;
    public Button seeControls;
    public Image controls;

    public bool controlsActive;


    void Update()
    {
        ikeHealth.text = "Ike's Health: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().IkeHealth;
        otisHealth.text = "Otis' Health: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().OtisHealth;

        ikeAntigrav.text = "Ike's Antigrav: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ikeAntigrav;
        otisAntigrav.text = "Otis' Antigrav: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().otisAntigrav;

        keysCollected.text = "Number of Key's collected: " + GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().keysCollected;

        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().activeItem == 0)
        {
            activeItem.text = "Active Item: Bounce Shoes (Ike)";
        }
        else if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().activeItem == 1)
        {
            activeItem.text = "Active Item: Baseball Bat (Ike)";
        }
        else if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().activeItem == 2)
        {
            activeItem.text = "Active Item: Flashlight (Otis)";
        }

        if (GameObject.Find("Ike").GetComponent<ThirdPersonUserControl>().isActivePlayer == true)
        {
            activePlayer.text = "Active Player: Ike";
        }
        else if (GameObject.Find("Otis").GetComponent<ThirdPersonUserControl>().isActivePlayer == true)
        {
            activePlayer.text = "Active Player: Otis";
        }

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
