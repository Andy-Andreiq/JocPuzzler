using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa3 : MonoBehaviour
{

    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune3;



    public bool placaJ = false;
    string nume = "Potiune_Verde";
    /// <------------------------------------> ANIMATIE PENTRU POTIUNEA VERDE <-------------------------------> \\\
    private void Start()
    {
        RandomPoz();
        Potiune3.transform.position = new Vector3(pozX, pozY, pozZ);
        transform.position = new Vector3(-4.577f, 0.55f, 18.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nume)
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-4.577f, 0.44f, 18.5f);
            SaveManager.instance.placa3 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
       {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-4.577f, 0.55f, 18.5f);
            SaveManager.instance.placa3 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }

    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -7.322f;
            pozY = 1.061f;
            pozZ = 24.195f;
        }
        else if (Rand == 2)
        {
            pozX = -19.59f;
            pozY = 1.12f;
            pozZ = 15.19f;
        }
        else if (Rand == 3)
        {
            pozX = -12.883f;
            pozY = 0.966f;
            pozZ = 6.43f;
        }
 

    }

}
