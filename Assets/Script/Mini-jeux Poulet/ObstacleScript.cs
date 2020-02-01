using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject chicken;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 playerCoor = player.transform.position;
            Vector3 moov = new Vector3(playerCoor.x + 10.0f, 0.0f, 0.0f);

            chicken.GetComponent<SpriteRenderer>().enabled = true;
            chicken.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
