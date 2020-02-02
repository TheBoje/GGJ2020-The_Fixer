using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Vector3 input; // Vecteur d'input 
    public float speed = 2f; // Multiplicateur de vitesse, modifiable à vos souhaits
    public bool canMove = true; // Pour bloquer le player quand il est en train QTE
    private string bigay = "yann is big gay"; // A voir plus tard i guess

    private Rigidbody2D rb; // Rigidbody du player

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   // récupère le rb du player
    }
    private void FixedUpdate() // Pas update parce que FixedUpdate rends tout smooths (toujours faire Fixed pour, 
    {
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Récupération des inputs selon l'input manager de Unity

        if (canMove)    // Applique la vélocité uniquement si je player n'est pas en QTE
        {
            rb.velocity = input * speed * 100 * Time.deltaTime; // Application de la vitesse au personnage ( + linéarisation avec Time.deltaTime)
        }
        else
        {
            rb.velocity = Vector3.zero; // Si le player joue, on bloque ses mouvements
            // suck like a gay
        }
    }
}
