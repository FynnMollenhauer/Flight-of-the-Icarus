using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContraptionController : MonoBehaviour
{
    public float gravityMultiplier;


    void Start()
    {
        gravityMultiplier = 2.0f;

    }


    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude <= gravityMultiplier)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down * gravityMultiplier);
        }

        Debug.Log(gameObject.transform.position.y);
    }
}
