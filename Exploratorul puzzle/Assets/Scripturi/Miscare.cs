using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscare : MonoBehaviour
{
    public CharacterController controller;


    public float viteza = 4f;
    public float gravitatie = -10f;
    public float saritura = 1f;

    Vector3 velocitate;

    public Transform Picioare;
    public float distanta = 0.4f;
    public LayerMask Pamant;
    bool PePamant;
    void Update()
    {
        PePamant = Physics.CheckSphere(Picioare.position, distanta, Pamant);

        if(PePamant && velocitate.y <0)
        {
            velocitate.y = -2f;
        }

        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 miscare = transform.right * x + transform.forward * z;



        controller.Move(miscare * viteza *Time.deltaTime);

        if (Input.GetButtonDown("Jump") && PePamant)
                {
            velocitate.y = Mathf.Sqrt(saritura * -2f * gravitatie);
        }

            velocitate.y += gravitatie * Time.deltaTime;

        controller.Move(velocitate * Time.deltaTime);
    }
}
