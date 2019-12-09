using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightDebris : MonoBehaviour
{
    float startPosition;
    public float movementSpeed;
    public float movementRange;

    void Start()
    {
        startPosition = transform.position.x;

        StartCoroutine(LeftRight());
    }

    private IEnumerator LeftRight()
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

        other.gameObject.GetComponent<ContraptionController>().damageTaken += 1;
        gameObject.SetActive(false);
    }
}
