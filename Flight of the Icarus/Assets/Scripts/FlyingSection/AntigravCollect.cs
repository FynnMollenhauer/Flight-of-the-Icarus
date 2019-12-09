using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntigravCollect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.gameObject.GetComponent<ContraptionController>().antigravCollected += 1;
        gameObject.SetActive(false);
    }


}
