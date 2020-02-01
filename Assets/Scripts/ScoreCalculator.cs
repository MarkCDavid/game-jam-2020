using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public TMP_Text scoreText;
    
    private bool _scoringStarted;
    private FadeIn _fi;

    private static float _currentScore = 0f;

    public static int CurrentScore => Mathf.RoundToInt(_currentScore);

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _fi = GetComponent<FadeIn>();
        _fi.OnFadeEnd += () => { _scoringStarted = true; };
    }  

    // Update is called once per frame
    void Update()
    {
        if (_scoringStarted)
        {
            _currentScore += Time.deltaTime;
            scoreText.text = $"Score: {CurrentScore}";
        }
    }

    public static void AddScore(int score)
    {
        _currentScore += score;
    }
}
