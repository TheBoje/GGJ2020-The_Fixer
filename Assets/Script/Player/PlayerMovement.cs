using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Vector3 input;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = input * speed;
    }

}
