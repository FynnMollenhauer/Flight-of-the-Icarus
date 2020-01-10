using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Utility
{
    public class FollowHandHolding : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 0f, -1.0f);

        public bool isHandHolding = false;

        private void Start()
        {
            
        }

        private void Update()
        {

            

            if (gameObject.GetComponent<ThirdPersonUserControl>().isActivePlayer == false && isHandHolding == false && Vector3.Distance(target.position, transform.position) <= 5)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    isHandHolding = true;
                }
            }
            else if (gameObject.GetComponent<ThirdPersonUserControl>().isActivePlayer == false && isHandHolding == true)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    isHandHolding = false;
                }
            }
        }


        private void LateUpdate()
        {
            if (isHandHolding == true)
            {
                transform.position = target.position + offset;
            }
        }

    }
}
