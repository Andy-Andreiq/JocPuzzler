using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume subprogram
public class Cartedeschisa : MonoBehaviour
{//variabile pentru verificare si definirea a 2 obiecte pentru canvas si pentru meniu pauza
    private bool ein = false;
    public GameObject Poveste;
    private bool eactiva = false;
    public GameObject pauza;
    //verificare daca playerul se afla in collider
    private void OnTriggerEnter(Collider other)
    {
        ein = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ein = false;
    }
    
    private void Update()
    {//conditie daca apesi e si esti in collider
        if(Input.GetKeyDown("e") && ein == true )
        {//activeaza canvasul (element UI)
            Poveste.SetActive(true);
            //Opreste toate sunetele posibile
            FindObjectOfType<AudioManager>().Stop("Meniu");
            FindObjectOfType<AudioManager>().Stop("doom");
            FindObjectOfType<AudioManager>().Stop("ultimate");
            //Porneste sunetele "horor" si "voice"
            FindObjectOfType<AudioManager>().Play("horor");
            FindObjectOfType<AudioManager>().Play("voice");
            //dezactiveaza meniul de pauza
            pauza.SetActive(false);
            //daca conditia se aplica variabila devine adevarata
            eactiva = true;
}//conditie daca apesi "ESC" si variabila eactiva (care verifica conditia de mai sus) e adevarata
        if (Input.GetKeyDown(KeyCode.Escape) && eactiva == true)
        {//dezactiveaza canvasul
            Poveste.SetActive(false);
            //activeaza meniul de pauza
            pauza.SetActive(true);
            //porneste muzica de meniu si opreste sunetele folosite
            FindObjectOfType<AudioManager>().Play("Meniu");
            FindObjectOfType<AudioManager>().Stop("horor");
            FindObjectOfType<AudioManager>().Stop("voice");
            //variabila devine falsa pentru a putea repeta procesul
            eactiva = false;
        }


    }
}
