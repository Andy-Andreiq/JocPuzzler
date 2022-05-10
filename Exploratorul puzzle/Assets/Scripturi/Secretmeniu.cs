using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Secretmeniu : MonoBehaviour
{//variabila de tim obiect si pentru verificare
    public GameObject men;
    private bool odata = false;
    void Update()
    {//verificare conditii, daca obiectul pe care este scriptul este activ si daca actiunea s-a intamplat odata
        if (gameObject.activeSelf == true && odata == false)
        {
            //se opreste muzica meniului principal si se porneste cea a celui secret
            men.GetComponent<AudioManager>().Stop("Meniustart");
            men.GetComponent<AudioManager>().Play("ricardo");
            odata = true;
        }
        
    }
        
}
