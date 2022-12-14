using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreCam : MonoBehaviour
{
    public float velocity = 5f;
    GameObject Player;
    Camera Camera;
    RectTransform Glitch;
    Image Glitchim;
    float signal = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Glitch = GameObject.Find("Glitch").GetComponent<RectTransform>();
        Glitchim = GameObject.Find("Glitch").GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (!isPlayerVisible())
        {
            signal += Time.deltaTime;
            Glitching();
            if (signal >= 3) GameManager.isOver = true;
        }
        else
        {
            signal = 0f;
            Glitchim.color = new Color(Glitchim.color.r, Glitchim.color.g, Glitchim.color.b, 0);
            Glitch.transform.localPosition = new Vector3(-1000, -500, 0);
        }
        if (!GameManager.CaptureMod)
        {
            X_Move();
            Y_Move();
        }
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
        foreach (var exist in view)
        {
            if (exist.GetDistanceToPoint(player) < 0)
                return false;
        }
        return true;
    }

    void Glitching()
    {
        int random = Random.Range(0, 4);
        Vector3 Tickdir = Vector3.zero;
        switch (random)
        {
            case 0:
                Tickdir = Vector3.up;
                break;
            case 1:
                Tickdir = Vector3.down;
                break;
            case 2:
                Tickdir = Vector3.left;
                break;
            case 3:
                Tickdir = Vector3.right;
                break;
        }
        Glitch.transform.localPosition += Tickdir * signal * 10;
        Glitchim.color = new Color(Glitchim.color.r, Glitchim.color.g, Glitchim.color.b, signal / 2);
    }
}