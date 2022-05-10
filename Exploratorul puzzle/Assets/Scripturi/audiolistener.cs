using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class audiolistener : MonoBehaviour
{ //variabila care activeaza optiunea doar o singura data
    private bool odata = false;

    void Update()
    {//conditie pentru activare , actiunea sa nu fi avut loc deja in scena
        if (odata == false)
        {
            //variabila predefinita care seteaza volumul audiolistenerului(un obiect predefinit)
            //care inregistreaza sunetul la 1 (adica volumul maxim)
            AudioListener.volume = 1f;
            //variabila devine adevarata pentru a nu se repeta actiunea
            odata = true;
        }
    }
}
