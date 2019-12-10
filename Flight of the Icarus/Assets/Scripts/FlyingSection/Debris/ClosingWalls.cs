using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingWalls : MonoBehaviour
{
    float startPosition;
    Quaternion startRotation;
    public float movementSpeed;
    public float movementRange;

    int resetAmount;
    int fallChance;
    int fallenPassengers;

    void Start()
    {
        startPosition = transform.position.x;
        startRotation = transform.localRotation;
        StartCoroutine(LeftRight());
    }

    private IEnumerator LeftRight()
    {
        if (gameObject.tag == "LeftWall")
        {
            while (true)
            {
                Vector3 pastPosition = transform.position;
                transform.position = new Vector3(startPosition + (Mathf.Cos(Time.time * movementSpeed) * movementRange), transform.position.y, transform.position.z);
                transform.forward = (transform.position - pastPosition).normalized;
                transform.localRotation = startRotation;
                yield return new WaitForEndOfFrame();
            }
        }
        else if (gameObject.tag == "RightWall")
        {
            while (true)
            {
                Vector3 pastPosition = transform.position;
                transform.position = new Vector3(startPosition - (Mathf.Cos(Time.time * movementSpeed) * movementRange), transform.position.y, transform.position.z);
                transform.forward = (transform.position - pastPosition).normalized;
                transform.localRotation = startRotation;
                yield return new WaitForEndOfFrame();
            }
        }

    }


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
