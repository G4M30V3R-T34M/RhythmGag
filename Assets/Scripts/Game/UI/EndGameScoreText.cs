using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FeTo.SOArchitecture;

public class EndGameScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] FloatReference score;

    private void OnEnable() {
        scoreText.text = string.Format("{0:D5}", (int)score);
    }
}
