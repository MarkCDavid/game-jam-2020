﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class IssueManager : MonoBehaviour
{
    public Transform issueSpots;
    public int maxIssueCount = 3;
    public float nextIssueSpawn = 10f;
    public int CriticalIssueCount => _issues.Count(issue => issue.isCritical);
    

    private IssueSpot[] _issueSpots;
    private List<IssueSpot> _unusedIssueSpots;
    private List<IssueSpot> _usedIssueSpots;
    
    private float _currentIssueSpawnTime = 0f;
    private List<Issue> _issues;
    private Random _prng;

    private void Awake()
    {
        _issueSpots = issueSpots.GetComponentsInChildren<IssueSpot>();
        _unusedIssueSpots = _issueSpots.ToList();
        _usedIssueSpots = new List<IssueSpot>();
        _prng = new Random();
        _issues = new List<Issue>();
    }

    void Update()
    {
        _currentIssueSpawnTime += Time.deltaTime;

        if (_usedIssueSpots.Count >= maxIssueCount)
            _currentIssueSpawnTime = 0;
        
        if (_currentIssueSpawnTime > nextIssueSpawn)
        {
            _currentIssueSpawnTime = 0;
            _issues.Add(CreateIssue());
        }
    }

    private Issue CreateIssue()
    {
        if (_unusedIssueSpots.Count == 0)
            return null;

        var spot = FetchIssueSpot();
        var issuego = Instantiate(spot.IssueType, spot.transform.position, Quaternion.identity);
        var issue = issuego.GetComponent<Issue>();
        issue.transform.SetParent(transform);
        issue.name = spot.name;
        issue.onFixed += () =>
        {
            _usedIssueSpots.Remove(spot);
            if(!_unusedIssueSpots.Contains(spot))
                _unusedIssueSpots.Add(spot);

            _issues.Remove(issue);
        };
        return issue;
    }

    private IssueSpot FetchIssueSpot()
    {
        var position = _prng.Next(0, _unusedIssueSpots.Count);
        print(position);
        var spot = _unusedIssueSpots[position];
        _unusedIssueSpots.RemoveAt(position);
        _usedIssueSpots.Add(spot);
        return spot;
    }
}
