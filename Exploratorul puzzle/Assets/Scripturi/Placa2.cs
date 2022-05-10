using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa2 : MonoBehaviour
{
    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune2;

    public bool placaJ = false;
    string nume = "Potiune_Rosie";
    /// <------------------------------------> ANIMATIE PENTRU POTIUNEA ROSIE <-------------------------------> \\\
    private void Start()
    {
        RandomPoz();
        Potiune2.transform.position = new Vector3(pozX, pozY, pozZ);
        transform.position = new Vector3(-6.11f, 0.55f, 18.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nume)
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-6.11f, 0.44f, 18.5f);
            SaveManager.instance.placa2 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
        {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-6.11f, 0.55f, 18.5f);
            SaveManager.instance.placa2 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }


    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -9.032f;
            pozY = 1.26f;
            pozZ = -9.48f;
        }
        else if (Rand == 2)
        {
            pozX = -9.17f;
            pozY = 10f; 
            pozZ = -22.82f;
        }
        else if (Rand == 3)
        {
            pozX = 6.38f;
            pozY = 1.26f;
            pozZ = -19.56f;
        }
        //// <----POTIUNILE SE BAGA SUB HARTA ----->>>
        ///   ........................................

    }

}
