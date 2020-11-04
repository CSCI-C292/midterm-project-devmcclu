using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    TimeSpan _timePlaying;
    float _levelTime;
    bool _isCounting;

    void Awake()
    {
        _isCounting = true;
        _timerText.text = "Time: 00:00.00";
        _levelTime = 0f;
        StartCoroutine(CountTimer());
    }

    public IEnumerator CountTimer()
    {
        while(_isCounting)
        {
            _levelTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(_levelTime);
            _timerText.text = String.Concat("Time: ", _timePlaying.ToString("mm':'ss'.'ff"));

            yield return null;
        }
    }

    public void StopTimer()
    {
        _isCounting = false;
    }
}
