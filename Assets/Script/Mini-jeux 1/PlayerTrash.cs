using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrash : MonoBehaviour
{
    [SerializeField] private GameObject Trash;
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            Trash.GetComponent<TrashState>().EnterTheTrash(collision.gameObject);
            //Debug.Log(collision.gameObject.GetComponent<TrashState>().State);
        }
    }
}
