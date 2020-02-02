using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    public bool isInteracting = false;                      // Booléen de vérification : permet de ne pas lancer la boucle de minijeu pour nettoyer
    [SerializeField] private bool isPressingUse = false;    // Manière de merde pour savoir quand on presse la touche de merde
    [SerializeField] private GameObject canvas;             // Holder de l'UI

    private void Start()
    {
        canvas.SetActive(false);    // Mets inactive par défaut l'UI
    }

    private void Update()
    {
        isPressingUse = Input.GetButton("Fire1"); // Permet l'interaction avec l'interface, déclance le QTE si en contact avec un des objets du décors, et qui presse le bouton "Fire1"
    }


    private void OnTriggerStay2D(Collider2D collision) // Methode de Unity, collision.gameObject est le GO de l'object rencontré
    {

        if (collision.gameObject.tag == "Trash" && !isInteracting && isPressingUse) // Conditions d'intéractions
        {
            canvas.SetActive(true); //Bug du canvas qui bouge si on touch une direction
            
            GetComponent<PlayerMovement>().canMove = false; // Bloque le player
            isInteracting = true;                           // Evite de dupliquer / spam les interactions
            collision.gameObject.GetComponent<TrashState>().Interact(); // Lance la fonction d'interaction dans le fichier 
        }
    }
}