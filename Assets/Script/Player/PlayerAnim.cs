using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovement pM;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb.velocity.magnitude >= 0.1)
        {
            anim.SetFloat("UpDown", pM.input.y);
            anim.SetFloat("LeftRight", pM.input.x);
        }
        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }
}
