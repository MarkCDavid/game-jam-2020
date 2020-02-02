using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class IssueSpot : MonoBehaviour
{
    public GameObject issueType;
    public int materialId;
    
    
    public Renderer planeRenderer;
    public Renderer windowRenderer;
    
    public Material nonBroken;
    public Material broken;
    
    public Material nonPooped;
    public Material pooped;
    

}
