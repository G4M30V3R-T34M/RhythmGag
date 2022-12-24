using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.ObjectPool;
using FeTo.SOArchitecture;

public class Gag : PoolableObject
{
    [SerializeField] FloatReference gagSpeed;
    [SerializeField] StringReference missedGagTag;

    private void Update() {
        transform.Translate(new Vector3(gagSpeed * Time.deltaTime, 0f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag(missedGagTag)) {
            gameObject.SetActive(false);
        }
    }
}
