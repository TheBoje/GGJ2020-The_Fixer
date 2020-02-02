using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private GameObject player;  // Prend l'objet du joueur
    [SerializeField] private GameObject chicken; // Prend l'objet du poulet
    private bool isFollowing;
    private bool isGoingBack;
    [SerializeField] private int i = 0;
    [SerializeField] private int refreshRate = 300;
    [SerializeField] private Vector3 oldPosition;
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        isFollowing = chicken.GetComponent<ChickenScript>().isFollowingPlayer;
        if (i >= refreshRate)
        {
            oldPosition = chicken.transform.position;
            i = 0;
        }
        else
        {
            i++;
        }
        if (isGoingBack)
        {
            if (Vector3.Distance(chicken.GetComponent<Transform>().position,oldPosition) > 0.5f)
            {
                chicken.GetComponent<Transform>().position = Vector3.Lerp(chicken.GetComponent<Transform>().position, oldPosition, Time.deltaTime * speed);
            }
            else
            {
                isGoingBack = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // Quand on entre dans une collision
    {
        if (collision.gameObject.tag == "Player" && isFollowing) // Si le collision est avec le joueur
        {
            chicken.GetComponent<ChickenScript>().isFollowingPlayer = false;
            isGoingBack = true;
        }
    }

}
