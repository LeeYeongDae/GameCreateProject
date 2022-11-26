using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startPos, currPosition;
    float dirx, diry, angle;
    GameObject player, img;
    bool detect, watchRight, Idle;

    void Start()
    {
        player = GameObject.Find("Player");
        img = transform.GetChild(0).gameObject;
        startPos = this.transform.position;
    }

    void Update()
    {
        detect = img.GetComponent<Arrested>().detect;
        currPosition = transform.position;
        if (this.detect)
        {
            Idle = false;
            Invoke("ChasePlayer", 0.5f);
        }
        else if (!this.detect && !Idle)
        {
            Invoke("ReturnStart", 3f);
            if (currPosition == startPos)
                Idle = true;
        }
        else if (!this.detect && Idle)
        {
            IdleMove();
        }
    }

    void ReturnStart()
    {
        transform.position = Vector2.MoveTowards(currPosition, startPos, 2f * Time.deltaTime);
    }
    void IdleMove()
    {
        if (watchRight && currPosition.x < startPos.x + 4)
            currPosition.x -= (Time.deltaTime * 2f);
        else if((watchRight && currPosition.x == startPos.x + 4) || (!watchRight && currPosition.x == startPos.x - 4))
        {
            angle = img.GetComponent<Arrested>().angle;
            img.GetComponent<Arrested>().RotateEnemy();
        }
        if (!watchRight && currPosition.x > startPos.x - 4)
            currPosition.x += (Time.deltaTime * 2f);
        else if (!watchRight && currPosition.x == startPos.x - 4)
        {
            angle = img.GetComponent<Arrested>().angle;
            angle += 0.01f;
            if (angle != 180)
                img.GetComponent<Arrested>().RotateEnemy();
            else watchRight = true;
        }
    }

    void ChasePlayer()
    {
        dirx = player.transform.position.x - currPosition.x;
        dirx = (dirx < 0) ? -1 : 1;
        diry = player.transform.position.y - currPosition.y;
        diry = (diry < 0) ? -1 : 1;
        transform.Translate(new Vector2(dirx, diry) * 4f * Time.deltaTime);
    }
}
