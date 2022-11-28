using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detected : MonoBehaviour
{
    float detectTime = 1f;
    float WarnTime;
    public bool Warn;
    public bool detect = false;
    SpriteRenderer sren;

    void Start()
    {
        sren = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Warn)
        {
            WarnTime += Time.deltaTime;
            if (WarnTime >= detectTime)
            {
                detect = true;
                sren.color = new Color(1, 0, 0, 1);
            }
        }
        else detect = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Warn = true;
            sren.color = new Color(1, 1, 1, 1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WarnTime = 0f;
            Warn = false;
            sren.color = new Color(0, 1, 0, 1);
        }
    }
}
