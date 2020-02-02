using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovement pM;
    [SerializeField] private AudioSource aS;
    private Rigidbody2D rb;
    [SerializeField][Range(0,1)]private float timeBstep = 0.5f;
    private float timeStart;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timeStart = Time.time;
        aS.Play();
    }

    private void Update()
    {
        if(rb.velocity.magnitude >= 0.1)
        {
            anim.SetFloat("UpDown", pM.input.y);
            anim.SetFloat("LeftRight", pM.input.x);

            if(Time.time - timeBstep >= timeStart)
            {

                aS.Play();
                timeStart = Time.time;

            }
            
        }
        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }
}
