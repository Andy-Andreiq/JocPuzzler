using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume subprogram
public class NewGame : MonoBehaviour
{//variabile de obiecte pentru loadingscreen,de text si de slider
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //subprogram care reseteaza baza de date in totalitate si care activeaza corutina
    public void New(int indexscene)
    {
        SaveManager.instance.lvl1 = false;
        SaveManager.instance.lvl5 = false;
        SaveManager.instance.lvl4 = false;
        SaveManager.instance.lvl3 = false;
        SaveManager.instance.lvl2 = false;
        SaveManager.instance.tut = false;
        SaveManager.instance.secret5 = false;
        SaveManager.instance.secret4 = false;
        SaveManager.instance.secret3 = false;
        SaveManager.instance.secret22 = false;
        SaveManager.instance.secret1 = false;
        SaveManager.instance.placa1 = false;
        SaveManager.instance.placa2 = false;
        SaveManager.instance.placa3 = false;
        SaveManager.instance.placa4 = false;
        SaveManager.instance.placa5 = false;
        SaveManager.instance.aparut = false;
        SaveManager.instance.Save();

        AudioListener.volume = 0f;
        StartCoroutine(incarca(indexscene));
    }
    //subprogramul foloseste indexscene deoarece se poate seta direct de pe buton Scena unde vrei sa fii trimis
    IEnumerator incarca(int indexscene)
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(indexscene);
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
