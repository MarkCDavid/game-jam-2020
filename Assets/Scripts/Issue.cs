using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Issue : MonoBehaviour
{
    public Action OnFixed;
    public Action OnCritical;
    
    public float CriticalTime;

    private bool _isCritical = false;
    private float _currentLifeTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentLifeTime += Time.deltaTime;
        if (!_isCritical && _currentLifeTime > CriticalTime)
        {
            _isCritical = true;
            OnCritical?.Invoke();
        }
    }


    private void Weld()
    {
        
    }

    private void Spray()
    {
        
    }
}
