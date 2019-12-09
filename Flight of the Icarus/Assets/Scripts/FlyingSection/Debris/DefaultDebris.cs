using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDebris : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.gameObject.GetComponent<ContraptionController>().damageTaken += 1;
        gameObject.SetActive(false);
    }
}
