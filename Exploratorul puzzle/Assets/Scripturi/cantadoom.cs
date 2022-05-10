using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class cantadoom : MonoBehaviour
{//variabile pentru verificare , si alta care face referinta la un alt script
    private bool insite = false;
    public apare ba;
    private bool canta = true;
    //subprogram predefinit care inregistreaza intrarea in Collider
    private void OnTriggerEnter(Collider other)
    {
        insite = true;
    }
    private void OnTriggerExit(Collider other)
    {
        insite = false;
    }
    void Update()
    {//Conditie pentru activare ( apasa'e', te afli in collider)
        //variabila 'canta'care asteapta pana se termina si variabila 'e' din scriptul 'apare' adevarata
        if (Input.GetKeyDown("e") && insite == true && canta == true && ba.e == true)
        {//variabila canta devine falsa , pentru ca deja o face
            canta = false;
            //opreste toate sunetele posibile din Audiomanager
            FindObjectOfType<AudioManager>().Stop("Meniu");
            FindObjectOfType<AudioManager>().Stop("ultimate");
            //Porneste muzica cu numele respectiv
            FindObjectOfType<AudioManager>().Play("doom");
            //foloseste comanda de delay pentru subprogramu respectiv pe durata de (480 de secunde)
            Invoke("iar", 130);
        }
    }
    //subprogram care activeaza muzica din meniu , si variabila pentru a putea fi refolosita muzica
    void iar()
    {
        FindObjectOfType<AudioManager>().Play("Meniu");
        canta = true;
    }
    
}
