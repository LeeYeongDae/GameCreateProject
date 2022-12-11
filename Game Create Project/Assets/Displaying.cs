using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Displaying : MonoBehaviour
{
    public static float alpha = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (alpha > 1) alpha = 1;
        Display();
    }

    void Display()
    {
        Image image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, (alpha * 2));

        Text[] allChildren = GetComponentsInChildren<Text>();
        foreach (Text text in allChildren)
        {
            // �ڱ� �ڽ��� ��쿣 ���� 
            // (���ӿ�����Ʈ���� �� �ٸ��ٰ� �������� �� ���ϴ� �ڵ�)
            //if (child.name == transform.name)
            //    return;

            //Text text = child.gameObject.GetComponent<Text>();
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }
    }
}
