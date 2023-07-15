using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehavior : MonoBehaviour
{
    private bool isFixed1 = false;
    private bool isFixed2 = false;
    private bool isFixed3 = false;
    private bool isfixed4 = false;
    private bool pipesFixed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pipesFixed = false;
      
    }

    public void PipesBroken()
    {
        
        pipesFixed = false;
        Debug.Log("Fix the Pipes");
    }
    public void PipesFixed()
    {
        isFixed1 = true;
     isFixed2 = true;
     isFixed3 = true;
    isfixed4 = true;
        Debug.Log("Pipes Fixed");
}
}
