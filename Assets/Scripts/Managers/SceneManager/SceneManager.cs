using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private IEnumerator Start() { 
        yield return new WaitForSecondsRealtime(0.5f);
        OpenCurtains();
    }

    private void OpenCurtains() => animator.SetTrigger("Open");
    private void CloseCurtains() => animator.SetTrigger("Close");

    public void LoadScene(int scene) {
        CloseCurtains();
        StartCoroutine(DoLoadScene(scene));
    }

    private IEnumerator DoLoadScene(int scene) {
        yield return new WaitForSecondsRealtime(2f);
        // TODO (remove - testing purposes): Debug.Log("Loading Scene ..." + scene);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }


}
