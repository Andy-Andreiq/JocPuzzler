using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{//Apeleaza o funtie predefinita , dand o variabila instanta, care seteaza o lista privata si care ea fiecare funtie
    public static SaveManager instance { get; private set; }
    //Secrete

    public bool secret1 = false;
    public bool secret22 = false;
    public bool secret3 = false;
    public bool secret4 = false;
    public bool secret5 = false;
    //Meniu Nivele
    public bool tut = false;
    public bool lvl1 = false;
    public bool lvl2 = false;
    public bool lvl3 = false;
    public bool lvl4 = false;
    public bool lvl5 = false;
    //Lvl2
    public bool placa1;
    public bool placa2;
    public bool placa3;
    public bool placa4;
    public bool placa5;
    //canvas Meniu
    public bool second = false;
    public bool aparut = false;
    //subprogram care la apelarea scriptului , verifica variabila
    //daca nu e goala si e diferita de precedenta se distruge obiectul
    //altfel instanta ia valoarea listei din momentul respectiv
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        //comanda care nu distruge la incarcare obiectul pe care este pus scriptul
  
        DontDestroyOnLoad(gameObject);
        //subprogram apelat
        Load();
    }

    public void Load()
    {//Conditii, daca Fila exista , variabilele din aplicatie pot fi ridicate din baza de date
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {//comanda predefinita de unity care reprezinta un reformator binar, realizand o variabila,in care datele se stocheaza in forme de cifre
            BinaryFormatter bf = new BinaryFormatter();
            //comanda predefinita care creaza o variabila noua si care deschide fila de salvari si o lasa deschisa pentru extragere
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            //comanda predefinita care creeaza o variabila in care datele stocate sunt trimise din fila in variabila dupa reformatare
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            //variabilele iau datele stocate din variabila data 
            secret1 = data.secret1;
            secret22 = data.secret22;
            secret3 = data.secret3;
            secret4 = data.secret4;
            secret5 = data.secret5;
            tut = data.tut;
            lvl1 = data.lvl1;
            lvl2 = data.lvl2;
            lvl3 = data.lvl3;
            lvl4 = data.lvl4;
            lvl5 = data.lvl5;
            placa1 = data.placa1;
            placa2 = data.placa2;
            placa3 = data.placa3;
            placa4 = data.placa4;
            placa5 = data.placa5;
            aparut = data.aparut;
            second = data.second;
            //inchide fila dupa ridicarea informatiei
            file.Close();
        }
    }
    //subprogram folosit in salvarea datelor
    public void Save()
    {//comanda predefinita pentru crearea unei variabile noi de tip reformator binar
        //aceasta formatand informatiile in cifre pentru usurare si pentru scaderea memoriei(mai putina utilizata)
        BinaryFormatter bf = new BinaryFormatter();
        //comanda predefinita care realizeaza o variabila , in care se creaza o fila si in care se stocheaza datele aplicatiei
        //datele aplicatiei reprezinta datele introduce de noi
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        //comanda care creaza o variabila , care ia forma unui Storage Nou de date
        PlayerData_Storage data = new PlayerData_Storage();
        //datele cuprinse de-a lungul actiunii fiind slalvate in variabile si contopite in cod mai tarziu
        data.secret4 = secret4;
        data.secret1 = secret1;
        data.secret3 = secret3;
        data.secret22 = secret22;
        data.secret5 = secret5;
        data.tut = tut;
        data.lvl1 = lvl1;
        data.lvl2 = lvl2;
        data.lvl3 = lvl3;
        data.lvl4 = lvl4;
        data.lvl5 = lvl5;
        data.placa1 = placa1;
        data.placa2 = placa2;
        data.placa3 = placa3;
        data.placa4 = placa4;
        data.placa5 = placa5;
        data.aparut = aparut;
        data.second = second;
        //serializeaza statusul obiectului stocat si numele acestuia in forma de bytes
        bf.Serialize(file, data);
        file.Close();
    }
}
//Camp predefinit care explica posibilitatea clasei de a ii fi luat statutul si de a fi stocat in forma de bytes
[Serializable]
class PlayerData_Storage
{
    public bool secret1;
    public bool secret22;
    public bool secret3;
    public bool secret4;
    public bool secret5;
    public bool tut;
    public bool lvl1;
    public bool lvl2;
    public bool lvl3;
    public bool lvl4;
    public bool lvl5;
    public bool placa1;
    public bool placa2;
    public bool placa3;
    public bool placa4;
    public bool placa5;
    public bool aparut;
    public bool second;
}