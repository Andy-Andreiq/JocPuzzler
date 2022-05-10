using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class random : MonoBehaviour
{//variabila de tip obiect, si variabile pentru pozitii
    //variabila de tip ind pentru preluarea de valori
    public GameObject key;
    private float pozX;
    private float pozY;
    private float pozZ;
    public int Rand;
    //subprogram care apeleaza alt subprogram imediat ce intri in scena
    void Start()
    {
        Spawn();
    }
    //subprogram care alege una din pozitiile random si transforma cheia la o pozitie 
    void Spawn()
    {
        RandomPoz();
        key.transform.position = new Vector3(pozX, pozY, pozZ);
    }
    //subprogram care randomizeaza pozitiile posibile alea cheii
    public void RandomPoz()
    {
       Rand = Random.Range(1, 8);
        if (Rand == 1)
        {
            pozX = -11.65f;
            pozY = 1f;
            pozZ = 23.58f;
        }
        else if (Rand == 2)
        {
            pozX = -10.3f;
            pozY = 1f;
            pozZ = 5.5f;
        }
        else if (Rand == 3)
        {
            pozX = -14.5f;
            pozY = 1f;
            pozZ = -22.76f;
        }
        else if (Rand == 4)
        {
            pozX = 11f;
            pozY = 1f;
            pozZ = -22.76f;
        }
        else if (Rand == 5)
        {
            pozX = 9.9f;
            pozY = 1f;
            pozZ = -0.85f;
        }
        else if (Rand == 6)
        {
            pozX = -4.03f;
            pozY = 1f;
            pozZ = -10f;
        }
        else if (Rand == 7)
        {
            pozX = -7.215f;
            pozY = 1f;
            pozZ = -2.8f;
        }
        else if (Rand == 8)
        {
            pozX = 7.572f;
            pozY = 1f;
            pozZ = 12.313f;
        }
    }
}
