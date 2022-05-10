using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class boostsaritura : MonoBehaviour
{//variabile care fac referinta la niste scripturi din alte obiecte
    public trage dat;
    public trage2 da;
    public trage3 d;

    private void Update()
    {//conditie ca variabilele din scripturile respective sa fie adevarate
        if(dat.edat == true && da.edat1 == true && d.edat2 == true)
        {
            //cauta componenta in scriptul Miscare , si seteaza saritura la putere 10
            GetComponent<Miscare>().saritura = 10f;
        }
    }
}
