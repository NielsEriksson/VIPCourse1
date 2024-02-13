using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject playing, paused, handIcon;

    [SerializeField] private GameObject inventoryBar;

    [SerializeField] private PlayerLook playerLook;

    public void OnToggleMenu()
    {
        isPaused = !isPaused;
        
        playing.SetActive(!isPaused);
        paused.SetActive(isPaused);
        if(isPaused ) Pause();
        else Unpause();
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        handIcon.SetActive(false);
        inventoryBar.SetActive(false);
        playerLook.enabled = false;
    }

    public void Unpause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        handIcon.SetActive(true);
        inventoryBar.SetActive(true);
        playerLook.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
