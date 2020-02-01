using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    public bool isInteracting = false;  // Booléen de vérification : permet de ne pas lancer la boucle de minijeu pour netoyer ea


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash" && Input.GetButtonDown("Use") && isInteracting == false)
        {
            //collision.gameObject.GetComponent<TrashState>().Interact();
            isInteracting = true;
        }
        else if ( isInteracting == true)
        {
            Debug.Log("Le personnage est déjà en train d'intéragir. Le bool est mis à false quelque part?");
        }
    }
}