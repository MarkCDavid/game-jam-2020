using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Height : MonoBehaviour
{
    public float HeightTarget = 0;
    public float DecentSpeed = 0f;
    public Action OnPlaneFall;

    void SpeedChange(float Severity) {
        DecentSpeed  = Severity;        
    }
    void Update()
    {   if(transform.position.y + DecentSpeed<100)
        transform.position = new Vector3(transform.position.x, transform.position.y+DecentSpeed, transform.position.z);
        if (transform.position.y < HeightTarget)
            OnPlaneFall?.Invoke();
    }
}
