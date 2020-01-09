using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAnomaly : MonoBehaviour
{

    public Vector3 propellingForce;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.GetComponent<Rigidbody>().velocity = (new Vector3 (other.GetComponent<Rigidbody>().velocity.x, 0.0f, other.GetComponent<Rigidbody>().velocity.z));

        other.GetComponent<Rigidbody>().AddForce(propellingForce);
    }
}
