using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] string _levelToLoad;
    [SerializeField] CanvasType _canvasType;
    [SerializeField] Canvas _canvas;
    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        if(_canvasType == CanvasType.LevelEnd)
        {
            GameEvents.LevelFinished += OnLevelEnd;
        }
        else if (_canvasType == CanvasType.Death)
        {
            GameEvents.PlayerDied +=  OnLevelEnd;
        }
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
