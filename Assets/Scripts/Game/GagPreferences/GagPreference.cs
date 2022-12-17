using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GagPreference : MonoBehaviour
{
    [Header("1st = SMILE / 2nd = PARTY / 3rd = STAR")]
    [SerializeField] GagPreferenceRuntimeSet[] RuntimeSets;
    [SerializeField] GagPreference_SO[] gagPrecerences; 
    [SerializeField] SpriteRenderer spriteRenderer;

    GagPreferenceType currentType;

    int counter;

    private void Start() {
        SetRandomType();
    }

    private void SetType(GagPreferenceType type) {
        RuntimeSets[(int)currentType].Remove(this);
        currentType = type;
        RuntimeSets[(int)currentType].Add(this);
        spriteRenderer.sprite = gagPrecerences[(int)currentType].sprite;
        spriteRenderer.color = gagPrecerences[(int)currentType].color;
    }

    public void CheckPreferenceDecrement(int type) {
        if ((GagPreferenceType)type == currentType) {
            counter--;
            if (counter == 0) {
                SetRandomType();
            }
        }
    }

    private void SetRandomType() {
        SetType((GagPreferenceType)Random.Range(0, 3));
        counter = Random.Range(1, 4);
    }
}
