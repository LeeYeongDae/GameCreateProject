using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startPos, currPosition;
    float dirx, diry, angle;
    GameObject player, img;
    public bool detect = false, watchRight = false, Idle = true;

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
        else if (!this.detect)
        {
            if (!Idle && currPosition != startPos)
                Invoke("ReturnStart", 3f);
            if (currPosition == startPos)
                Idle = true;
        }
    }
    void ReturnStart()
    {
        if (currPosition != startPos)
            transform.position = Vector2.MoveTowards(currPosition, startPos, 40f * Time.deltaTime);
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
