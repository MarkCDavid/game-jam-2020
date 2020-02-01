using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlanePitch : MonoBehaviour
{
    public float pitchSpeed = 0.05f;
    public float issuePitchChange = 3f;
    
    [NonSerialized]
    public float PitchCurrent = 0;

    private IssueManager _im;
    private float _pitchTarget = 0;

    private Rigidbody _rb;

    private void Awake()
    {
        _im = GetComponentInChildren<IssueManager>();
    }

    void Update()
    {
        var criticalIssueCount = _im.CriticalIssueCount;
        _pitchTarget = criticalIssueCount * issuePitchChange;
        if (criticalIssueCount == 0)
        {
            if (transform.position.y < 99.95f)
                _pitchTarget = -15;
        }
        _pitchTarget = Mathf.Clamp(_pitchTarget, -15, 30);
        
        if (_pitchTarget < PitchCurrent)
        {
            PitchCurrent -= pitchSpeed * Time.deltaTime;           
        }
        else if (_pitchTarget > PitchCurrent)
        {
            PitchCurrent += pitchSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(PitchCurrent,0.0f ,0.0f);

    }

}
