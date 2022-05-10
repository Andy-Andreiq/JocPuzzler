using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class inainte2 : MonoBehaviour
{//variabila , cu referinta dintr-un script exterior, si o variabila de verificare
    public trage2 dat;
    private bool stop = false;

    private void Update()
    {//conditii, daca din scriptul exterior variabila dorita e adevarata
        //si variabila de verificare este adevarata(folosita sa realizeze actiunea o singura data)
        if (dat.edat1 == true && stop == false)
        {//ea componenta animation a obiectului pe care este pus si o activeaza , pe numele respectiv
            GetComponent<Animation>().Play("inainte2");
            //variabila care realizeaza actiunea o singura data devine adevarata
            stop = true;
        }
    }
}
