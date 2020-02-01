using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaneHeight : MonoBehaviour
{
    public Action onPlaneFall;
    
    public float heightTarget = 0;
    public float heightChangeSpeed = 1f;

    private float DecentSpeed => pitch.PitchCurrent * heightChangeSpeed * Time.deltaTime;

    private PlanePitch pitch;
    

    private void Awake()
    {
        pitch = GetComponent<PlanePitch>();
    }
    

    void Update()
    {
        var trueDescentSpeed = DecentSpeed * Time.deltaTime;
        var nextYPosition = transform.position.y - trueDescentSpeed;
        nextYPosition = Mathf.Clamp(nextYPosition, float.MinValue, 100f);
        transform.position = new Vector3(transform.position.x, nextYPosition, transform.position.z);
        
        if (transform.position.y < heightTarget)
            onPlaneFall?.Invoke();
    }
}
