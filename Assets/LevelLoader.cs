using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] string _levelToLoad;
    Canvas _canvas;
    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        GameEvents.LevelFinished += OnLevelEnd;
    }

    void OnLevelEnd(object sender, EventArgs args)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        _canvas.enabled = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
