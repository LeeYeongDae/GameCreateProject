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
    public bool OnClicked;
    public bool isWalked = false;
    public float runGage = 10;
    Vector3 lastPos;
    Camera Camera;
    GameObject Touch;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        OnClicked = false;
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Touch = GameObject.Find("Destination");
    }

    // Update is called once per frame
    void Update()
    {
        path = GameObject.Find("GameManager").GetComponent<GameManager>().FinalNodeList;

        if (lastPos != transform.localPosition)
        {
            lastPos = transform.localPosition;
            isWalked = true;
        }
        else isWalked = false;

        if (GameManager.CaptureMod)
        {
            speed = 0f;
            setNum = num;
            if (Input.GetKeyDown(KeyCode.C)) Touch.transform.position = transform.position;
        }
        else
        {
            if (Input.GetKey(KeyCode.R) && runGage > 0)
                speed = 6f;
            else
            speed = 3f;
        }
            
        PlayerMove();
        if (transform.position.x == -20)
        {
            num++;
            this.transform.position = new Vector2(-24, -1);
            nextPos = new Vector2(-24, -1);
            Camera.transform.position = new Vector3(-36, 0, -10);
        }
        if (transform.position.x == -23)
        {
            num++;
            this.transform.position = new Vector2(-19, -1);
            nextPos = new Vector2(-19, -1);
            Camera.transform.position = new Vector3(-7, 0, -10);
        }
        if (transform.position.x == 19)
        {
            num++;
            this.transform.position = new Vector2(23, -1);
            nextPos = new Vector2(23, -1);
            Camera.transform.position = new Vector3(35, 0, -10);
        }
        if (transform.position.x == 22)
        {
            num++;
            this.transform.position = new Vector2(18, -1);
            nextPos = new Vector2(18, -1);
            Camera.transform.position = new Vector3(6, 0, -10);
        }
    }

    void FixedUpdate()
    {
        if(!GameManager.CaptureMod)
        {
            if (Input.GetKey(KeyCode.R) && runGage > 0 && isWalked)
                runGage -= Time.deltaTime;
            else if (runGage < 10)
                runGage += 3 * Time.deltaTime;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            GameManager.isClear = true;
        }
    }
}