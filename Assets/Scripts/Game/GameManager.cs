using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FeTo.SOArchitecture;

public class GameManager : MonoBehaviour
{
    [SerializeField] FloatReference currentAct;
    [SerializeField] GameObject act1Finish, act2Finish, act3Finish;

    public void ActFinished() {
        switch (currentAct.Value) {
            case 0:
                act1Finish.SetActive(true);
                break;
            case 1:
                act2Finish.SetActive(true);
                break;
            case 2:
                act3Finish.SetActive(true);
                break;
        }
    }
}
