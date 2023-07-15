using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour

{
    public GameObject prop;
    private Rigidbody rb;

    public float myValue = -1; // the total
    public float addPerSecond;// add this every second
    // Start is called before the first frame update
    
    void Start() {


        
    rb = prop.GetComponent<Rigidbody>();
}
  
    // Update is called once per frame
    void Update()

    {
        prop.GetComponent<Rigidbody>().useGravity = false;
        //float at a constant rate
        myValue += addPerSecond;
      
    
        if (prop.GetComponent< Rigidbody>().useGravity == false)
        {
            if (myValue >= 0.005)
            {
                myValue = (float)0.0001;
               
            }
            rb.AddForce(new Vector3(0, (myValue), 0));
            
        }
        


    }
}
