using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLightar : MonoBehaviour
{
    public GameObject player;
    Light Inten;
    bool OnOff;

    
    // Start is called before the first frame update
    void Start()
    {

        Inten = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        OnOff = player.GetComponent<Player>().On;
        if(OnOff == false)
        {
            Inten.intensity = 1;
        }
        else if(OnOff == true)
        {
            Inten.intensity = 0;
           
        }

    }
}
