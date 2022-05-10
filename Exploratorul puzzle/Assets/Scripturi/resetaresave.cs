using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetaresave : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown("r"))
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
            SaveManager.instance.second = false;
            SaveManager.instance.Save();
        }
    }
}
