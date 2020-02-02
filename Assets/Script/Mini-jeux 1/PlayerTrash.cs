using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    public bool isInteracting = false;  // Booléen de vérification : permet de ne pas lancer la boucle de minijeu pour nettoyer
    [SerializeField] private bool isPressingUse = false;

    private void Update()
    {
        isPressingUse = Input.GetButton("Fire1"); //TODO Fix this shit please ( louis de demain, soit pas con stp)
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash" && !isInteracting && isPressingUse)
        {
            isInteracting = true;
            collision.gameObject.GetComponent<TrashState>().Interact();
        }


        /*else if ( isInteracting == true)
        {
            Debug.Log("Le personnage est déjà en train d'intéragir. Le bool est mis à false quelque part?");
        }*/
    }
}