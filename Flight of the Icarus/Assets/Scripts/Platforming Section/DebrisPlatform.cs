using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DebrisPlatform : MonoBehaviour
{
    public Vector3 offset;

    private float thrustForce;
    private float timePassed;

    public bool isAwaitingInput;
    public float thrustForceMultiplier;


    private void Start()
    {
        timePassed = 0;
        isAwaitingInput = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ike")
            return;

        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().activeItem == 1)
        {
            timePassed = 0;
            isAwaitingInput = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name != "Ike")
            return;

        timePassed = 0;
        isAwaitingInput = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!Input.anyKey && other.name == "Otis")
        {
            other.transform.position = transform.position + offset;
        }
        
    }


    private void Update()
    {
        if (isAwaitingInput == true && Input.GetKey(KeyCode.E))
        {
            timePassed += Time.deltaTime;
            Debug.Log(timePassed);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (timePassed >= 0.8f)
            {
                timePassed = 0.8f;
            }
            thrustForce = timePassed * thrustForceMultiplier;
            timePassed = 0;
            gameObject.GetComponent<Rigidbody>().AddForce(GameObject.Find("Ike").GetComponent<Transform>().forward * thrustForce);
        }
    }
    
}
