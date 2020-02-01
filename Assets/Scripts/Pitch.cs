using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : MonoBehaviour
{
    public float PitchCurrent = 0;
    public float PitchTarget = 0;
    public float PitchSpeed = 0.05f;
    public Vector3 TargetPosition;


    void PitchChange(float PitchNew)
    {
        PitchTarget= PitchNew;
    }
    void Update()
    {
        TargetPosition = transform.position;
        if (PitchTarget < PitchCurrent)
        {
            PitchCurrent -= PitchSpeed;           
        }
        else if (PitchTarget > PitchCurrent)
        {
            PitchCurrent += PitchSpeed;
        }
        transform.rotation = Quaternion.Euler(PitchCurrent,0.0f ,0.0f);

    }

}
