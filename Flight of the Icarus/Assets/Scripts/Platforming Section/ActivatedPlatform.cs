using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedPlatform : MonoBehaviour
{

    public bool isUp;
    public bool isDown;
    public float speedMultiplier;

    private bool isActivated;

    public Vector3 originalPosition;

    private float timePassed;



    private void Start()
    {
        speedMultiplier = 2.0f;
        originalPosition = gameObject.GetComponent<Transform>().position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        isActivated = true;
        timePassed = 0;

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        isActivated = false;
    }


    void Update()
    {
        if (isActivated == false)
        {
            timePassed += Time.deltaTime;
        }

        if (isActivated == true && isUp == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedMultiplier, Space.World);
        }

        else if (isActivated == true && isDown == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speedMultiplier, Space.World);
        }

        else if (isActivated == false && timePassed >= 1.0f)
        {
            gameObject.GetComponent<Transform>().position = originalPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
