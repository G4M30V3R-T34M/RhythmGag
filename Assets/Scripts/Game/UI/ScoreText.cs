using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FeTo.SOArchitecture;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] FloatReference score;

    public void UpdateScore() {
        scoreText.text = string.Format("{0:D5}", (int)score);
    }
}
