using System.Collections;
using UnityEngine;
using FeTo.SOArchitecture;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] GameEvent endAct;
    [SerializeField] TextMeshProUGUI timer;
    float remainingTime;

    public void StartAct() {
        remainingTime = 30f;
        StartCoroutine(ActTimer());
    }

    private IEnumerator ActTimer() { 
        while (remainingTime >= 0) {
            yield return null;
            remainingTime -= Time.deltaTime;
            timer.text = string.Format("00:{0:D2}", (int)remainingTime);
        }
        remainingTime = 0f;
        endAct.Raise();
    }
}
