using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] string _levelToLoad;
    [SerializeField] CanvasType _canvasType;
    [SerializeField] Canvas _canvas;
    [SerializeField] LevelTimer _levelTimer;
    void Awake()
    {
        //_canvas = GetComponent<Canvas>();
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
        if(_canvasType == CanvasType.LevelEnd)
        {
            _levelTimer.StopTimer();
            GameEvents.LevelFinished -= OnLevelEnd;
        }
        else if (_canvasType == CanvasType.Death)
        {
            GameEvents.PlayerDied -=  OnLevelEnd;
        }
        SceneManager.LoadScene(_levelToLoad);
    }
}
