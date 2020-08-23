using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject options;
    public void Play()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(Random.Range(0, 3) == 0 ? "DemoScene 1" : "DemoScene 2");
    }
    public void Options()
    {
        options.SetActive(true);
    }
    public void SetGraphics(int ind)
    {
        FindObjectOfType<LevelLoader>().SetQuality(ind);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
