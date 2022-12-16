using UnityEngine;

public class ChangeSceneMenuOption : BaseMenuOption
{
    [SerializeField] IntGameEvent buttonEvent;
    [SerializeField] SCENE nextScene;

    public override void MenuOptionAction() {
        buttonEvent.Raise(((int)nextScene));
    }
}
