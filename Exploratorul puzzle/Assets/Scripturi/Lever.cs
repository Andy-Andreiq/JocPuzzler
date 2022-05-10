using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Lever : MonoBehaviour
{ //referinta la script extern ,adaugare obiectelor(canvas,text,levere)
    //folosirea variabilelor pentru verificare
    public cade da;
    public GameObject Lever1;
    public bool l1 = false;
    public GameObject Lever2;
    public bool l2 = false;
    public GameObject Lever3;
    public bool l3 = false;
    public GameObject can;
    public GameObject txt;
    void Update()
    {//conditii, daca se apasa 'z' si daca referinta din scriptul extern e adevarata
        if (Input.GetKeyDown("z") && da.meteorit == true)
        {//folosirea comenzii de delay pentru subprograme
            Invoke("lvr1", 1);
            Invoke("lvr2", 3);
            Invoke("lvr3", 5);
            //activarea canvasului(element UI)
            can.SetActive(true);
            //activarea componentei animation , care activeaza animatia cu numele respectiv
            txt.GetComponent<Animation>().Play("anim");
            //folosirea comenzii de delay pentru subprogram
            Invoke("dispare", 3);
        }
    }
    //subrogram care activeaza leverul 1 si  ii seteaza variabila de verificare adevarata
    void lvr1()
    {
        Lever1.SetActive(true);
        l1 = true;
    }
    //subrogram care activeaza leverul 2 si ii seteaza variabila de verificare adevarata
    void lvr2()
    {
        Lever2.SetActive(true);
        l2 = true;
    }
    //subrogram care activeaza leverul 3 si ii seteaza variabila de verificare adevarata
    void lvr3()
    {
        Lever3.SetActive(true);
        l3 = true;
    }
    //subprogram dezactivare canvas
 void dispare()
    {
        can.SetActive(false);
    }
        
}
