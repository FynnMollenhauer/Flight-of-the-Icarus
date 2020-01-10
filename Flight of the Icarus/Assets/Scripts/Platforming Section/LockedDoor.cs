using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool isReadyForInput;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        isReadyForInput = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        isReadyForInput = false;
    }

    void Update()
    {
        if (isReadyForInput == true && Input.GetKey(KeyCode.E) && GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().keysCollected >= 1)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().keysCollected -= 1;
            gameObject.SetActive(false);
        }

    }

}
