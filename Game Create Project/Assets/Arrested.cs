using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrested : MonoBehaviour
{
    private Vector3 currPosition;
    GameObject player, sight;
    public bool detect, watchRight;
    public float angle;

    void Start()
    {
        player = GameObject.Find("Player");
        sight = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        detect = sight.GetComponent<Detected>().detect;
        currPosition = transform.position;
        if (this.detect) FacePlayer();
    }

    public void RotateEnemy()
    {
        angle += 5f * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FacePlayer()
    {
        Vector3 dir = player.transform.position - currPosition;
        Vector3 qut = Quaternion.Euler(0, 0, -90) * dir;
        Quaternion rot = Quaternion.LookRotation(forward: Vector3.forward, upwards: qut);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rot, Time.deltaTime * 75f);
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.isOver = true;
        }
    }
}
