using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static bool isOver;
    public static bool CaptureMod;
    public Vector2Int bottomLeft, topRight;
    public Vector2 startPos, targetPos;
    public List<Node> FinalNodeList;
    public bool allowDiagonal, dontCrossCorner;
    public GameObject Capture;
    public GameObject Player;
    public GameObject Touch;
    int sizeX, sizeY;
    Node[,] NodeArray;
    Node StartNode, TargetNode, CurNode;
    List<Node> OpenList, ClosedList ;
    Camera Camera;
    Animator Capanim;

    private void Awake()
    {
        CaptureMod = false;
        Capture = GameObject.Find("Capture");
        Capture.SetActive(false);
        Player = GameObject.Find("Player");
        Touch = GameObject.Find("TouchPin");
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Capanim = Capture.GetComponent<Animator>();
    }

    void Update()
    {
        if (isOver) Time.timeScale = 0f;
        startPos = Player.transform.position;
        ChangeRoom();
        if (Input.GetKeyDown(KeyCode.C))
        {
           if(!CaptureMod)
            {
                Capture.SetActive(true);
                Capanim.SetBool("isMod", true);
                CaptureMod = true;
            }
           else
            {
                Capanim.SetBool("isMod", false);
                StartCoroutine(Off());
            }
        }
        SetTarget();
    }

    void SetTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Player.GetComponent<Player>().num = 1;
            targetPos = Input.mousePosition;
            targetPos = Camera.ScreenToWorldPoint(targetPos);
            if (targetPos.x >= 0)
            {
                if (targetPos.y >= 0)
                    targetPos = new Vector2((int)(targetPos.x + 0.5f), (int)(targetPos.y + 0.5f));
                else
                    targetPos = new Vector2((int)(targetPos.x + 0.5f), (int)(targetPos.y - 0.5f));
            }
            else
            {
                if (targetPos.y >= 0)
                    targetPos = new Vector2((int)(targetPos.x - 0.5f), (int)(targetPos.y + 0.5f));
                else
                    targetPos = new Vector2((int)(targetPos.x - 0.5f), (int)(targetPos.y - 0.5f));
            }

            Touch.transform.position = targetPos;

            if (!CaptureMod)
            {
                Player.GetComponent<Player>().OnClicked = true;
                PathFinding();
            }
            else if (CaptureMod)
                Interact();
        }
    }

    void Interact()
    {
        
    }

    void ChangeRoom()
    {
        if (Player.transform.position.x < -20)
        {
            bottomLeft = new Vector2Int(-66, -11);
            topRight = new Vector2Int(-23, 25);
        }

        else if (Player.transform.position.x > 20)
        {
            bottomLeft = new Vector2Int(22, -13);
            topRight = new Vector2Int(81, 16);
        }

        else
        {
            bottomLeft = new Vector2Int(-20, -17);
            topRight = new Vector2Int(20, 10);
        }
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.55f);
        Capture.SetActive(false);
        CaptureMod = false;
    }

    public void PathFinding()
    {
        // NodeArray의 크기 정해주고, isWall, x, y 대입
        sizeX = topRight.x - bottomLeft.x + 1;
        sizeY = topRight.y - bottomLeft.y + 1;
        NodeArray = new Node[sizeX, sizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                bool isWall = false;
                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i + bottomLeft.x, j + bottomLeft.y), 0.4f))
                    if (col.gameObject.layer == LayerMask.NameToLayer("Wall")) isWall = true;

                NodeArray[i, j] = new Node(isWall, i + bottomLeft.x, j + bottomLeft.y);
            }
        }
        

        // 시작과 끝 노드, 열린리스트와 닫힌리스트, 마지막리스트 초기화

        StartNode = NodeArray[(int)(startPos.x) - bottomLeft.x, (int)(startPos.y) - bottomLeft.y];
        TargetNode = NodeArray[(int)(targetPos.x) - bottomLeft.x, (int)(targetPos.y) - bottomLeft.y];

        OpenList = new List<Node>() { StartNode };
        ClosedList = new List<Node>();
        FinalNodeList = new List<Node>();

        
        while (OpenList.Count > 0)
        {
            // 열린리스트 중 가장 F가 작고 F가 같다면 H가 작은 걸 현재노드로 하고 열린리스트에서 닫힌리스트로 옮기기
            CurNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
                if (OpenList[i].F <= CurNode.F && OpenList[i].H < CurNode.H) CurNode = OpenList[i];

            OpenList.Remove(CurNode);
            ClosedList.Add(CurNode);


            // 마지막
            if (CurNode == TargetNode)
            {
                Node TargetCurNode = TargetNode;
                while (TargetCurNode != StartNode)
                {
                    FinalNodeList.Add(TargetCurNode);
                    TargetCurNode = TargetCurNode.ParentNode;
                }
                FinalNodeList.Add(StartNode);
                FinalNodeList.Reverse();

                for (int i = 0; i < FinalNodeList.Count; i++) print(i + "번째는 " + FinalNodeList[i].x + ", " + FinalNodeList[i].y);
                return;
            }


            // ↗↖↙↘
            if (allowDiagonal)
            {
                OpenListAdd(CurNode.x + 1, CurNode.y + 1);
                OpenListAdd(CurNode.x - 1, CurNode.y + 1);
                OpenListAdd(CurNode.x - 1, CurNode.y - 1);
                OpenListAdd(CurNode.x + 1, CurNode.y - 1);
            }

            // ↑ → ↓ ←
            OpenListAdd(CurNode.x, CurNode.y + 1);
            OpenListAdd(CurNode.x + 1, CurNode.y);
            OpenListAdd(CurNode.x, CurNode.y - 1);
            OpenListAdd(CurNode.x - 1, CurNode.y);
        }
    }

    void OpenListAdd(int checkX, int checkY)
    {
        // 상하좌우 범위를 벗어나지 않고, 벽이 아니면서, 닫힌리스트에 없다면
        if (checkX >= bottomLeft.x && checkX < topRight.x + 1 && checkY >= bottomLeft.y && checkY < topRight.y + 1 
            && !NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y].isWall 
            && !ClosedList.Contains(NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y]))
        {
            // 대각선 허용시, 벽 사이로 통과 안됨
            if (allowDiagonal) 
                if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall 
                    && NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;

            // 코너를 가로질러 가지 않을시, 이동 중에 수직수평 장애물이 있으면 안됨
            if (dontCrossCorner)
                if (NodeArray[CurNode.x - bottomLeft.x, checkY - bottomLeft.y].isWall 
                    || NodeArray[checkX - bottomLeft.x, CurNode.y - bottomLeft.y].isWall) return;

            
            // 이웃노드에 넣고, 직선은 10, 대각선은 14비용
            Node NeighborNode = NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y];
            int MoveCost = CurNode.G + (CurNode.x - checkX == 0 || CurNode.y - checkY == 0 ? 10 : 14);


            // 이동비용이 이웃노드G보다 작거나 또는 열린리스트에 이웃노드가 없다면 G, H, ParentNode를 설정 후 열린리스트에 추가
            if (MoveCost < NeighborNode.G || !OpenList.Contains(NeighborNode))
            {
                NeighborNode.G = MoveCost;
                NeighborNode.H = (Mathf.Abs(NeighborNode.x - TargetNode.x) + Mathf.Abs(NeighborNode.y - TargetNode.y)) * 10;
                NeighborNode.ParentNode = CurNode;

                OpenList.Add(NeighborNode);
            }
        }
    }

    void OnDrawGizmos()
    {
        if(FinalNodeList.Count != 0) for (int i = 0; i < FinalNodeList.Count - 1; i++)
                Gizmos.DrawLine(new Vector2(FinalNodeList[i].x, FinalNodeList[i].y), new Vector2(FinalNodeList[i + 1].x, FinalNodeList[i + 1].y));
    }
}
