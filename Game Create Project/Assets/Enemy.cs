using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 currPosition;
    float dirx, diry;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        currPosition = transform.position;
        //if (Detected.detect) ChasePlayer();
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
