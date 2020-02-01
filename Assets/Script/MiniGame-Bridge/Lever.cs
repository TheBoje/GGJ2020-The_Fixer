using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    [SerializeField] private bool _state;


    // Start is called before the first frame update
    void Start()
    {
        _state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // On vérifie si le player et à porté et si il appuis sur E on change l'état du levier
        if(collision.tag == "Player")
        {
            if(Input.GetButtonDown("Fire1") && !_state)
            {
                //transform.GetComponentInParent<SpriteRenderer>().color = Color.green;
                _state = true;
            }
                
        }
       
    }

    public bool state
    {
        get { return _state; }
    }
}
