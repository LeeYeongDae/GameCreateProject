using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Password : MonoBehaviour
{
    GameObject PW, File, Info;
    GameObject SPW, Secret, Desc, Cover;
    RectTransform filerect, secrect;
    Text password, security;
    Image coverim;
    public float hacktime, readtime;
    public bool turnon, uncover, hacking, reading;
    float opentime, unfoldtime;

    // Start is called before the first frame update
    void Awake()
    {
        PW = GameObject.Find("PW");
        Info = GameObject.Find("Info");
        File = GameObject.Find("File");
        filerect = File.GetComponent<RectTransform>();
        Info.SetActive(false);
        File.SetActive(false);
        password = PW.GetComponent<Text>();
        password.text = "8 8 8 8";
        
        SPW = GameObject.Find("SPW");
        Secret = GameObject.Find("Secret");
        Desc = GameObject.Find("Desc");
        Cover = GameObject.Find("Cover");
        secrect = Secret.GetComponent<RectTransform>();
        coverim = Cover.GetComponent<Image>();
        Desc.SetActive(false);
        Secret.SetActive(false);
        security = SPW.GetComponent<Text>();
        security.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (opentime >= 1) opentime = (int)1;
        else if (opentime <= 0) opentime = (int)0;
        Hack();
        Read();
    }

    void Hack()
    {
        int hacknum = (int)hacktime;
        if (turnon) Displaying.alpha = hacktime;
        if (!Interaction.hack1 && !Interaction.hack2 && !Interaction.hack3 && !Interaction.hack4 && !Interaction.hack5 && !Interaction.hack6)
        {
            password.text = "8 8 8 8";
            opentime = 0f;
            hacktime = 0f;
            Info.gameObject.SetActive(false);
            File.SetActive(false);
            hacking = false;
        }
        else
        {
            File.SetActive(true);
            opentime += 2 * Time.deltaTime;
            filerect.localScale = new Vector3(opentime, opentime, filerect.localScale.z);
            StartCoroutine(Scan());
            if (hacking)
            {
                Info.SetActive(true);
                hacktime += 2 * Time.deltaTime;
                if (hacktime < 6f) turnon = true;
            }
        }
        if (hacknum >= 4) hacknum = 4;
        if (hacktime >= 6f)
        {
            turnon = false;
            opentime -= 4 * Time.deltaTime;
            Displaying.alpha -= 8 * Time.deltaTime;
            if (hacktime >= 7f)
            {
                if (Interaction.hack1) Interaction.hack1 = false;
                if (Interaction.hack2) Interaction.hack2 = false;
                if (Interaction.hack3) Interaction.hack3 = false;
                if (Interaction.hack4) Interaction.hack4 = false;
                if (Interaction.hack5) Interaction.hack5 = false;
                if (Interaction.hack6) Interaction.hack6 = false;
            }
        }
        if (Interaction.hack1)
        {
            if (hacknum == 1) password.text = "4 8 8 8";
            if (hacknum == 2) password.text = "4 5 8 8";
            if (hacknum == 3) password.text = "4 5 7 8";
            if (hacknum == 4) password.text = "4 5 7 8";
        }
        if (Interaction.hack2)
        {
            if (hacknum == 1) password.text = "1 8 8 8";
            if (hacknum == 2) password.text = "1 7 8 8";
            if (hacknum == 3) password.text = "1 7 5 8";
            if (hacknum == 4) password.text = "1 7 5 3";
        }
        if (Interaction.hack3)
        {
            if (hacknum == 1) password.text = "1 8 8 8";
            if (hacknum == 2) password.text = "1 2 8 8";
            if (hacknum == 3) password.text = "1 2 0 8";
            if (hacknum == 4) password.text = "1 2 0 1";
        }
        if (Interaction.hack4)
        {
            if (hacknum == 1) password.text = "0 8 8 8";
            if (hacknum == 2) password.text = "0 9 8 8";
            if (hacknum == 3) password.text = "0 9 0 8";
            if (hacknum == 4) password.text = "0 9 0 6";
        }
        if (Interaction.hack5)
        {
            if (hacknum == 1) password.text = "0 8 8 8";
            if (hacknum == 2) password.text = "0 5 8 8";
            if (hacknum == 3) password.text = "0 5 1 8";
            if (hacknum == 4) password.text = "0 5 1 6";
        }
        if (Interaction.hack6)
        {
            if (hacknum == 1) password.text = "9 8 8 8";
            if (hacknum == 2) password.text = "9 4 8 8";
            if (hacknum == 3) password.text = "9 4 7 8";
            if (hacknum == 4) password.text = "9 4 7 2";
        }
    }

    IEnumerator Scan()
    {
        yield return new WaitForSeconds(0.5f);
        hacking = true;
    }

    void Read()
    {
        //if (uncover) Displaying.alpha = readtime;
        if (unfoldtime > 1f) unfoldtime = (int)1;
        else if (unfoldtime <= 0f) unfoldtime = (int)0;
        float salpha = (1 - readtime);
        if (salpha < 0) salpha = 0;
        if (!Interaction.read1 && !Interaction.read2 && !Interaction.read3)
        {
            security.text = "";
            unfoldtime = 0f;
            readtime = 0f;
            Desc.SetActive(false);
            Secret.SetActive(false);
            reading = false;
        }
        else
        {
            Secret.SetActive(true);
            unfoldtime += 2 * Time.deltaTime;
            if (unfoldtime <= 0 || unfoldtime >= 1f) secrect.localScale = new Vector3((int)unfoldtime, (int)unfoldtime, secrect.localScale.z);
            else secrect.localScale = new Vector3(unfoldtime, unfoldtime, secrect.localScale.z);
            StartCoroutine(Slide());
            if (reading)
            {
                Desc.SetActive(true);
                coverim.color = new Color(coverim.color.r, coverim.color.g, coverim.color.b, salpha);
                readtime += 2 * Time.deltaTime;
                if (readtime < 6f) uncover = true;
            }
        }
        if (readtime >= 6f)
        {
            uncover = false;
            coverim.color = new Color(coverim.color.r, coverim.color.g, coverim.color.b, 0);
            unfoldtime -= 4 * Time.deltaTime;
            if (readtime >= 7f)
            {
                if (Interaction.read1) Interaction.read1 = false;
                if (Interaction.read2) Interaction.read2 = false;
                if (Interaction.read3) Interaction.read3 = false;
            }
        }
        if (Interaction.read1) security.text = "5 7 3 6";
        if (Interaction.read2) security.text = "3 0 4 9";
        if (Interaction.read3) security.text = "8 8 1 2";
    }
    IEnumerator Slide()
    {
        yield return new WaitForSeconds(0.5f);
        reading = true;
    }
}
