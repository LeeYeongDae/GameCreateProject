using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrested : MonoBehaviour
{
    private Vector3 currPosition;
    GameObject player, sight, pos;
    public bool detect, watchRight, Idle;
    bool Check = true;
    public float angle;
    int checkangle;

    void Start()
    {
        player = GameObject.Find("Player");
        pos = transform.parent.gameObject;
        sight = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        detect = sight.GetComponent<Detected>().detect;
        Idle = pos.GetComponent<Enemy>().Idle;
        currPosition = transform.position;
        if (this.detect) FacePlayer();
        if (!this.detect && Idle && Check && !GameManager.CaptureMod) RotateEnemy();
        if (checkangle % 180 == 0)
        {
            Check = false;
            StartCoroutine(Wait());
        }
    }

    public void RotateEnemy()
    {
        angle += 40f * Time.deltaTime;
        if (angle > 360) angle -= 360;
        checkangle = (int)angle;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FacePlayer()
    {
        Vector3 dir = player.transform.position - currPosition;
        Vector3 qut = Quaternion.Euler(0, 0, -90) * dir;
        Quaternion rot = Quaternion.LookRotation(forward: Vector3.forward, upwards: qut);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rot, Time.deltaTime * 30f);
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        Check = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.isOver = true;
        }
    }
}
