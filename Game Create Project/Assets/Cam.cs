using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float velocity = 5f;
    GameObject Player;
    Camera Camera;
    float signal = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (!isPlayerVisible())
        {
            signal -= Time.deltaTime;
            if (signal <= 0) GameManager.isOver = true;
        }
        else signal = 3f;
        if (!GameManager.CaptureMod)
        {
            X_Move();
            Y_Move();
        }
        if (Player.transform.position.x < -20)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -53f, -36f), Mathf.Clamp(transform.position.y, -4f, 18f), -10);
        }
        else if (Player.transform.position.x > 20)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 35f, 68f), Mathf.Clamp(transform.position.y, -6f, 9f), -10);
        }
        else
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 6f), Mathf.Clamp(transform.position.y, -11f, 3f), -10);
    }

    void X_Move()
    {
        Vector3 movedirection = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movedirection = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movedirection = Vector3.right;
        }

        transform.position += movedirection * velocity * Time.deltaTime;
    }

    void Y_Move()
    {
        Vector3 movedirection = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movedirection = Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            movedirection = Vector3.down;
        }

        transform.position += movedirection * velocity * Time.deltaTime;
    }

    bool isPlayerVisible()
    {
        var view = GeometryUtility.CalculateFrustumPlanes(Camera);
        var player = Player.transform.position;
        foreach(var exist in view)
        {
            if (exist.GetDistanceToPoint(player) < 0)
                return false;
        }
        return true;
    }
}
