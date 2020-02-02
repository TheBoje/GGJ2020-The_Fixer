using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    [SerializeField] private Transform target; // Transform de l'ecrou

    private Vector3 mouse_pos;                 // Position de la souris 
    private Vector3 object_pos;                // Position de l'objet
    private float angle;                       // Angle de rotation
    private bool isClicked = false;            // Verifie le clic sur l'ecrou
    private int active = 0;                    // Active ou non la rotation

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red; // Initialise l'ecrou en rouge
    }

    void Update()  // A chaque frame
    {
        if (isClicked) // Si le joueur clique sur l'ecrou
        {
            mouse_pos = Input.mousePosition;                                // Position de la souris a l'instant t
            mouse_pos.z = -20;                                              // "Ignore" le z de la position de la souris 
            object_pos = Camera.main.WorldToScreenPoint(target.position);   // Position de l'ecrou a l'instant t
            mouse_pos.x = mouse_pos.x - object_pos.x;                       // Met le vecteur x de la souris en y soustrayant la position de l'ecrou
            mouse_pos.y = mouse_pos.y - object_pos.y;                       // Met le vecteur y de la souris en y soustrayant la position de l'ecrou
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;  // Convertit la tengante de l'angle en radian
            transform.rotation = Quaternion.Euler(0, 0, angle);             // Effectue la rotation
        }
        else           // Si le joueur ne clique pas sur l'ecrou
        {
            float z = transform.rotation.z * Mathf.Rad2Deg;   // Prend le z de l'ecrou et le transforme en degres 

            if (z > -20 && z < 20)    // Si le z est compris entre -5 et 5
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;  // Met l'ecrou en vert
            }
        }
    }

    void OnMouseDown()  // Quand la souris clic
    {
        if (this.gameObject.tag == "Ecrou" && active % 2 == 0)        // Si l'objet est un ecrou et que le clic est actif
        {
            isClicked = true;  // Le clic est valide
            active++;          // Active  = desactive pour le prochain clic
        }
        else if (this.gameObject.tag == "Ecrou" && active % 2 == 1)   // Si l'objet est un ecrou et que le clic n'est pas actif
        {
            {
                isClicked = false; // Le clic n'est pas valide
                active++;          // Active  = active pour le prochain clic
            }
        }
    }
}
