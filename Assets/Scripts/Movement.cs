using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Kapi"))
        {
            Debug.Log("kapi temas");
            movementSpeed = 0f;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Hizlandirici"))
        {
            movementSpeed = 6.5f;
        }

        if(other.gameObject.CompareTag("Yavaslatici"))
        {
            movementSpeed = 3.5f;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Hizlandirici") || other.gameObject.CompareTag("Yavaslatici"))
        {
            movementSpeed = 5f;
        }
    }
}
