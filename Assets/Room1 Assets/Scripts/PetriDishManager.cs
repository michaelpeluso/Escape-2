using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class PetriDishManager : MonoBehaviour
{   
    public string dishNumber;

    public XRGrabInteractable interactable;

    private GameObject parentObject;
    private GameObject dishObject;
    private GameObject dishNumberObject;

    private TextMeshPro numText;
    private TextMeshPro dishText;

    void Start() 
    {
        interactable = GetComponent<XRGrabInteractable>();
        CreateTextObject();

        interactable.hoverEntered.AddListener(HandleHoverEnter);
        interactable.hoverExited.AddListener(HandleHoverEnter);
    }

    private void Update() 
    {
        if (parentObject.activeSelf) {
            parentObject.transform.LookAt(Camera.main.transform);
            parentObject.transform.Rotate(0f, 180f, 0f, Space.Self);
            parentObject.transform.position = transform.position - Vector3.Normalize(transform.position - Camera.main.transform.position) * 0.1f;
        }
    }

    public void CreateTextObject()
    {
        parentObject = new GameObject();
        parentObject.transform.parent = transform;
        parentObject.name = "text";
        parentObject.SetActive(false);
        
        dishNumberObject= new GameObject();
        dishNumberObject.transform.localScale = Vector3.one * 0.01f;
        dishNumberObject.transform.parent = parentObject.transform;
        numText = dishNumberObject.AddComponent<TextMeshPro>();
        numText.text = dishNumber;
        numText.fontSize = 36;
        numText.alignment = TextAlignmentOptions.Center;


        dishObject = new GameObject();
        dishObject.transform.localScale = Vector3.one * 0.01f;
        dishObject.transform.parent = parentObject.transform;
        dishText = dishObject.AddComponent<TextMeshPro>();
        dishText.text = "\n\n\n" + "Petri Dish";
        dishText.fontSize = 18;
        dishText.alignment = TextAlignmentOptions.Center;
    }

    private void HandleHoverEnter(HoverEnterEventArgs args)
    {
        parentObject.SetActive(true);
    }

    private void HandleHoverEnter(HoverExitEventArgs args)
    {
        parentObject.SetActive(false);
    }
}
