using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GagTypeButton : BaseMenuOption
{
    [SerializeField] Image gagIconImage, arrowIconImage;
    [SerializeField] IntGameEvent gameEvent;
    [SerializeField] GagPreference_SO gagPreference;

    private void Start() {
        gagIconImage.sprite = gagPreference.sprite;
        gagIconImage.color = gagPreference.color;
        arrowIconImage.sprite = gagPreference.arrowSprite;
        arrowIconImage.color = gagPreference.color;
    }

    public override void MenuOptionAction() {
        gameEvent.Raise((int)gagPreference.type);
    }
}
