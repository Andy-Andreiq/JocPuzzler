using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume subprogram
public class ScriptExcalibur : MonoBehaviour
{//variabile de tip obiecte (canvas,text,etc.)
    //variabile pentru verificare
    public GameObject sabie;
    private bool razwan = false;
    private bool odata = false;
    private bool apare = false;
    public GameObject cufar;
    public GameObject text;
    public GameObject audem;

    void Update()
    {//conditii, daca este apasata tasta 'e' si exista coliziune  
        //si variabila odata , folosita pentru repetarea actiunii o singura data e falsa
        if (Input.GetKey("e") && razwan == true && odata == false)
        {//in obiectul sabie se acceseaza componenta animatie , si se activeaza
            sabie.GetComponent<Animation>().Play("anim");
            //variabila devine adevarata pentru a stopa repetarea
            odata = true;
            //Componenta AudioManager activeaza sunetul cu numele respectiv
            audem.GetComponent<AudioManager>().Play("Boom");
            //variabila apare devuine adevarata
            apare = true;
            //textul se activeaza , si din componente se activeaza animatia
            text.SetActive(true);
            text.GetComponent<Animation>().Play("Stefanelenes");
            //comanda de delay pentru subprogramul respectiv
            Invoke("mana", 3);
        }
        //conditie care face cufarul sa apara
        if(apare == true)
        {
            cufar.SetActive(true);
          
        }
        
    }      
    //subprogram care dezactiveaza textul
    void mana()
    {
        text.SetActive(false);
    }
                                  //subprogram care verifica coliziunea    
    private void OnTriggerEnter(Collider other)
    {                   
        razwan = true;
    }
    private void OnTriggerExit(Collider other)
    {
        razwan = false;
    }

   
}
