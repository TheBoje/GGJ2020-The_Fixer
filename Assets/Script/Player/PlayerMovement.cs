using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Vector3 input; // Vecteur d'input 
    public float speed = 2f; // Multiplicateur de vitesse, modifiable à vos souhaits
    public bool canMove = true; // Pour bloquer le player quand il est en train QTE

    private Rigidbody2D rb; // Rigidbody du player

    public bool folowAPoint;
    public Transform folowTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   // récupère le rb du player
    }
    private void FixedUpdate() // Pas update parce que FixedUpdate rends tout smooths (toujours faire Fixed pour, 
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

        if (canMove)    // Applique la vélocité uniquement si je player n'est pas en QTE
        {
            rb.velocity = input * speed * 100 * Time.deltaTime; // Application de la vitesse au personnage ( + linéarisation avec Time.deltaTime)
        }
        else
        {
            rb.velocity = Vector3.zero; // Si le player joue, on bloque ses mouvements
        }
    }

}
