using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private GameObject player;  // Prend l'objet du joueur
    [SerializeField] private GameObject chicken; // Prend l'objet du poulet

    private void OnCollisionEnter2D(Collision2D collision) // Quand on entre dans une collision
    {
        if (collision.gameObject.tag == "Player") // Si le collision est avec le joueur
        {
            Vector3 playerCoor = player.transform.position;                 // Coordonnee du joueur
            Vector3 moov = new Vector3(playerCoor.x + 10.0f, 0.0f, 0.0f);   // Coordonnee du mouvement du poulet

            chicken.GetComponent<SpriteRenderer>().enabled = true;   // Montre le rendu du poulet
            chicken.GetComponent<BoxCollider2D>().enabled = true;    // Re-met les collisions avec le poulet
        }
    }
}
