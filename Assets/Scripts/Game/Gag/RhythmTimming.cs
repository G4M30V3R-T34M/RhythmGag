using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

public class RhythmTimming : MonoBehaviour
{
    [Header("1st = SMILE / 2nd = PARTY / 3rd = STAR")]
    [SerializeField] GagPreferenceRuntimeSet[] CurrentGagPreferences;
    [SerializeField] FloatVariable score;
    [SerializeField] GameEvent updateScore;
    Gag currentGag;

    int counter = 0;

    private void Awake() {
        score.SetValue(0);
    }

    public void TellGag(int gagType) {
        if (currentGag != null) {
            int preferencesMultiplier = 1 + CurrentGagPreferences[gagType].Items.Count;
            float distance = Mathf.Abs(transform.position.x - currentGag.transform.position.x);
            // if distance >= 2 then Score = 0. For lower distaneces score increases to 1.
            float distanceMultiplier = -0.5f * distance + 1;
            float gagScore = 10 * preferencesMultiplier * distanceMultiplier;
            int cleanGagScore = Mathf.RoundToInt(gagScore);
            score.ApplyChange(cleanGagScore);
            updateScore.Raise();

            currentGag.gameObject.SetActive(false);
        } else {
            score.ApplyChange(-10f);
            if (score.Value < 0) {
                score.SetValue(0);
            }
            updateScore.Raise();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        currentGag = collision.gameObject.GetComponent<Gag>();
        counter++;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        counter--;
        if (counter == 0) {
            currentGag = null;
        }
    }

}
