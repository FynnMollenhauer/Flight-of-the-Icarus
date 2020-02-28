using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITitleScreen : MonoBehaviour
{
    public Button startGame;

    public Button seeFlyingControls;
    public Image flyingControls;

    public Button seePlatformingControls;
    public Image platformingControls;

    public bool flyingControlsActive;
    public bool platformingControlsActive;

    public void ShowFlyingControls()
    {
        if (flyingControlsActive == true)
        {
            flyingControls.gameObject.SetActive(false);
            flyingControlsActive = false;
        }
        else if (flyingControlsActive == false)
        {
            flyingControls.gameObject.SetActive(true);
            flyingControlsActive = true;
        }
    }

    public void ShowPlatformingControls()
    {
        if (platformingControlsActive == true)
        {
            platformingControls.gameObject.SetActive(false);
            platformingControlsActive = false;
        }
        else if (platformingControlsActive == false)
        {
            platformingControls.gameObject.SetActive(true);
            platformingControlsActive = true;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
