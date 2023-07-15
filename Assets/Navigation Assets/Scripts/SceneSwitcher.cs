using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneNum; // the name of the scene you want to switch to


    private void Start() {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(HandleSelectEnter);
    }

    private void HandleSelectEnter(SelectEnterEventArgs args)
    {
        SceneManager.LoadScene(sceneNum);
    }

}
