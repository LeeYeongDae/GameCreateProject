using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 currPosition;
    public Vector3 startPos;
    float dirx, diry, angle;
    GameObject player;
    public bool Idle = true;
    bool Warn, detect;
    void Start()
    {
        player = GameObject.Find("Player");
        startPos = this.transform.position;
    }

    void Update()
    {
        detect = this.GetComponentInChildren<Detected>().detect;
        Warn = this.GetComponentInChildren<Detected>().Warn;
        currPosition = transform.position;
        if (this.Warn) Idle = false;
        if (this.detect) ChasePlayer();
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
            transform.position = Vector2.MoveTowards(currPosition, startPos, 10f * Time.deltaTime);
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
