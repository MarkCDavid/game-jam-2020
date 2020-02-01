﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public bool IsGrounded = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform != transform.parent)
            IsGrounded = true;
    }
}
