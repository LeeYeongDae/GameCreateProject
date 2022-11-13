using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interaction : MonoBehaviour
{
    public bool CaptureMod;
    private Vector2 pos;
    bool check1 = false;
    bool check2 = false;
    int password1 = 1136;
    int password2 = 4423;
    public Grid grid;
    public Tilemap wall;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CaptureMod = GameObject.Find("GameManager").GetComponent<GameManager>().CaptureMod;
        pos = transform.position;
        if (pos.x == -12 && pos.y == -4 && CaptureMod)
        {
            print("비밀번호는 " + password1);
            check1 = true;
            pos.x = 0;
            pos.y = 0;
            transform.position = pos;
        }
        if (check1)
        {
            wall.SetTile(new Vector3Int(-14, 1, 0), null);
        }
        if (pos.x == 7 && pos.y == 7 && CaptureMod)
        {
            print("비밀번호는 " + password2);
            check2 = true;
            pos.x = 0;
            pos.y = 0;
            transform.position = pos;
        }
        if (check2)
        {
            wall.SetTile(new Vector3Int(13, 1, 0), null);
        }
    }

}
