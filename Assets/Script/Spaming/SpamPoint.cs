using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpamPoint : MonoBehaviour
{

    [SerializeField] private float radius;
    [SerializeField] private float spamForce;
    [SerializeField] private float spamLimit;

    [SerializeField] private float timeStamp;
    private float startTime;

    public bool isPlayerPresent;

    [SerializeField] private Transform jaugeObject;
    [SerializeField] private Vector3 offset;

    [SerializeField] private Sprite fixedSprite;
    [SerializeField] private SpriteRenderer render;

    public bool state=false;

    private void Start()
    {

        startTime = Time.time;
    }

    private void Update()
    {
        if (state)
        {
            jaugeObject.gameObject.SetActive(false);
            return;

        }

        DetectPlayer();

        if (isPlayerPresent)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                spamForce++;
                Camera.main.transform.DOComplete();
                Camera.main.transform.DOShakePosition(.2f, .25f, 14, 90, false, true);
            }
        }
        
        if(Time.time - timeStamp >= startTime && spamForce > 0)
        {
            spamForce--;
            startTime = Time.time;

        }

        if(spamForce >= spamLimit)
        {
            Destroy(GetComponent<Animator>());
            if (GetComponent<AudioSource>())
            {
                Destroy(GetComponent<AudioSource>());
            }
            jaugeObject.gameObject.SetActive(false);
            render.sprite = fixedSprite;
            state = true;
        }

    }

    private void DetectPlayer()
    {
        RaycastHit2D[] around = Physics2D.CircleCastAll(transform.position, radius, Vector3.up);
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

    private void OnGUI()
    {
        if (isPlayerPresent)
        {
            jaugeObject.gameObject.SetActive(true);
            jaugeObject.position = Camera.main.WorldToScreenPoint(transform.position + offset);
            jaugeObject.localScale = new Vector3(1 * (spamForce/spamLimit),1,1);
        }
        else
        {
            jaugeObject.gameObject.SetActive(false);
        }
    }

}
