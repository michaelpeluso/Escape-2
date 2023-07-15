using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public Timer count = new Timer();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            Destroy(gameObject);
            count.IncreaseTime();
            Debug.Log("collision");
        }
    }
}