using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] bool isReadyForInput;
    [SerializeField] bool wasUsed;

    public bool enable;

    public GameObject target0;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public GameObject otherTerminal;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Otis")
            return;

        isReadyForInput = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name != "Otis")
            return;

        isReadyForInput = false;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }


    void Update()
    {
        if (isReadyForInput == true && wasUsed == false && Input.GetKey(KeyCode.E))
        {
            wasUsed = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            if (enable == true)
            {
                target0.SetActive(true);
                target1.SetActive(true);
                otherTerminal.SetActive(false);
            }
            else
            {
                target0.SetActive(false);
                target1.SetActive(false);
                target2.SetActive(false);
                target3.SetActive(false);
            }
        }
    }
}
