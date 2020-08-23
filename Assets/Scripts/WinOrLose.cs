using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinOrLose : MonoBehaviour
{
    public GameObject panel;
    public Text title;
    public void Lose()
    {
        Time.timeScale = 0f;
        DisplayText("PERDISTE");
    }
    public void Win()
    {
        Time.timeScale = 0f;
        DisplayText("GANASTE");
    }
    private void DisplayText(string text)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<ThirdPersonCamera>().enabled = false;
        panel.SetActive(true);
        title.text = text;
    }
    public void Restart()
    {
        FindObjectOfType<LevelLoader>().ReloadLevel();
    }
    public void Menu()
    {
        FindObjectOfType<LevelLoader>().LoadLevel("New Scene");
    }
}
