using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKey : MonoBehaviour
{

    [SerializeField] private Transform canvas;
    [SerializeField] private Vector3 offset;

    public bool isPlayerPresent;

    private void OnGUI()
    {
        if (isPlayerPresent)
        {
            canvas.gameObject.SetActive(true);
            canvas.position = transform.position + offset;
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }

    private void DetectPlayer()
    {
        RaycastHit2D[] around = Physics2D.CircleCastAll(transform.position, 0.5f, Vector3.up);
        bool detect = false;
        foreach (RaycastHit2D hit in around)
        {
            if (hit.transform.tag == "Player")
            {
                detect = true;
            }
        }
        isPlayerPresent = detect;
    }

    private void Update()
    {
        DetectPlayer();
    }
}
