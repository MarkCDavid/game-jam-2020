using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlanePitch : MonoBehaviour
{
    public float pitchSpeed = 0.05f;
    public float issuePitchChange = 3f;

    public float RollCurrent = 0f;
    public float RollTarget = 0f;
    public float RollSpeed = 0.05f;    

    [NonSerialized]
    public float PitchCurrent = 0;

    private IssueManager _im;
    private float _pitchTarget = 0;

    private int Side = 0;
    private System.Random random = new System.Random();

    private Rigidbody _rb;

    private void Awake()
    {
        _im = GetComponentInChildren<IssueManager>();
    }

    void FixedUpdate()
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
            PitchCurrent -= pitchSpeed * Time.fixedDeltaTime;           
        }
        else if (_pitchTarget > PitchCurrent)
        {
            PitchCurrent += pitchSpeed * Time.fixedDeltaTime;
        }

        if (Mathf.Abs(RollCurrent - RollTarget) < 0.05)
        {
            Side = random.Next(-15, 15);
            RollTarget = Side;
        }
        if (RollTarget < RollCurrent)
        {
            RollCurrent -= RollSpeed * Time.fixedDeltaTime;
        }
        else if (RollTarget > RollCurrent)
        {
            RollCurrent += RollSpeed * Time.fixedDeltaTime;
        }
        transform.rotation = Quaternion.Euler(PitchCurrent, transform.rotation.y, RollCurrent);
    }

}
