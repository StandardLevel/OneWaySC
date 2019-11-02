using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxyCrushJMar : MonoBehaviour
{
    public bool Crush = false;
     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DoorGhost")
        {
            Crush = true;
        }
            
    }
     void OnTriggerExit(Collider other)
    {
        if (other.tag == "DoorGhost")
        {
            Crush = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
