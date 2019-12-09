using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ContraptionController : MonoBehaviour
{
    float gravity;
    float speed;

    public float gravityMultiplier;
    public float speedMultiplier;

    public float steeringSpeed;
    public float panningSpeed;


    void Start()
    {
        gravityMultiplier= 1.0f;
        speedMultiplier = 5.0f;

    }


    void FixedUpdate()
    {
        Debug.Log(speed);
        gravity = (gravityMultiplier + ((90.0f - (UnityEditor.TransformUtils.GetInspectorRotation(GameObject.FindGameObjectWithTag("Kite").transform).x * -1.0f)) / 20.0f)) * -1;
        if (gravity >= 0.0f)
        {
            gravity = -0.2f;
        }

        speed = (speedMultiplier + ((90.0f - (UnityEditor.TransformUtils.GetInspectorRotation(GameObject.FindGameObjectWithTag("Kite").transform).x * -1.0f)) / 5.0f));
        if (speed < 3.0f)
        {
            speed = 3.0f;
        }
        else if (speed > 7)
        {
            speed = 7;
        }

        transform.position += transform.forward * Time.deltaTime * speed;

        transform.position += transform.up * Time.deltaTime * gravity;


        if (InputHelper.IsSteering())
        {
            MoveSteering(InputHelper.GetSteering());
        }

        if (InputHelper.IsPanning())
        {
            MovePanning(InputHelper.GetPanning());
        }

    }




    public void MoveSteering(float direction)
    {
        if (direction <= 0.0f)
        {
            transform.Rotate(0.0f, -steeringSpeed, 0.0f);
        }
        else if (direction >= 0.0f)
        {
            transform.Rotate(0.0f, steeringSpeed, 0.0f);
        }
    }


    public void MovePanning(float direction)
    {
        if (direction <= 0.0f)
        {
            if (UnityEditor.TransformUtils.GetInspectorRotation(GameObject.FindGameObjectWithTag("Kite").transform).x <= -75)
            {
                GameObject.FindGameObjectWithTag("Kite").transform.Rotate(-panningSpeed, 0.0f, 0.0f);
            }
        }

        else if (direction >= 0.0f)
        {
            if (UnityEditor.TransformUtils.GetInspectorRotation(GameObject.FindGameObjectWithTag("Kite").transform).x >= -105)
            {
                GameObject.FindGameObjectWithTag("Kite").transform.Rotate(panningSpeed, 0.0f, 0.0f);
            }
        }
    }





}



