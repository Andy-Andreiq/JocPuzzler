using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//nume script
public class Setari : MonoBehaviour
{//comanda predefinita , creaza o variabila
    public AudioMixer audiomixer;
    //Camp Care acceseaza rezolutiile suportate de unity
    Resolution[] resolutions;
    //variabila de tip dropdown
    public Dropdown rezolutie;
    //metoda care se activeaza la start inaintea oricarei metode Update
    void Start()
    {//variabila ia marimea ecranului, si curata toate rezolutiile adaugate in text
        resolutions = Screen.resolutions;

        rezolutie.ClearOptions();
        //creaza o lista noua de stringuri
        List<string> optiuni = new List<string>();
        //creaza o variabila care inregistreaza rezolutia ecranului (intai incepe cu val 0)
        int rezolutiestart = 0;
        //Pentru fiecare valoare incepand cu 0 si ajungand la lungimea numarului de rezolutii , valoarea creste
        for ( int i = 0;i <  resolutions.Length; i++)
        {
            //creeaza o variabila de tip string , care ia masura fiecarei rezolutii gasite (Lungime , Inaltime si refreshrate-ul)
            string optiune = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            //Si le adauga ca optiuni  posibile
            optiuni.Add(optiune);
            //functii predefinite de la unity, compararea directa nu merge scrisa direct, fiind necesara scrierea pe bucati
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                //rezolutia ia valoarea fiecarei rezolutii stocate
                rezolutiestart = i;
            }
        }
        //se adauga in dropdawn optiunile posibile, la inceput intrand cu rezolutia ecranului
        //se reinprospateaza valorile afisate
        rezolutie.AddOptions(optiuni);
        rezolutie.value = rezolutiestart;
        rezolutie.RefreshShownValue();
    }
    //subprogram care foloseste sliderul si care seteaza volumul
    public void Volum(float volum)
    {
        audiomixer.SetFloat("volum", volum);
    }
    //subprogram care afiseaza toate optiunile de calitate
    public void Quality(int calitate)
    {
        QualitySettings.SetQualityLevel(calitate);
    }
    //subprogram care activeaza si dezactiveaza fullscreenul
    public void fullscreen(bool este)
    {
        Screen.fullScreen = este;
    }
    //subprogram care activeaza si dezactiveaza butonul de mute
    public void farasunet(bool mut)
    {
        if(mut == true)
        {
            AudioListener.volume = 0;
        }
        if (mut == false)
        {
            AudioListener.volume = 1;
        }
    }
    //subprogram care seteaza rezolutia , prin campiisetati
    public void rezset(int rez)
    {
        Resolution resolution = resolutions[rez];
        //rezolutia ia valoarea lungimii , inaltimii, este setat by default pe fullscreen si refreshrate-ul
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }
}
