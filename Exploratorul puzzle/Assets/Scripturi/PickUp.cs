using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform dest;
    public bool cheie; 
    void OnMouseDown()
    {
        cheie = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
            this.transform.position = dest.position;
        this.transform.parent = GameObject.Find("Obiect").transform;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnMouseUp()
    {
        cheie = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<MeshCollider>().enabled = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().isKinematic = false ;
    }
}
