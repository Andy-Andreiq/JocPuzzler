using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trece : MonoBehaviour
{//variabila de tip obiect si pentru verificare
    private bool odata = false;
    public GameObject chest;
    //metoda care verifica colide-ul cu un al collider
    private void OnTriggerEnter(Collider other)
    {//daca actiunea nu s-a realizat
        if (odata == false)
        {//se gaseste componenta de tip Animation a chestului si se activeaza
            chest.GetComponent<Animation>().Play("chest apare");
            //variabila devine adevarata pentru a prevenii  reinceperii metodei
            odata = true;
        }
        
    }
}
