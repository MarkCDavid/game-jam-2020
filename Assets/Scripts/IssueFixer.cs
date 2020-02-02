using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IssueFixer : MonoBehaviour
{
    public float rayDistance = 20f;

    public ParticleSystem extinguisherSmoke;
    public ParticleSystem welderFire;

    public AudioSource extinguisherSound;
    public AudioSource welderSound;
    private Camera _camera;

    private Issue _currentIssue;
    private Transform _currentIssueTransform;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        RaycastLookingAtIssue();
        FixIssues();
    }

    void FixIssues()
    {

        var lmb = Input.GetKey(KeyCode.Mouse0);
        var rmb = Input.GetKey(KeyCode.Mouse1);
        if (_currentIssue != null)
        {
            if (lmb)
                _currentIssue.Spray();

            if (rmb)
                _currentIssue.Weld();
        }

        if (lmb)
        {
            extinguisherSmoke.Emit(10);
            if(!extinguisherSound.isPlaying)
                extinguisherSound.Play();
        }
        else
        {
            extinguisherSound.Stop();
        }

        if (rmb)
        {
            welderFire.Emit(20);
            if(!welderSound.isPlaying)
                welderSound.Play();
        }
        else
        {
            welderSound.Stop();
        }

    }

    void RaycastLookingAtIssue()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, rayDistance, LayerMask.GetMask("Issue")))
        {
            if (_currentIssueTransform == hitInfo.transform) return;
            
            _currentIssueTransform = hitInfo.transform;
            _currentIssue = _currentIssueTransform.GetComponent<Issue>();
        }
        else
        {
            _currentIssueTransform = null;
            _currentIssue = null;
        }
    }
    
    
}
