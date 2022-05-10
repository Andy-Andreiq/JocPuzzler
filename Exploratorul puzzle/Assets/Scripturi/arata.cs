using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//numele scriptului
public class arata : MonoBehaviour
{//definirea unor obiecte (canvas si text) si variabilei aparut
    public GameObject pp;
    public GameObject txt;
    private bool aparut = false;
    //subprogram care activeaza canvasul si da Play la componenta animation de pe obiectul text
    void mana()
    {
        pp.SetActive(true);
        txt.GetComponent<Animation>().Play("chei");
    }
    //Udateaza scena continuu
    private void Update()
    {//conditie , daca variabila aparut este false sa realizeze actiunea 
        //"aparut"este folosita pentru realizarea actiunii doar o data
        if (aparut == false)
        {// foloseste comanda predefinita de delay pe subprogramele "mana" si "inchide"
            //avand delay de 2 secunde si 5 secunde
            Invoke("mana", 2);
            Invoke("inchide", 5);
            //variabila "aparut" devine adevarata , deoarece actiunea s-a realizat deja
            aparut = true;
        }
    }
    //subprogram pentru dezactivarea canvasului
    void inchide()
    {
        pp.SetActive(false);
    }
}
