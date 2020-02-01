using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameLoadScene : MonoBehaviour
{
    public Transform player;
    public GameObject GameManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            SceneManager.LoadScene(1);
        }
    }
}
