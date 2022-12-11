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
            // 자기 자신의 경우엔 무시 
            // (게임오브젝트명이 다 다르다고 가정했을 때 통하는 코드)
            //if (child.name == transform.name)
            //    return;

            //Text text = child.gameObject.GetComponent<Text>();
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }
    }
}
