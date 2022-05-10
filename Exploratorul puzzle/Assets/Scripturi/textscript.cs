using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textscript : MonoBehaviour
{
    public GameObject text;
    private bool odata = false;

    private void Update()
    {
        if(odata == false)
        {
            odata = true;
            text.GetComponent<Animation>().Play("Stefanelenes");
            Invoke("mana", 4);
        }
    }
    void mana()
    {
        text.SetActive(false);
    }
}
