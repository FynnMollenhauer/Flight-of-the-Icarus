using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraFromBehind : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraDistance;
    public float updateSpeed;

    private GameObject[] playerCharacters;

    void Start()
    {
        cameraDistance = new Vector3(0, -4, 10);
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        updateSpeed = 5;
    }

    private void Update()
    {
        for (int i = 0; i < playerCharacters.Length; i++)
        {
            if (playerCharacters[i].GetComponent<ThirdPersonUserControl>().isActivePlayer == true)
            {
                target = playerCharacters[i].GetComponent<Transform>();
            }
        }

        if (target == null)
        {
            enabled = false;

            return;
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, target.position - target.forward * cameraDistance.z - target.up * cameraDistance.y, Time.deltaTime * updateSpeed);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), updateSpeed * Time.deltaTime);
    }
}
