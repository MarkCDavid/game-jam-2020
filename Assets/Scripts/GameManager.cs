using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private float _time = 0f;
    void Awake()
    {
//        Cursor.lockState = CursorLockMode.Locked;
//        Cursor.visible = false;
    }

    private float sixminutes = 0.5f * 60;
    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time > sixminutes)
        {
            SceneManager.LoadScene(2);
            Destroy(gameObject);
        }
    }
}
