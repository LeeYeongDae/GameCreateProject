using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrested : MonoBehaviour
{
    private Vector3 currPosition;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        currPosition = transform.position;
        if (Detected.detect) AlterDirection();
    }

    void AlterDirection()
    {
        Vector3 dir = player.transform.position - currPosition;
        //Vector3 qut = Quaternion.Euler(0, 0, 0) * dir;
        //Quaternion rot = Quaternion.LookRotation(forward: Vector3.forward, upwards: qut);
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rot, Time.deltaTime * 75f);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.isOver = true;
        }
    }
}
