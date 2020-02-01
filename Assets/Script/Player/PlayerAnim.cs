using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb.velocity.magnitude >= 0.1)
        {
            anim.SetFloat("UpDown", Input.GetAxis("Vertical"));
            anim.SetFloat("LeftRight", Input.GetAxis("Horizontal"));
        }
        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }
}
