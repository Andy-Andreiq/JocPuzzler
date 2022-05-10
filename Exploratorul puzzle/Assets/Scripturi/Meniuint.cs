using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//nume script
public class Meniuint : MonoBehaviour
{//variabile de tip obiecte pentru butoane
    public GameObject continuarecanv;
    public GameObject canvnew;
    public GameObject start;
    private void Update()
    {//conditie, daca in save manager variabila second e adevarata(variabila care verifica daca butonul a mai fost apasat
        if (SaveManager.instance.second == true)
        {//activeaza butonul de continuare , cel de NewGame si dezactiveaza pe celalalt de NewGame
            continuarecanv.SetActive(true);
            canvnew.SetActive(true);
            start.SetActive(false);
        }
    }
    //subprogram care verifica daca e prima data cand intri in meniu
    public void firsttime()
    {
        AudioListener.volume = 0f;
        SaveManager.instance.second = true;
    }
} 
