using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;
    private bool isClicked = false;
    private int active = 0;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update()
    {
        if (isClicked)
        {
            mouse_pos = Input.mousePosition;
            mouse_pos.z = -20;
            object_pos = Camera.main.WorldToScreenPoint(target.position);
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float z = transform.rotation.z * Mathf.Rad2Deg;

            if (z > -5 && z < 5)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }

    void OnMouseDown()
    {
        if (this.gameObject.tag == "Ecrou" && active % 2 == 0)
        {
            isClicked = true;
            active++;
        }
        else if (this.gameObject.tag == "Ecrou" && active % 2 == 1)
        {
            isClicked = false;
            active++;
        }
    }
}
