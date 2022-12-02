using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrested : MonoBehaviour
{
    private Vector3 currPosition, startPos;
    GameObject player, sight, pos;
    public bool detect, Idle, Rotating, Vertical;
    bool Check = true;
    public float angle;
    int checkangle;

    void Start()
    {
        player = GameObject.Find("Player");
        pos = transform.parent.gameObject;
        startPos = pos.GetComponent<Enemy>().startPos;
        sight = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        detect = sight.GetComponent<Detected>().detect;
        Idle = pos.GetComponent<Enemy>().Idle;
        currPosition = transform.position;
        if(!GameManager.CaptureMod)
        {
            if (this.detect) FacePlayer();
            else if (!this.detect && !Idle) Invoke("ReturnPos", 2f);
            if (!this.detect && Idle && Check && Rotating) RotateEnemy();
            
        }
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
        if (Vertical) checkangle += 90;
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

    void ReturnPos()
    {
        Vector3 dir = startPos - currPosition;
        Vector3 qut = Quaternion.Euler(0, 0, 0) * dir;
        Quaternion rot = Quaternion.LookRotation(forward: Vector3.forward, upwards: qut);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rot, Time.deltaTime * 100f);
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
