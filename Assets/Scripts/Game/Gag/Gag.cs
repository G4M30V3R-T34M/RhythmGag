using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.ObjectPool;
using FeTo.SOArchitecture;

public class Gag : PoolableObject
{
    [SerializeField] FloatReference gagSpeed;
    [SerializeField] StringReference missedGagTag;
    [SerializeField] FloatVariable score;
    [SerializeField] GameEvent updateScore;

    private void Update() {
        transform.Translate(new Vector3(gagSpeed * Time.deltaTime, 0f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(missedGagTag)) {
            score.ApplyChange(-10);
            if (score.Value < 0) { score.SetValue(0); }
            updateScore.Raise();

            gameObject.SetActive(false);
        }
    }
}
