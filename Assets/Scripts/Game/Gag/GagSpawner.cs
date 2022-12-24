using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;
using FeTo.ObjectPool;

public class GagSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool gagPool;
    [SerializeField] ActSongs actSongs;
    [SerializeField] FloatReference currentAct;
    [SerializeField] FloatVariable gagSpeed;
    [SerializeField] FloatReference gagSpeedMultiplier;
    [SerializeField] FloatReference gagDistanceMultiplier;

    Coroutine spawnCoroutine;
    float spawnSpeed = 0f;

    public void StartSpawn() {
        float songBpm = actSongs.songs[(int)currentAct].bpm;
        spawnSpeed = 1 / (songBpm/60);
        gagSpeed.SetValue(spawnSpeed * gagSpeedMultiplier * gagDistanceMultiplier);
        spawnCoroutine = StartCoroutine(SpawnGags());
    }

    public void StopSpawn() {
        StopCoroutine(spawnCoroutine);
    }

    private IEnumerator SpawnGags() {
        while (true) {
            SpawnGag();
            yield return new WaitForSeconds(spawnSpeed * 2);
        }
    }

    private void SpawnGag() {
        Gag gag = (Gag)gagPool.GetNext();
        gag.transform.position = transform.position;
        gag.gameObject.SetActive(true);
    }
}
