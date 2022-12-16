using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(int scene) {
        // TODO (remove - testing purposes): Debug.Log("Loading Scene ..." + scene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
