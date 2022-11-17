using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detected : MonoBehaviour
{
    float detectTime = 1f;
    float WarnTime;
    bool Warn;
    public static bool isOver;
    GameObject MiniGame;

    void Start()
    {

    }

    void Update()
    {
        if (Warn)
        {
            WarnTime += Time.deltaTime;
            if (WarnTime >= detectTime)
            {
                isOver = true;
                //Destroy(MiniGame, 0.2f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Warn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WarnTime = 0f;
            Warn = false;
        }
    }
}
