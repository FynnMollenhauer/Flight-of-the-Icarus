using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ContraptionController : MonoBehaviour
{
    float gravity;
    float speed;
    int health;

    public float gravityMultiplier;
    public float speedMultiplier;

    public float steeringSpeed;
    public float panningSpeed;

    public int antigravCollected;

    public int defaultHealth;
    public int damageTaken;
    int obtainedHealth;


    void Start()
    {
        gravityMultiplier = 1.0f;
        speedMultiplier = 5.0f;
        defaultHealth = 2;
        damageTaken = 0;

    }


    void FixedUpdate()
    {
        Debug.Log(health);
        gravity = (gravityMultiplier + ((90.0f - (UnityEditor.TransformUtils.GetInspectorRotation(GameObject.FindGameObjectWithTag("Kite").transform).x * -1.0f)) / 20.0f) - (antigravCollected * 0.01f)) * -1.0f;
        if (gravity >= -0.2f)
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

        if (antigravCollected >= 25 && antigravCollected < 60)
        {
            obtainedHealth = 1;
        }
        else if (antigravCollected >= 60 && antigravCollected < 100)
        {
            obtainedHealth = 2;
        }
        else if (antigravCollected >= 100)
        {
            obtainedHealth = 3;
        }
        else
        {
            obtainedHealth = 0;
        }

        health = defaultHealth + obtainedHealth - damageTaken;


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


        if (health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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



