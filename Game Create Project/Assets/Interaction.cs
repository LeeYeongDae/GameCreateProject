using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interaction : MonoBehaviour
{
    private Vector2 pos;
    bool check1 = false;
    bool check2 = false;
    bool check3 = false;
    bool check4 = false;
    bool check5 = false;
    bool check6 = false;
    bool checkS1, checkS2, checkS3;
    public Grid grid;
    public Tilemap door, file;
    public TileBase Col, Row;
    GameObject Player;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (pos.x == -12 && pos.y == -4 && GameManager.CaptureMod)
        {
            check1 = true;
            transform.position = Player.transform.position;
        }
        if (check1)
        {
            door.SetTile(new Vector3Int(-14, 1, 0), null);
            //distance = Vector3.Distance(transform.position, target.position);
        }
        if (pos.x == 7 && pos.y == 7 && GameManager.CaptureMod)
        {
            check2 = true;
            transform.position = Player.transform.position;
        }
        if (check2)
        {
            door.SetTile(new Vector3Int(13, 1, 0), null/*Row*/);
        }
        if (pos.x == -28 && pos.y == 3 && GameManager.CaptureMod)
        {
            check3 = true;
            transform.position = Player.transform.position;
        }
        if (check3)
        {
            door.SetTile(new Vector3Int(-46, -3, 0), null/*Row*/);
            door.SetTile(new Vector3Int(-37, 1, 0), null/*Row*/);
        }
        if (pos.x == -52 && pos.y == -1 && GameManager.CaptureMod)
        {
            check4 = true;
            transform.position = Player.transform.position;
        }
        if (check4)
        {
            door.SetTile(new Vector3Int(-61, 0, 0), null/*Col*/);
            door.SetTile(new Vector3Int(-61, 12, 0), null/*Col*/);
        }
        if (pos.x == 39 && pos.y == -4 && GameManager.CaptureMod)
        {
            check5 = true;
            transform.position = Player.transform.position;
        }
        if (check5)
        {
            door.SetTile(new Vector3Int(28, -3, 0), null/*Row*/);
            door.SetTile(new Vector3Int(62, -3, 0), null/*Row*/);
        }
        if (pos.x == 41 && pos.y == 8 && GameManager.CaptureMod)
        {
            check6 = true;
            transform.position = Player.transform.position;
        }
        if (check6)
        {
            door.SetTile(new Vector3Int(50, 12, 0), null/*Row*/);
            door.SetTile(new Vector3Int(42, 14, 0), null/*Col*/);
        }

        if (Player.transform.position.x == -15 && Player.transform.position.y == 8)
        {
            file.SetTile(new Vector3Int(-15, 8, 0), null);
            door.SetTile(new Vector3Int(-61, -9, 0), null/*Col*/);
            door.SetTile(new Vector3Int(44, 12, 0), null/*Row*/);
            door.SetTile(new Vector3Int(62, 10, 0), null/*Col*/);
        }
        if (Player.transform.position.x == -64 && Player.transform.position.y == 22)
        {
            file.SetTile(new Vector3Int(-64, 22, 0), null);
            door.SetTile(new Vector3Int(-50, 7, 0), null/*Col*/);
            door.SetTile(new Vector3Int(74, 12, 0), null/*Row*/);
        }
        if (Player.transform.position.x == 28 && Player.transform.position.y == 13)
        {
            file.SetTile(new Vector3Int(28, 13, 0), null);
            door.SetTile(new Vector3Int(28, 1, 0), null/*Row*/);
            door.SetTile(new Vector3Int(78, 14, 0), null/*Col*/);
        }


    }

}
