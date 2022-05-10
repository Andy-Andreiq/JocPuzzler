using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
//nume script
public class loading : MonoBehaviour
{//nume variabile de tip obiecte (loadingscreen),text si slider
    public GameObject loadingscreen;
    public Slider loadin;
    public Text pro;
    //subprogram folosit prin butoan pentru intrarea in nivele
public void Loading()
    {
        //incepe corutina si seteaza volumul audiolistenerului la 0;
        StartCoroutine(incarca());
        AudioListener.volume = 0f;
    }
        IEnumerator incarca()
    {
        if (SaveManager.instance.tut == true)
        {
            //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
            //incarca actionand pe fundal
            //operatiune folosita pentru schimbarea de scene 
            //fiind setata la indexul din Built 
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);
            //activeaza variabila de loading screen(canvas)
            loadingscreen.SetActive(true);
            //cat timp operatiunea nu este terminata 
            while (operatiune.isDone == false)
            {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
             //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
                //sliderul ia valoarea progresului, schimbandu-se in functie de el
                loadin.value = progres;
                //textul realizeaza un calcul matematic , care rotunjeste progresul
                //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
                //Transforma variabila in data de tip String si adauga semnul"%"
                pro.text = Mathf.Round(progres * 100f).ToString() + "%";

                //returneaza argumentul null
                yield return null;

            }
        }
        if (SaveManager.instance.tut == false)
        {
            //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
            //incarca actionand pe fundal
            //operatiune folosita pentru schimbarea de scene 
            //fiind setata la indexul din Built 
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(7);
            //activeaza variabila de loading screen(canvas)
            loadingscreen.SetActive(true);
            //cat timp operatiunea nu este terminata 
            while (operatiune.isDone == false)
            {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
             //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
                //sliderul ia valoarea progresului, schimbandu-se in functie de el
                loadin.value = progres;
                //textul realizeaza un calcul matematic , care rotunjeste progresul
                //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
                //Transforma variabila in data de tip String si adauga semnul"%"
                pro.text = Mathf.Round(progres * 100f).ToString() + "%";

                //returneaza argumentul null
                yield return null;

            }
        }
    }
        
}
