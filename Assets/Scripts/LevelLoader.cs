using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class LevelLoader : MonoBehaviour
{
    int QualityLevel = 2;
    void Awake()
    {
        CheckIfDuplicated();
    }
    private void OnLevelWasLoaded(int level)
    {
        SetQuality(QualityLevel);
        Time.timeScale = 1;
    }
    void CheckIfDuplicated()
    {
        if (FindObjectsOfType<LevelLoader>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void ReloadLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }
    public void SetQuality(int index)
    {
        QualityLevel = index;
        QualitySettings.SetQualityLevel(QualityLevel);
        Camera.main.GetComponent<Volume>().enabled = (QualityLevel == 2);
    }
}
