using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    [SerializeField] private GameObject player;  
    [SerializeField] public bool isFollowingPlayer = false;
    [SerializeField] private int distMin = 2;
    [SerializeField] private float speed = 1.5f;

    private Vector3 Direction;
    private float Distance;

    public void OnTriggerStay2D(Collider2D collision)   // Quand on reste dans un trigger
    {
        if (collision.tag == "Player" && !isFollowingPlayer)  // Si le joueur collisionne avec l'objet
        {
            isFollowingPlayer = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFollowingPlayer)
        {
            Distance = Vector3.Distance(player.transform.position, transform.position);
            if (Distance > distMin)
            {
                transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
            }
        }
    }
}
