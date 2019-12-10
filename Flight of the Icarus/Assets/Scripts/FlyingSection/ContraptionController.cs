using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ContraptionController : MonoBehaviour
{
    float gravity;
    float speed;
    public int health;

    public float gravityMultiplier;
    public float speedMultiplier;

    public float steeringSpeed;
    public float panningSpeed;

    public int antigravCollected;

    public int defaultHealth;
    public int damageTaken;
    int obtainedHealth;

    public GameObject[] passengers;


    void Start()
    {
        gravityMultiplier = 1.0f;
        speedMultiplier = 5.0f;
        defaultHealth = 2;
        damageTaken = 0;

        passengers = GameObject.FindGameObjectsWithTag("Townspeople");

        switch (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallenPassengers)
        {
            case 1:
                passengers[0].SetActive(false);
                break;
            case 2:
                passengers[0].SetActive(false);
                passengers[1].SetActive(false);
                break;
            case 3:
                passengers[0].SetActive(false);
                passengers[1].SetActive(false);
                passengers[2].SetActive(false);
                break;
        }

    }


    void FixedUpdate()
    {
        Debug.Log(gravity);
        gravity = (gravityMultiplier + ((90.0f - (UnityEditor.TransformUtils.GetInspectorRotation(GameObject.FindGameObjectWithTag("Kite").transform).x * -1.0f)) / 20.0f) - (antigravCollected * 0.01f) - (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FallenPassengers / 10.0f)) * -1.0f;
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
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().ResetAmount += 1;

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



