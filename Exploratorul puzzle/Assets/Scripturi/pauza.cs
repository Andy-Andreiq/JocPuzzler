using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class pauza : MonoBehaviour
{//variabile verificare, obiecte pentru meniul de pauza si loadingscreen
    //variabile pentru text si pentru slider
    public static bool pauz = false;

    public GameObject meniupauza;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //subprogram predefinit care updateaza frame cu frame
    void Update()
    {   //Conditie, daca variabila este falsa , cursorul devine blocat si invizibil
        //Daca variabila e adevarata , cursorul devine deblocat si vizibil
        if (pauz == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (pauz == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
            
        //Conditie, daca tasta escape este apasata si variabila este adevarata 
        //Se apeleaza subprogramul Resume() si cursorul devine blocat si invizibil
        //Altfel se apeleaza subprogramul Pause() si cursorul devine vizibil si deblocat
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauz == true)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false ;
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
            }
        }
    }
    //subprogram care dezactiveaza meniul de pauza , seteaza timpul la normal
    //reseteaza variabila la fals;
    public void Resume()
    {
        meniupauza.SetActive(false);
        Time.timeScale = 1f;
        pauz = false;
    }
    //subprogram care activeaza meniul de pauza , blocheaza timpul 
    //seteaza variabila adevarata
    void Pause()
    {
        meniupauza.SetActive(true);
        Time.timeScale = 0f;
        pauz = true;
    }
    //subprogram folosit la butoane , pentru trimiterea inapoi in meniu
    //acesta seteaza timpul la normal, seteaza 0 volumul AudioListeneru-lui
    //AudioListener este o componenta predefinita care percepe sunetele 
    //incepe corutina care te trimite inapoi in meniu
    //subprogramul foloseste o variabila de tip int "indexscene" prin care
    //setezi direct din butoane la ce scena vrei sa te trimita
    public void Nivele(int indexscene)
    {
        Time.timeScale = 1f;
        AudioListener.volume = 0f;
        StartCoroutine(incarca(indexscene));
    }

    //subprogram care realizeaza aceeasi actiune ca cel de sus 
    //doar ca acesta te trimite in interfata meniului
    public void QuitGame(int indexscene)
    {
        Time.timeScale = 1f;
        AudioListener.volume = 0f;
        StartCoroutine(incarca(indexscene));
    }
    //foloseste variabila indexscene pentru a putea seta din interfata butoanelor scena
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
