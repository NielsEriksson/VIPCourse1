using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject playing, paused, handIcon;

    public void OnToggleMenu()
    {
        isPaused = !isPaused;
        
        playing.SetActive(!isPaused);
        paused.SetActive(isPaused);
        if(isPaused ) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
