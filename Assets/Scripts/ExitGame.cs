using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public float TimeToExit;

    private float _exitTime;
    // Update is called once per frame
    void Update()
    {
        _exitTime += Time.deltaTime;
        if (_exitTime > TimeToExit)
            Application.Quit();
    }
}
