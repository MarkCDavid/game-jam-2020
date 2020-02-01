using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class Explodify : MonoBehaviour
{
    private Rigidbody[] rbs;

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Start()
    {
        foreach (var rb in rbs)
        {
            rb.transform.SetParent(null);
            rb.AddForce(UnityEngine.Random.insideUnitSphere * 100, ForceMode.Impulse);
        }

    }
}
