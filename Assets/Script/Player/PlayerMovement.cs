using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Vector3 input; // Vecteur d'input 
    public float speed = 2f; // Multiplicateur de vitesse, modifiable à vos souhaits
    public bool canMove = true;
    private string bigay = "yann is big gay"; // A voir plus tard i guess

    private Rigidbody2D rb; // Rigidbody du player

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Récupération des inputs selon l'input manager de Unity

        if (canMove)
        {
            rb.velocity = input * speed * 100 * Time.deltaTime; // Application de la vitesse au personnage ( + linéarisation avec Time.deltaTime)
        }
        else
        {
            rb.velocity = Vector3.zero;
            // suck like a gay
        }
    }
}
