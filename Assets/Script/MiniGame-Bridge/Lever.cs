using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] private bool _state;
    [SerializeField] private AudioSource aS;

    public bool isPLayerPresent;


 
    void Start()
    {
        _state = false;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPLayerPresent = false;
        // On vérifie si le player et à porté et si il appuis sur E on change l'état du levier
        if(collision.tag == "Player")
        {
            isPLayerPresent = true;
            if(Input.GetButtonDown("Fire1") && !_state)
            {
                //transform.GetComponentInParent<SpriteRenderer>().color = Color.green;
                aS.Play();
                _state = true;
                
            }
                
        }
       
    }

    public bool state
    {
        get { return _state; }
    }
}
