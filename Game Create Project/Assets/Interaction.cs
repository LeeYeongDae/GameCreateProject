using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interaction : MonoBehaviour
{
    private Vector2 pos;
    public bool check1, check2, check3, check4, check5, check6;
    public bool checkS1, checkS2, checkS3;
    public Grid grid;
    public Tilemap door, file;
    public TileBase Col, Row;
    public static bool hack1, hack2, hack3, hack4, hack5, hack6;
    public static bool read1, read2, read3;
    GameObject Player, open, hack, read;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        open = GameObject.Find("Open");
        open.SetActive(false);
        hack = GameObject.Find("Hacked");
        hack.SetActive(false);
        read = GameObject.Find("Read");
        read.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (pos.x == -12 && pos.y == -4 && GameManager.CaptureMod)
        {
            check1 = true;
            hack1 = true;
            StartCoroutine(Sound(hack));
            transform.position = Player.transform.position;
            door.SetTile(new Vector3Int(-14, 1, 0), Row);
        }
        if (check1)
        {
            if (Vector3.Distance(new Vector3Int(-14, 1, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(-14, 1, 0), null);
                StartCoroutine(Sound(open));
                check1 = false;
            }
        }

        if (pos.x == 7 && pos.y == 7 && GameManager.CaptureMod)
        {
            check2 = true;
            hack2 = true;
            StartCoroutine(Sound(hack));
            transform.position = Player.transform.position;
            door.SetTile(new Vector3Int(13, 1, 0), Row);
        }
        if (check2)
        {
            if (Vector3.Distance(new Vector3Int(13, 1, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(13, 1, 0), null);
                StartCoroutine(Sound(open));
                check2 = false;
            }
        }

        if (pos.x == -28 && pos.y == 3 && GameManager.CaptureMod)
        {
            check3 = true;
            hack3 = true;
            StartCoroutine(Sound(hack));
            transform.position = Player.transform.position;
            door.SetTile(new Vector3Int(-46, -3, 0), Row);
            door.SetTile(new Vector3Int(-37, 1, 0), Row);
        }
        if (check3)
        {
            if (Vector3.Distance(new Vector3Int(-46, -3, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(-46, -3, 0), null);
                StartCoroutine(Sound(open));
            }
            if (Vector3.Distance(new Vector3Int(-37, 1, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(-37, 1, 0), null);
                StartCoroutine(Sound(open));
            }
        }

        if (pos.x == -52 && pos.y == -1 && GameManager.CaptureMod)
        {
            check4 = true;
            hack4 = true;
            StartCoroutine(Sound(hack));
            transform.position = Player.transform.position;
            door.SetTile(new Vector3Int(-61, 0, 0), Col);
            door.SetTile(new Vector3Int(-61, 12, 0), Col);
        }
        if (check4)
        {
            if (Vector3.Distance(new Vector3Int(-61, 0, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(-61, 0, 0), null);
                StartCoroutine(Sound(open));
            }
            if (Vector3.Distance(new Vector3Int(-61, 12, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(-61, 12, 0), null);
                StartCoroutine(Sound(open));
            }
        }

        if (pos.x == 39 && pos.y == -4 && GameManager.CaptureMod)
        {
            check5 = true;
            hack5 = true;
            StartCoroutine(Sound(hack));
            transform.position = Player.transform.position;
            door.SetTile(new Vector3Int(28, -3, 0), Row);
            door.SetTile(new Vector3Int(62, -3, 0), Row);
        }
        if (check5)
        {
            if (Vector3.Distance(new Vector3Int(28, -3, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(28, -3, 0), null);
                StartCoroutine(Sound(open));
            }
            if (Vector3.Distance(new Vector3Int(62, -3, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(62, -3, 0), null);
                StartCoroutine(Sound(open));
            }
        }

        if (pos.x == 41 && pos.y == 8 && GameManager.CaptureMod)
        {
            check6 = true;
            hack6 = true;
            StartCoroutine(Sound(hack));
            transform.position = Player.transform.position;
            door.SetTile(new Vector3Int(50, 12, 0), Row);
            door.SetTile(new Vector3Int(42, 14, 0), Col);
        }
        if (check6)
        {
            if (Vector3.Distance(new Vector3Int(50, 12, 0), Player.transform.position) < 1.5f)
            {    
                door.SetTile(new Vector3Int(50, 12, 0), null);
                StartCoroutine(Sound(open));
            }
        if (Vector3.Distance(new Vector3Int(42, 14, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(42, 14, 0), null);
                StartCoroutine(Sound(open));
            }
        }

        if (Player.transform.position.x == -15 && Player.transform.position.y == 8 && !checkS1)
        {
            checkS1 = true;
            read1 = true;
            StartCoroutine(Sound(read));
            file.SetTile(new Vector3Int(-15, 8, 0), null);
            door.SetTile(new Vector3Int(-61, -9, 0), Col);
            door.SetTile(new Vector3Int(44, 12, 0), Row);
            door.SetTile(new Vector3Int(62, 10, 0), Col);
        }
        if (checkS1)
        {
            if (Vector3.Distance(new Vector3Int(-61, -9, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(-61, -9, 0), null);
                StartCoroutine(Sound(open));
            }
            if (Vector3.Distance(new Vector3Int(44, 12, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(44, 12, 0), null);
                StartCoroutine(Sound(open));
            }
            if (Vector3.Distance(new Vector3Int(62, 10, 0), Player.transform.position) < 1.5f)
            {
                door.SetTile(new Vector3Int(62, 10, 0), null);
                StartCoroutine(Sound(open));
            }
        }

        if (Player.transform.position.x == -64 && Player.transform.position.y == 22 && !checkS2)
        {
            checkS2 = true;
            read2 = true;
            StartCoroutine(Sound(read));
            file.SetTile(new Vector3Int(-64, 22, 0), null);
            door.SetTile(new Vector3Int(-50, 7, 0), Col);
            door.SetTile(new Vector3Int(74, 12, 0), Row);
        }
        if (checkS2)
        {
            if (Vector3.Distance(new Vector3Int(-50, 7, 0), Player.transform.position) < 1.5f)
                door.SetTile(new Vector3Int(-50, 7, 0), null);
            if (Vector3.Distance(new Vector3Int(74, 12, 0), Player.transform.position) < 1.5f)
                 door.SetTile(new Vector3Int(74, 12, 0), null);
        }

        if (Player.transform.position.x == 28 && Player.transform.position.y == 13 && !checkS3)
        {
            checkS3 = true;
            read3 = true;
            StartCoroutine(Sound(read));
            file.SetTile(new Vector3Int(28, 13, 0), null);
            door.SetTile(new Vector3Int(28, 1, 0), Row);
            door.SetTile(new Vector3Int(78, 14, 0), Col);
        }
        if (checkS3)
        {
            if (Vector3.Distance(new Vector3Int(28, 1, 0), Player.transform.position) < 1.5f)
                door.SetTile(new Vector3Int(28, 1, 0), null);
            if (Vector3.Distance(new Vector3Int(78, 14, 0), Player.transform.position) < 1.5f)
                door.SetTile(new Vector3Int(78, 14, 0), null);
        }


    }
    IEnumerator Sound(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
