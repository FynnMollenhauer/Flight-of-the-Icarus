using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Utility;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public int ResetAmount;
    public int FallChance;
    public int FallenPassengers;

    private GameObject[] playerCharacters;

    public GameObject bigButtonTarget;
    public GameObject bigButtonTarget1;

    public int IkeHealth;
    public int OtisHealth;

    public float ikeAntigrav;
    public float otisAntigrav;

    public int keysCollected;

    public int bigButtonActivations;

    public bool flashlightPickedUp;

    public int activeItem;

    public Vector3 ikeLastCheckpoint;
    public Vector3 otisLastCheckpoint;
   
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
        FallChance = 20;
        FallenPassengers = 0;

        IkeHealth = 4;
        OtisHealth = 2;

        ikeAntigrav = 0;
        otisAntigrav = 0;

        keysCollected = 0;

        bigButtonActivations = 0;

        activeItem = 0;

        flashlightPickedUp = false;

        ikeLastCheckpoint = new Vector3(3, -1.5f, -65.5f);
        otisLastCheckpoint = new Vector3(3, -1.5f, -65.5f);

        if (ResetAmount >= FallChance)
        {
            ResetAmount = FallChance;
        }
    }

    private void Update()
    {
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "PlatformingLevel")
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                for (int i = 0; i < playerCharacters.Length; i++)
                {
                    playerCharacters[i].GetComponent<FollowHandHolding>().isHandHolding = false;
                    playerCharacters[i].GetComponent<FollowHandHolding>().isHandHolding = false;

                    playerCharacters[i].GetComponent<ThirdPersonUserControl>().isActivePlayer = !playerCharacters[i].GetComponent<ThirdPersonUserControl>().isActivePlayer;
                }
            }


            if (bigButtonActivations >= 3)
            {
                bigButtonTarget.SetActive(true);
                bigButtonTarget1.SetActive(false);
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                activeItem += 1;

                if (flashlightPickedUp == false && activeItem > 1)
                {
                    activeItem = 0;
                }
                else if (flashlightPickedUp == true && activeItem > 2)
                {
                    activeItem = 0;
                }
            }


            if (activeItem == 0)
            {
               GameObject.Find("Ike").GetComponent<ThirdPersonCharacter>().m_JumpPower = 15;
               GameObject.Find("FlashlightOn").GetComponent<Light>().enabled = false;
            }
            else if (activeItem == 1)
            {
                GameObject.Find("Ike").GetComponent<ThirdPersonCharacter>().m_JumpPower = 10;
                GameObject.Find("FlashlightOn").GetComponent<Light>().enabled = false;
            }
            else if (activeItem == 2 && flashlightPickedUp == true)
            {
                GameObject.Find("FlashlightOn").GetComponent<Light>().enabled = true;
                GameObject.Find("Ike").GetComponent<ThirdPersonCharacter>().m_JumpPower = 10;
            }
        }
    }
}





    