using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    GameObject player, speak;
    Camera Camera;
    public bool start = true;
    public bool talk, spend;
    public Text script;
    string[] ment;
    int scriptnum;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speak = GameObject.Find("Speak");
        script = GameObject.Find("Speak").GetComponent<Text>();
        speak.SetActive(false);
        Camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        ment[0] = "��~...";
        ment[1] = "��ǥ �ǹ� ���η� �����µ� �����ߴ�.";
        ment[2] = "�̹� �ӹ��� ������ ��Ʈ�ʰ� �����̶� �ϴ���...";
        ment[3] = "Ȥ�� Ʃ�丮���� �ʿ��Ѱ�?";
        ment[4] = "........";
        ment[5] = "..��, ������ȭ�� �Ϲ������� ���� �����߱�.";
        ment[6] = "�׷� �� ���� ���� ī�޶� �����������";
        ment[7] = "Ʃ�丮���� �ʿ��Ѱ�?";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currPosition = player.transform.position;
        if(player.transform.position != new Vector3(0, 0, player.transform.position.z))
            player.transform.position = Vector2.MoveTowards(currPosition, new Vector2(0, 0), 3f * Time.deltaTime);
        if (Camera.transform.position != new Vector3(0, 0, Camera.transform.position.z) && player.transform.position.y >= -11 && start)
        {
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, player.transform.position, 4f * Time.deltaTime);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, -10);
        }
        if (Camera.transform.position == new Vector3(0, 0, Camera.transform.position.z)) start = false;

        if (currPosition == new Vector2(0, 0)) talk = true;
    }

    void FixedUpdate()
    {
        if (talk)
        {
            speak.SetActive(true);
            if (script.text == ment[scriptnum]) spend = true;
            else spend = false;
            if (!spend)
            {
                if (Input.anyKeyDown) script.text = ment[scriptnum];
                else StartCoroutine(Texting(ment[scriptnum]));
            }
            else
                if (Input.anyKeyDown)
            {
                scriptnum++;
                script.text = "";
            }
        }
            
    }

    IEnumerator Texting(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            script.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
