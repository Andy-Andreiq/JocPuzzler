using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class MeniuS : MonoBehaviour
{//variabile pentru verificare si de tip obiecte
    public GameObject canvas;
    public GameObject txt;
    private bool afost = false;
    //subprogram separat folosit ulterior
    void arata()
    {//Conditii, daca in SaveManager aparut e false (aparut fiin o variabila care inregistreaza daca textul a mai fost afisat)
        //si a fost care reprezinta o variabila ce realizeaza actiunea o data
        if (SaveManager.instance.aparut == false && afost == false)
        {//obiectul de tip canvas devine activ
            canvas.SetActive(true);
            //se activeaza componenta animatie de la obiectul text
            txt.GetComponent<Animation>().Play("textmeniu");
            //SaveManagerul inregistreaza variabila aparut in baza de date
            //Acest text nu va mai fii afisat
            SaveManager.instance.aparut = true;
            SaveManager.instance.Save();
            //variabila devine adevarata pentru a nu reincepe procesu
            afost = true;

        }
    }
    //subprogram predefinit de unity pentru Updatarea frame cu frame
    private void Update()
    {//comanda de delay este apelata pe subprogramele cu numele respective pe durata de (2 secunde si 4.8 secunde)
        Invoke("arata", 2);
        Invoke("pa", 4.8f);
    }
    //subprogram care inchide canvasul
    void pa()
    {
        canvas.SetActive(false);
    }
}
