using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchar : MonoBehaviour
{
    public Light Light1;
    public Light Light2;
    public Light Light3;
    bool On;
    

    void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.tag == "Switch" && On)
            {
                Light1.intensity = 0;
                Light2.intensity = 0;
                Light3.intensity = 0;
            }
            else
            {
                Light1.intensity = 1;
                Light2.intensity = 1;
                Light3.intensity = 1;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }
}
