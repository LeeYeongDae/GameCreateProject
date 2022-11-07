using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 currPosition, nextPos;
    public float speed = 3f;
    public List<Node> path;
    public int num;
    public int setNum;
    public bool CaptureMod;
    public bool OnClicked;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        OnClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        CaptureMod = GameObject.Find("GameManager").GetComponent<GameManager>().CaptureMod;
        path = GameObject.Find("GameManager").GetComponent<GameManager>().FinalNodeList;
        if (CaptureMod)
        {
            speed = 0f;
            setNum = num;
        }
        else speed = 3f;
        PlayerMove();
        if (transform.position.x == -20)
        {
            num++;
            this.transform.position = new Vector2(-24, -1);
            nextPos = new Vector2(-24, -1);
        }
        if (transform.position.x == 20)
        {
            num++;
            this.transform.position = new Vector2(24, -1);
            nextPos = new Vector2(24, -1);
        }
    }

    void PlayerMove()
    {
        if (OnClicked)
        {
            setNum = path.Count;
            OnClicked = false;
        }
        currPosition = transform.position;
        nextPos = new Vector2(path[num].x, path[num].y);
        float walk = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(currPosition, nextPos, walk);
        if (currPosition == nextPos)
        {
            if (num < setNum) num++;
        }
    }
}