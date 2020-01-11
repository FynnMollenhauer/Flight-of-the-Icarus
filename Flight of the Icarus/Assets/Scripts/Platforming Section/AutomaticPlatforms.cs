using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticPlatforms : MonoBehaviour
{
    float startPosition;
    public float movementSpeed;
    public float movementRange;

    public bool isSideways;
    public bool isForward;

    void Start()
    {
        if (isForward == true)
        {
            startPosition = transform.position.z;

            StartCoroutine(Forward());
        }
        else if (isSideways == true)
        {
            startPosition = transform.position.x;

            StartCoroutine(Sideways());
        }
        
    }

    private IEnumerator Forward()
    {
        while (true)
        {
            Vector3 pastPosition = transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, startPosition + (Mathf.Cos(Time.time * movementSpeed) * movementRange));
            transform.forward = (transform.position - pastPosition).normalized;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator Sideways()
    {
        while (true)
        {
            Vector3 pastPosition = transform.position;
            transform.position = new Vector3(startPosition + (Mathf.Cos(Time.time * movementSpeed) * movementRange), transform.position.y, transform.position.z);
            transform.forward = (transform.position - pastPosition).normalized;
            yield return new WaitForEndOfFrame();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.transform.parent = null;
    }
}
