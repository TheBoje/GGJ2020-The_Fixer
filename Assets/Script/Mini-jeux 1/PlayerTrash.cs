using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    public bool isInteracting = false;                      // Booléen de vérification : permet de ne pas lancer la boucle de minijeu pour nettoyer
    [SerializeField] private GameObject canvas;             // Holder de l'UI

    private void Start()
    {
        canvas.SetActive(false);    // Mets inactive par défaut l'UI
    }




    private void OnTriggerStay2D(Collider2D collision) // Methode de Unity, collision.gameObject est le GO de l'object rencontré
    {
        if (collision.gameObject.tag == "Trash" && !isInteracting && Input.GetButton("Fire1")) // Conditions d'intéractions
        {
            canvas.SetActive(true); //Bug du canvas qui bouge si on touch une direction
            
            GetComponent<PlayerMovement>().canMove = false; // Bloque le player
            isInteracting = true;                           // Evite de dupliquer / spam les interactions
            collision.gameObject.GetComponent<TrashState>().Interact(); // Lance la fonction d'interaction dans le fichier 
        }
    }
}