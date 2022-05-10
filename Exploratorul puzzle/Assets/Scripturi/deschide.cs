using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class deschide : MonoBehaviour
{//variabila de verificare
    private bool wait = false;
    private void Update()
    {//conditii, daca apesi 'e' si asteapta e false
        if (Input.GetKeyDown("e") && wait == false)
        {//se ia componenta animation si se activeaza, cu numele animatiei
            GetComponent<Animation>().Play("Door_Open");
            //asteapta devine adevarat deoarece conditia se verifica
            wait = true;
            //se foloseste comanda de delay , pentru subprogramele "inchisa" si "ast"(2 secunde si 4 secunde)
            Invoke("inchisa", 2);
            Invoke("ast", 4);
        }
    }
    //subprogram pentru asteptare folosit sa astepte 4 secunde inainte de repetarea actiunii
    void ast()
    {
        wait = false;
    }
    //subprogram care ia componenta animation si o activeaza , cu numele potrivit, pentru a inchide usa
    void inchisa()
    {
        GetComponent<Animation>().Play("Door_Close");
    }
}
