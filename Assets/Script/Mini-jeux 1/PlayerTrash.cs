using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    [SerializeField] private GameObject Trash;
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Debug.Log("TEST");
           // Trash.GetComponent<>.EnterTheTrash(collision.gameObject);
        }
    }
}
