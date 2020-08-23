using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausaPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausing();
        }
    }
    void Pausing()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<ThirdPersonCamera>().enabled = false;
        pausaPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<ThirdPersonCamera>().enabled = true;
        pausaPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
