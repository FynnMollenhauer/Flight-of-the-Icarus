using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

        private GameObject[] playerCharacters;

        private void Start()
        {
            playerCharacters = GameObject.FindGameObjectsWithTag("Player");
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


        private void LateUpdate()
        {
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
            transform.position = target.position + offset;

        }
    }
}
