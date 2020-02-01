using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlaneHeight : MonoBehaviour
{
    public Action onPlaneFall;
    
    public float heightTarget = 0;
    public float heightChangeSpeed = 1f;

    private float DecentSpeed => pitch.PitchCurrent * heightChangeSpeed * Time.fixedDeltaTime;

    private PlanePitch pitch;
    

    private void Awake()
    {
        pitch = GetComponent<PlanePitch>();
    }
    

    void FixedUpdate()
    {
        var trueDescentSpeed = DecentSpeed * Time.fixedDeltaTime;
        var nextYPosition = transform.position.y - trueDescentSpeed;
        nextYPosition = Mathf.Clamp(nextYPosition, float.MinValue, 100f);
        transform.position = new Vector3(transform.position.x, nextYPosition, transform.position.z);

        if (transform.position.y < heightTarget)
            SceneManager.LoadScene(3);
    }
}
