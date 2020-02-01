using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            transform.position = player.transform.position;      // l'objet vient se mettre sur le personnage
            this.GetComponent<SpriteRenderer>().enabled = false; // On désactive son rendu
            this.GetComponent<BoxCollider2D>().enabled = false;  // On désactive son collider
        }
    }
}
