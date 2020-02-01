using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDIalogueActivator : MonoBehaviour
{

    [SerializeField] private DialoguePlayer current;
    [SerializeField] private int indice;
    [SerializeField] private bool isPlayerPresent;

    private float radius = 0.10f;
    private bool played = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetButtonDown("Fire1") && !played)
        {
            current.Read(indice);
            played = true;
        }
    }

}
