using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public enum IssueType
{
    Welder, Extinguisher
}

public class Issue : MonoBehaviour
{
    public Action<int> onFixed;
    public Action onCritical;
    
    public float fixSpeed;

    public IssueType issueType;
    public float criticalTime;

    public int issueScore;

    public bool isCritical = false;
    private float _currentLifeTime = 0f;
    


    void Update()
    {
        DoBreak();
    }

    void DoBreak()
    {
        if (!isCritical)
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > criticalTime)
            {
                isCritical = true;
                onCritical?.Invoke();
            }
        }

       
    }


    public void Weld()
    {
        if (issueType == IssueType.Welder)
            Fix();
    }

    public void Spray()
    {
        if (issueType == IssueType.Extinguisher)
            Fix();
    }

    private void Fix()
    {
        _currentLifeTime -= Time.deltaTime * fixSpeed;
        if (_currentLifeTime <= 0)
        {
            onFixed?.Invoke(issueScore);
            Destroy(gameObject);
        }
    }
}
