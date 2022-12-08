using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    GameObject PW, File, Info;
    public Text password;
    public int num;
    public float hacktime;
    //public bool hack1, hack2, hack3, hack4, hack5, hack6;

    // Start is called before the first frame update
    void Awake()
    {
        PW = GameObject.Find("PW");
        Info = GameObject.Find("Info");
        File = GameObject.Find("File");
        Info.gameObject.SetActive(false);
        File.SetActive(false);
        password = PW.GetComponent<Text>();
        password.text = "8 8 8 8";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Interaction.hack1 || Interaction.hack2 || Interaction.hack3 || Interaction.hack4 || Interaction.hack5 || Interaction.hack6)
        {
            File.SetActive(true);
            Info.gameObject.SetActive(true);
            hacktime += 2 * Time.deltaTime;
        }
        num = (int)hacktime;
        if (num >= 4) num = 4;
        if (hacktime >= 6f)
        {
            if (Interaction.hack1) Interaction.hack1 = false;
            if (Interaction.hack2) Interaction.hack2 = false;
            if (Interaction.hack3) Interaction.hack3 = false;
            if (Interaction.hack4) Interaction.hack4 = false;
            if (Interaction.hack5) Interaction.hack5 = false;
            if (Interaction.hack6) Interaction.hack6 = false;
            hacktime = 0f;
        }
        if (Interaction.hack1)
        {
            if (num == 1) password.text = "4 8 8 8";
            if (num == 2) password.text = "4 5 8 8";
            if (num == 3) password.text = "4 5 7 8";
            if (num == 4) password.text = "4 5 7 8";
        }
        if (Interaction.hack2)
        {
            if (num == 1) password.text = "1 8 8 8";
            if (num == 2) password.text = "1 7 8 8";
            if (num == 3) password.text = "1 7 5 8";
            if (num == 4) password.text = "1 7 5 3";
        }
        if (Interaction.hack3)
        {
            if (num == 1) password.text = "1 8 8 8";
            if (num == 2) password.text = "1 2 8 8";
            if (num == 3) password.text = "1 2 0 8";
            if (num == 4) password.text = "1 2 0 1";
        }
        if (Interaction.hack4)
        {
            if (num == 1) password.text = "0 8 8 8";
            if (num == 2) password.text = "0 9 8 8";
            if (num == 3) password.text = "0 9 0 8";
            if (num == 4) password.text = "0 9 0 6";
        }
        if (Interaction.hack5)
        {
            if (num == 1) password.text = "0 8 8 8";
            if (num == 2) password.text = "0 5 8 8";
            if (num == 3) password.text = "0 5 1 8";
            if (num == 4) password.text = "0 5 1 6";
        }
        if (Interaction.hack6)
        {
            if (num == 1) password.text = "9 8 8 8";
            if (num == 2) password.text = "9 4 8 8";
            if (num == 3) password.text = "9 4 7 8";
            if (num == 4) password.text = "9 4 7 2";
        }
        if (!Interaction.hack1 && !Interaction.hack2 && !Interaction.hack3 && !Interaction.hack4 && !Interaction.hack5 && !Interaction.hack6)
        {
            password.text = "8 8 8 8";
            num = 0;
            Info.gameObject.SetActive(false);
            File.SetActive(false);
        }
    }
}
