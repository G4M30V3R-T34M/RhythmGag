using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GagTypeButton : BaseMenuOption
{
    [SerializeField] Image gagIconImage, arrowIconImage;
    [SerializeField] IntGameEvent gameEvent;
    [SerializeField] GagPreference_SO gagPreference;

    [SerializeField] Button button;

    private void Start() {
        gagIconImage.sprite = gagPreference.sprite;
        gagIconImage.color = gagPreference.color;
        arrowIconImage.sprite = gagPreference.arrowSprite;
        arrowIconImage.color = gagPreference.color;
    }

    public void InvokeOnClick(InputAction.CallbackContext context) {
        if (button.interactable) {
            if (context.started) {
                StartCoroutine(FadeToColor());
                button.onClick.Invoke();
            }
        }
    }

    private IEnumerator FadeToColor() {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(button.colors.pressedColor, button.colors.fadeDuration, true, true);
        yield return new WaitForSeconds(button.colors.fadeDuration);
        graphic.CrossFadeColor(button.colors.normalColor, button.colors.fadeDuration, true, true);
    }

    public override void MenuOptionAction() {
        gameEvent.Raise((int)gagPreference.type);
    }
}
