using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] Animator transition;
    private float transitionTime = 0.5f;

    int currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadDesertLevel()
    {
        SceneManager.LoadScene("Desert");
    }

    public void LoadArcticLevel()
    {
        SceneManager.LoadScene("Arctic");
    }

    public void LoadForestLevel()
    {
        SceneManager.LoadScene("Forest");
    }

    public IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }

}