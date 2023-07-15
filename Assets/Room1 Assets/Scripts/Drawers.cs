using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Drawers : MonoBehaviour
{
    private Vector3 minPos;
    public Vector3 maxPos;
    public float transition;

    private bool grabPressed;

    private Vector3 offset;

    void Start()
    {
        minPos = transform.position;
        maxPos += minPos;
    }

    void Update()
    {
    }

    public void OnGrab() {
        grabPressed = true;
        StartCoroutine(Move(transform.position, maxPos, true));
    }

    public void OnDrop() {
        grabPressed = false;
        StartCoroutine(Move(transform.position, minPos, false));
    }

    public IEnumerator Move(Vector3 startPos, Vector3 endPos, bool grabButtonState) 
    {
        float time = 0;
        while (time < 1 && grabButtonState == grabPressed) {
            time += Time.deltaTime / transition;
            GetComponent<Rigidbody>().position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }
    }

}
