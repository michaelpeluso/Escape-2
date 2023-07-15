using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FlaskManager : MonoBehaviour
{
    public string ChemFormula;
    public string ChemName;
    public Color color;

    public XRGrabInteractable interactable;

    private GameObject parentObject;
    private GameObject nameObject;
    private GameObject formulaObject;

    private TextMeshPro chemName;
    private TextMeshPro chemFormula;

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
        
        formulaObject= new GameObject();
        formulaObject.transform.localScale = Vector3.one * 0.01f;
        formulaObject.transform.parent = parentObject.transform;
        chemFormula = formulaObject.AddComponent<TextMeshPro>();
        chemFormula.text = ChemFormula;
        chemFormula.fontSize = 36;
        chemFormula.alignment = TextAlignmentOptions.Center;


        nameObject = new GameObject();
        nameObject.transform.localScale = Vector3.one * 0.01f;
        nameObject.transform.parent = parentObject.transform;
        chemName = nameObject.AddComponent<TextMeshPro>();
        chemName.text = "\n\n\n" + ChemName;
        chemName.fontSize = 18;
        chemName.alignment = TextAlignmentOptions.Center;
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
