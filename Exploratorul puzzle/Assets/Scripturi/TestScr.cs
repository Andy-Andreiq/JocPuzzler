using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class TestScr : MonoBehaviour
{
   //referinta la un script extern,variabile de tip obiect si pentru verificare
    public GameObject munte;
    public DamageScript bs;
    public bool gigel = false;
    public Damage2 cl;
    public Damage3 nt;
   

   
    void Update()
    {//conditii, daca in scriptul extern distrus e adevarat si variabila gigel este false
        //gigel este folosit pentru repetarea programului o singura data
        if (bs.distrus == true && gigel == false )
        {  //gigel devine adevarat pentru a impiedica repetitia
            gigel = true;
            //se ia componenta de tip animation a muntelui si se activeaza
            munte.GetComponent<Animation>().Play("AnimMunte");
            //se cauta si se porneste sunetul , prin AudioManager
            FindObjectOfType<AudioManager>().Play("mountainsound");
        }


    }
}
