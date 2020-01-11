using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private float timePassed;
    private bool isActivated;
    private float thrustForce;

    public Vector3 offset;
    public float thrustForceMultiplier;
    public float delayTime;

    void Start()
    {
    }

    void Update()
    {
        if (isActivated == true)
        {
            timePassed += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            thrustForce = timePassed * thrustForceMultiplier;
            isActivated = false;
            timePassed = 0;
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, thrustForce));
            StartCoroutine(Return());
        }

    }

    public void SwingBat()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 0) + offset;
            gameObject.transform.rotation = GameObject.Find("Ike").GetComponent<Transform>().rotation;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            timePassed = 0;
            isActivated = true;
        }
        
    }


    private IEnumerator Return()
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
