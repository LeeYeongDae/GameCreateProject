using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    RectTransform Cam;
    float starttime;
    bool Pressed;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        starttime = 0f;
        Pressed = false;
        Cam = GameObject.Find("Cam").GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Pressed)
        {
            starttime += 25 * Time.deltaTime;
            Cam.localScale = new Vector3(starttime, starttime, Cam.localScale.z);
        }
    }

    public void Main()
    {
        StartCoroutine(MainMenu());
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }

    public void Game()
    {
        Pressed = true;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
