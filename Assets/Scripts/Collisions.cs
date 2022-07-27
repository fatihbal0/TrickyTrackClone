using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collisions : MonoBehaviour
{
    Movement movement;
    Rigidbody rigidbody;
    BoxCollider kapi_collider;
    [SerializeField]
    private GameObject Parent, playerkapi1, playerkapi2, enemykapi1, enemykapi2, player_hizlandirici, enemy_hizlandirici;
    [SerializeField]
    private Material kirmizi_zemin, yesil_zemin;
    private Renderer ren, ren_hizlandirici;
    private Material[] mat;
    void Start()
    {
        movement = Parent.GetComponent<Movement>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Hedefsag1"))
        {
            ren = other.gameObject.GetComponent<Renderer>();
            mat = ren.materials;
            Animator animator_playerkapi1 = playerkapi1.GetComponent<Animator>();
            kapi_collider = playerkapi1.GetComponent<BoxCollider>();
            other.gameObject.transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 1f, 1, 0f);

            if(animator_playerkapi1.GetBool("Trigger"))
            {
                animator_playerkapi1.SetBool("Trigger",false);
                kapi_collider.enabled = true;
                mat[1].color = Color.red;                
            }
            else
            {
                kapi_collider.enabled = false;
                animator_playerkapi1.SetBool("Trigger",true);
                movement.movementSpeed = 5f;
                mat[1].color = Color.green;
            }
        }

        if(other.gameObject.CompareTag("Hedefsag2"))
        {
            ren = other.gameObject.GetComponent<Renderer>();
            mat = ren.materials;
            Animator animator_playerkapi2 = playerkapi2.GetComponent<Animator>();
            kapi_collider = playerkapi2.GetComponent<BoxCollider>();
            other.gameObject.transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 1f, 1, 0f);
            
            if(animator_playerkapi2.GetBool("Trigger"))
            {
                animator_playerkapi2.SetBool("Trigger",false);
                kapi_collider.enabled = true;
                mat[1].color = Color.red;
            }
            else
            {
                animator_playerkapi2.SetBool("Trigger",true);
                kapi_collider.enabled = false;
                movement.movementSpeed = 5f;
                mat[1].color = Color.green;
            }
        }

        if(other.gameObject.CompareTag("Hedefsol1"))
        {
            ren = other.gameObject.GetComponent<Renderer>();
            mat = ren.materials;
            Animator animator_enemykapi1 = enemykapi1.GetComponent<Animator>();
            kapi_collider = enemykapi1.GetComponent<BoxCollider>();
            other.gameObject.transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 1f, 1, 0f);

            if(animator_enemykapi1.GetBool("Trigger"))
            {
                animator_enemykapi1.SetBool("Trigger",false);
                kapi_collider.enabled = true;
                mat[1].color = Color.red;                
            }
            else
            {
                kapi_collider.enabled = false;
                animator_enemykapi1.SetBool("Trigger",true);
                movement.movementSpeed = 5f;
                mat[1].color = Color.green;
            }
        }

        if(other.gameObject.CompareTag("Hedefsol2"))
        {
            ren = other.gameObject.GetComponent<Renderer>();
            mat = ren.materials;
            Animator animator_enemykapi2 = enemykapi2.GetComponent<Animator>();
            kapi_collider = enemykapi2.GetComponent<BoxCollider>();
            other.gameObject.transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 1f, 1, 0f);

            if(animator_enemykapi2.GetBool("Trigger"))
            {
                animator_enemykapi2.SetBool("Trigger",false);
                kapi_collider.enabled = true;
                mat[1].color = Color.red;                
            }
            else
            {
                kapi_collider.enabled = false;
                animator_enemykapi2.SetBool("Trigger",true);
                movement.movementSpeed = 5f;
                mat[1].color = Color.green;
            }
        }

        if(other.gameObject.CompareTag("Hedefsaghizlandirici"))
        {
            ren = other.gameObject.GetComponent<Renderer>();
            ren_hizlandirici = player_hizlandirici.GetComponent<Renderer>();
            mat = ren.materials;
            other.gameObject.transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 1f, 1, 0f);
            if(mat[1].color == Color.green)
            {
                
                ren_hizlandirici.material = kirmizi_zemin;
                mat[1].color = Color.red;
                player_hizlandirici.transform.rotation = Quaternion.Euler(0, 0, 0);
                player_hizlandirici.tag = "Yavaslatici";

            }
            else
            {
                mat[1].color = Color.green;
                ren_hizlandirici.material = yesil_zemin;
                player_hizlandirici.transform.rotation = Quaternion.Euler(0, 180, 0);
                player_hizlandirici.tag = "Hizlandirici";
            }
            
        }

        if(other.gameObject.CompareTag("Hedefsolhizlandirici"))
        {
            ren = other.gameObject.GetComponent<Renderer>();
            ren_hizlandirici = enemy_hizlandirici.GetComponent<Renderer>();
            mat = ren.materials;
            other.gameObject.transform.DOPunchScale(new Vector3(0.1f,0.1f,0.1f), 1f, 1, 0f);
            if(mat[1].color == Color.green)
            {
                
                ren_hizlandirici.material = kirmizi_zemin;
                mat[1].color = Color.red;
                enemy_hizlandirici.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy_hizlandirici.tag = "Yavaslatici";

            }
            else
            {
                mat[1].color = Color.green;
                ren_hizlandirici.material = yesil_zemin;
                enemy_hizlandirici.transform.rotation = Quaternion.Euler(0, 180, 0);
                enemy_hizlandirici.tag = "Hizlandirici";
            }
            
        }

    }



}
