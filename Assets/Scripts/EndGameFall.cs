using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameFall : MonoBehaviour
{

    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"Score: {ScoreCalculator.CurrentScore}";
    }

}
