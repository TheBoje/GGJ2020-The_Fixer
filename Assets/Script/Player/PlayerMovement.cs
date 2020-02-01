using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Vector3 input; // Vecteur d'input 
    public float speed = 2f; // Multiplicateur de vitesse, modifiable à vos souhaits

    private Rigidbody2D rb; // Rigidbody du player

    public bool canMove;
    public bool folowAPoint;
    public Transform folowTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            
            input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Récupération des inputs selon l'input manager de Unity
        }
        else
        {
            if (folowAPoint && folowTransform != null)
            {
                input = (folowTransform.position - transform.position).normalized;
            }
            else
            {
                input = Vector3.zero;
            }
        }      


        rb.velocity = input * speed; // Application de la vitesse au personnage
    }


}
