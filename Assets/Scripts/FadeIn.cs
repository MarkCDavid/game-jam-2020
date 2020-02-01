using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Action OnFadeEnd;
    
    public GameObject issues;
    public Image fadeImage;
    public float fadeTime;

    private float _currentFadeTime = -2;
    
    public void Start()
    {
        issues.SetActive(false);
    }

    public void Update()
    {
        if (fadeImage != null)
        {
            if (_currentFadeTime <= fadeTime)
            {
                _currentFadeTime += Time.deltaTime;

                while (_currentFadeTime < 0)
                    return;

                var color = fadeImage.color;
                var alpha = Mathf.Lerp(1, 0, _currentFadeTime / fadeTime);
                fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            }

            if (_currentFadeTime > fadeTime)
            {
                issues.SetActive(true);
                OnFadeEnd?.Invoke();
            }
        }
    }

}
