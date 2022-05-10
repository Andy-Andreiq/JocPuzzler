using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class canta : MonoBehaviour
{//variabile pentru verificare si care fac referinta la un alt script
    public bool insite = false;
    //variabila folosita pentru a astepra pana sa poti din nou sa il asculti
    private bool asteapta = true;
    public apare da;
    //Subprograme care verifica daca Colliderul de pe obiect este atins de ceva
    private void OnTriggerEnter(Collider other)
    {
        insite = true;
    }
    private void OnTriggerExit(Collider other)
    {
        insite = false;
    }
    //Updatare scena 
    void Update()
    {//conditie daca se apasa 'e', te afli in colliderul obiectului,daca variabila asteapta este adevarata
        //si daca in scriptul apare , exista este adevarata
        if (Input.GetKeyDown("e") && insite == true && asteapta ==true && da.exista == true)
        {//variabila devine falsa
            asteapta = false;
            //opreste orice sunet posibil cautand obiectul AudioManger si Folosind comanda Stop
            FindObjectOfType<AudioManager>().Stop("Meniu");
            FindObjectOfType<AudioManager>().Stop("doom");
            //Cauta obiectu AudioManager si porneste sunetul cu numele respectiv
            FindObjectOfType<AudioManager>().Play("ultimate");
            //comanda pentru delay , pentru subprogramele iar si wait(150 de secunde)
            Invoke("iar", 150);
        }
    }
    //subprogram care activeaza din nou muzica de meniu si activeaza variabila asteapta
    void iar()
    {
        FindObjectOfType<AudioManager>().Play("Meniu");
        asteapta = true;
    }


}
