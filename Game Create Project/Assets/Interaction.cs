using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool CaptureMod;
    private Vector2 pos;
    bool check1 = false;
    bool check2 = false;
    int password1 = 1136;
    int password2 = 4423;

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
            print("��й�ȣ�� " + password1);
            check1 = true;
            pos.x = 0;
            pos.y = 0;
            transform.position = pos;
        }
        if (check1)
        {
            //Layer.removeTileAt(tilePos);
        }
        if (pos.x == 7 && pos.y == 7 && CaptureMod)
        {
            print("��й�ȣ�� " + password2);
            check2 = true;
            pos.x = 0;
            pos.y = 0;
            transform.position = pos;
        }
        if (check2)
        {
            check2 = false;
        }
    }

}
