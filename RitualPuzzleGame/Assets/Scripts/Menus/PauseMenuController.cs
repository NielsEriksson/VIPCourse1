using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject playing, paused;

    public void OnToggleMenu()
    {
        isPaused = !isPaused;
        
        playing.SetActive(!isPaused);
        paused.SetActive(isPaused);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
