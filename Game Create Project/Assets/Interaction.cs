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
    bool check3 = false;
    bool check4 = false;
    bool check5 = false;
    bool check6 = false;
    public Grid grid;
    public Tilemap wall;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CaptureMod = GameObject.Find("GameManager").GetComponent<GameManager>().CaptureMod;
        pos = transform.position;
        if (pos.x == -12 && pos.y == -4 && CaptureMod)
        {
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
            check2 = true;
            transform.position = Player.transform.position;
        }
        if (check2)
        {
            wall.SetTile(new Vector3Int(13, 1, 0), null);
        }
        if (pos.x == -28 && pos.y == 3 && CaptureMod)
        {
            check3 = true;
            transform.position = Player.transform.position;
        }
        if (check3)
        {
            wall.SetTile(new Vector3Int(-46, -3, 0), null);
            wall.SetTile(new Vector3Int(-37, 1, 0), null);
        }
        if (pos.x == -52 && pos.y == -1 && CaptureMod)
        {
            check4 = true;
            transform.position = Player.transform.position;
        }
        if (check4)
        {
            wall.SetTile(new Vector3Int(-61, 0, 0), null);
            wall.SetTile(new Vector3Int(-61, 12, 0), null);
        }
        if (pos.x == 39 && pos.y == -4 && CaptureMod)
        {
            check5 = true;
            transform.position = Player.transform.position;
        }
        if (check5)
        {
            wall.SetTile(new Vector3Int(28, -3, 0), null);
            wall.SetTile(new Vector3Int(62, -3, 0), null);
        }
        if (pos.x == 41 && pos.y == 8 && CaptureMod)
        {
            check6 = true;
            transform.position = Player.transform.position;
        }
        if (check6)
        {
            wall.SetTile(new Vector3Int(50, 12, 0), null);
            wall.SetTile(new Vector3Int(42, 14, 0), null);
        }
    }

}
