using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class IntGameEventListener : MonoBehaviour
{
    [SerializeField] IntGameEvent gameEvent;

    [SerializeField] IntEvent response;

    protected void OnEnable() {
        gameEvent.RegisterListener(this);
    }

    protected void OnDisable() {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(int value) {
        response.Invoke(value);
    }
}
