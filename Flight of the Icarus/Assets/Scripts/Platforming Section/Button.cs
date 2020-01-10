using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isReadyForInput;
    public bool wasUsed;

    public GameObject target;

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
        if (isReadyForInput == true && wasUsed == false && Input.GetKey(KeyCode.E))
        {
            target.SetActive(true);
            wasUsed = true;
            gameObject.transform.Translate(new Vector3(0, 0.4f, 0));
        }

    }
}
