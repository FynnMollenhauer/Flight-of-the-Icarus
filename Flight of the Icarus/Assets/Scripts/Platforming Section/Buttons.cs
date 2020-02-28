using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool isReadyForInput;
    public bool wasUsed;

    public bool isBigButton;

    public GameObject target;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isReadyForInput = true;
        }
           
        else if (collision.gameObject.tag == "InteractibleDebris" && wasUsed == false)
        {
            if (isBigButton == true)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().bigButtonActivations += 1;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().bigButtonTarget = GameObject.Find("GameManagerHelper").GetComponent<GameManagerHelper>().bigButtonTarget;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().bigButtonTarget1 = GameObject.Find("GameManagerHelper").GetComponent<GameManagerHelper>().bigButtonTarget1;
            }
            else
            {
                target.SetActive(true);
            }
            wasUsed = true;
            gameObject.transform.Translate(new Vector3(0, 0.4f, 0));
        }

        else
        {
            return;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        isReadyForInput = false;
    }



    void Update()
    {
        if (isReadyForInput == true && wasUsed == false && Input.GetKey(KeyCode.E))
        {
            target.SetActive(true);
            wasUsed = true;
            gameObject.transform.Translate(new Vector3(0, 0.4f, 0));
        }

    }
}
