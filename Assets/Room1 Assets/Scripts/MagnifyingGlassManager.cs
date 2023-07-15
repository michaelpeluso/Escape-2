using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagnifyingGlassManager : MonoBehaviour
{
    public GameObject[] images;
    public GameObject[] dishes;
    public Material[] compounds;
    
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        foreach (GameObject dish in dishes) {
            if (other.gameObject == dish) {
                ShowImage(dish);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        foreach (GameObject dish in dishes) {
            if (other.gameObject == dish) {
                HideImage(dish);
            }
        }
    }

    void ShowImage(GameObject comp) 
    {
        int i = Array.IndexOf(dishes, comp);
        foreach (GameObject image in images) {
            image.SetActive(true);
            image.GetComponent<MeshRenderer>().material = compounds[i];
        }
    }

    void HideImage(GameObject comp) 
    {
        int i = Array.IndexOf(dishes, comp);
        foreach (GameObject image in images) {
            image.SetActive(false);
        }
    }
}
