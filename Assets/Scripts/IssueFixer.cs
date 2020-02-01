using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IssueFixer : MonoBehaviour
{
    public float rayDistance = 20f;
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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            
        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
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
