using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public int ResetAmount;
    public int FallChance;
    public int FallenPassengers;

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

        if (ResetAmount >= FallChance)
        {
            ResetAmount = FallChance;
        }
    }
}





    