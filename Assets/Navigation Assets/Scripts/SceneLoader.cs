using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    private int sceneIndex;

    public void LoadNextScene(int num) {
        SceneManager.LoadScene(sceneIndex);
    }
        /*Debug.Log("LoadNextScene running...");
        animator.SetTrigger("LoadScene");
        sceneIndex = num;
    }

    public void OnFadeComplete() {
        Debug.Log("Change scene");
        SceneManager.LoadScene(sceneIndex);
    }*/
}
