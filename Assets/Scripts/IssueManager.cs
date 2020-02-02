using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class IssueManager : MonoBehaviour
{
    public Transform issueSpots;
    public List<int> maxIssueCounts;
    public List<float> nextIssueSpawns;
    public float levelTime = 20f;
    public int CriticalIssueCount => _issues.Count(issue => issue.isCritical);
    

    private IssueSpot[] _issueSpots;
    private List<IssueSpot> _unusedIssueSpots;
    private List<IssueSpot> _usedIssueSpots;
    
    private float _currentIssueSpawnTime = 0f;
    private List<Issue> _issues;
    private Random _prng;

    private float _gameTime;

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
        _gameTime += Time.deltaTime;

        var level = _gameTime / levelTime;
        var index = (int)Mathf.Min(level, maxIssueCounts.Count - 1);
        
        if (_usedIssueSpots.Count >= maxIssueCounts[index])
            _currentIssueSpawnTime = 0;
        
        if (_currentIssueSpawnTime > nextIssueSpawns[index])
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
        var issuego = Instantiate(spot.issueType, spot.transform.position, Quaternion.identity);
        var issue = issuego.GetComponent<Issue>();
        if (spot.materialId < 0){}
        else if (spot.materialId <= 14)
            spot.planeRenderer.materials = UpdateMaterial(spot.planeRenderer.materials, spot.broken, spot.materialId);
        else
            spot.windowRenderer.materials = UpdateMaterial(spot.windowRenderer.materials, spot.pooped, spot.materialId);
        
        issue.transform.SetParent(transform);
        issue.name = spot.name;
        issue.onFixed += (_) =>
        {
            _usedIssueSpots.Remove(spot);
            if(!_unusedIssueSpots.Contains(spot))
                _unusedIssueSpots.Add(spot);

            _issues.Remove(issue);
            
            if (spot.materialId < 0){}
            else if (spot.materialId <= 14)
                spot.planeRenderer.materials = UpdateMaterial(spot.planeRenderer.materials, spot.nonBroken, spot.materialId);
            else
                spot.windowRenderer.materials = UpdateMaterial(spot.windowRenderer.materials, spot.nonPooped, spot.materialId);
        };
        
        issue.onFixed += ScoreCalculator.AddScore;
        return issue;
    }

    private Material[] UpdateMaterial(Material[] collection, Material newMaterial, int id)
    {
        collection[id] = newMaterial;
        return collection;
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
