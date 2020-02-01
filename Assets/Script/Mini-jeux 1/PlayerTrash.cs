using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    public bool isInteracting = false;  // Booléen de vérification : permet de ne pas lancer la boucle de minijeu pour nettoyer
    [SerializeField] private bool isPressingUse = false;
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void Update()
    {
        isPressingUse = Input.GetButton("Use");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Trash" && !isInteracting && isPressingUse)
        {
            canvas.SetActive(true); //Bug du canvas qui bouge si on touch une direction
            
            GetComponent<PlayerMovement>().canMove = false;

            isInteracting = true;
            collision.gameObject.GetComponent<TrashState>().Interact();
        }
    }
}