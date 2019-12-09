using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownDebris : MonoBehaviour
{
    float startPosition;
    public float movementSpeed;
    public float movementRange;

    void Start()
    {
        startPosition = transform.position.y;

        StartCoroutine(UpDown());
    }

    private IEnumerator UpDown()
    {
        while (true)
        {
            Vector3 pastPosition = transform.position;
            transform.position = new Vector3(transform.position.x, startPosition + (Mathf.Cos(Time.time * movementSpeed) * movementRange), transform.position.z);
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
