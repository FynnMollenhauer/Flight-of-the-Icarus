using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBackDebris : MonoBehaviour
{
    float startPosition;
    public float movementSpeed;
    public float movementRange;

    void Start()
    {
        startPosition = transform.position.z;

        StartCoroutine(ForwardBack());
    }

    private IEnumerator ForwardBack()
    {
        while (true)
        {
            Vector3 pastPosition = transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, startPosition + (Mathf.Cos(Time.time * movementSpeed) * movementRange));
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
