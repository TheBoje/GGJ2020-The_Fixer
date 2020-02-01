using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; // Transform du player
    public float offset = -10f;                         // Offset de la caméra selon z
    [SerializeField] [Range(0f, 1f)] private float smoothness = 0.2f; // Coef de Slerp, compris entre 0f et 1f, 1 = pas de Slerp, 0 = ne follow pas

    void Start()
    {
        transform.position = playerTransform.position + new Vector3(0f, 0f, offset); // Initialisation de la position de la caméra sur le player
    }

    void FixedUpdate() // FixedUpdate parce que pas de lag contrairement à Update()
    {
        Vector3 desiredPosition = playerTransform.transform.position + new Vector3(0f, 0f, offset); // Précalcul de la position désirée pour la caméra
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothness);  // Calcul de la linéarisation / smoothness avec Slerp
        transform.position = smoothedPosition; // Application de la position
    }
}
