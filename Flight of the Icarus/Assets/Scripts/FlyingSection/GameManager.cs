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

    public int IkeHealth;
    public int OtisHealth;

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
        }
    }
}





    