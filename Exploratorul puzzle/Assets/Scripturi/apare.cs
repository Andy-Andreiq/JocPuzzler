using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// numele scriptului
public class apare : MonoBehaviour
{//definirea mai multor obiecte cu scopul de a le activa
    public GameObject trofeu;
    public GameObject trofeu2;
    public GameObject trofeu3;
    public GameObject trofeu4;
    public GameObject trofeu5;
    public GameObject Carte;
    public GameObject Disc;
    public GameObject Disc2;
    public GameObject mexican;
    public GameObject ciuperca;
    public GameObject tablou2;
    public GameObject tablou3;
    public GameObject tablou4;
    public GameObject tablou5;
    //verificare pentru diferite aspecte
    public bool exista = false;
    public bool e = false;
    void Update()
    {//conditii care cer ca in componenta SaveManager (un alt script)(baza de date) Sa caute conditiile
        //pentru completarea mai multor actiuni(Activarea unor noi nivele(tablouri)si aparitia trofeelor
        //cat si activarea secretelor)
        if(SaveManager.instance.lvl1 == true)
        {
            trofeu.SetActive(true);
            tablou2.SetActive(true);
        }
        if(SaveManager.instance.lvl2 == true)
        {
            trofeu2.SetActive(true);
            tablou3.SetActive(true);
            
        }
        if (SaveManager.instance.lvl3 == true)
        {
            trofeu3.SetActive(true);
            tablou4.SetActive(true);
            
        }
        if (SaveManager.instance.lvl4 == true)
        {
            trofeu4.SetActive(true);
            tablou5.SetActive(true);
            
        }
        if(SaveManager.instance.lvl5 == true)
        {
            trofeu5.SetActive(true);
        }
        if (SaveManager.instance.secret1 == true)
        {
            Carte.SetActive(true);
        }
        if (SaveManager.instance.secret3 == true)
        {
            Disc.SetActive(true);
            exista = true;
        }
        if(SaveManager.instance.secret22 == true)
        {
            mexican.SetActive(true);
        }
        if (SaveManager.instance.secret4 == true)
        {
            Disc2.SetActive(true);
            e = true;
        }
        if (SaveManager.instance.secret5 == true)
        {
            ciuperca.SetActive(true);
        }
    }
}
