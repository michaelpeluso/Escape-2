using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject brokenGlass;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pod"))
        {
            other.gameObject.SetActive(false);
            brokenGlass.SetActive(true);
        }
    }
}
