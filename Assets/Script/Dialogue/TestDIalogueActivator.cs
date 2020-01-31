using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDIalogueActivator : MonoBehaviour
{

    [SerializeField] private DialoguePlayer current;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("OOF");
            current.Read(0);
            Destroy(this.gameObject);
        }
    }
}
