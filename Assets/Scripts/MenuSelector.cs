using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;

    private bool isCanvas1Shown = true;
    private bool isCanvas2Shown = false;
    private bool isCanvas3Shown = false;

    private string sceneName = "Scene1";
    private string sceneName2 = "Scene2";
    private string sceneName3 = "Scene3";
    private string sceneName4 = "Scene4";

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");
            // Si les trois canvas sont visibles, on les cache tous
            if (isCanvas1Shown || isCanvas2Shown || isCanvas3Shown)
            {
                canvas1.SetActive(false);
                canvas2.SetActive(false);
                canvas3.SetActive(false);
                isCanvas1Shown = false;
                isCanvas2Shown = false;
                isCanvas3Shown = false;
            }
            // Sinon, on affiche le premier canvas
            else
            {
                canvas1.SetActive(true);
                canvas2.SetActive(false);
                canvas3.SetActive(false);
                isCanvas1Shown = true;
                isCanvas2Shown = false;
                isCanvas3Shown = false;
            }
        }
    }

    public void ShowCanvas1()
    {
        Debug.Log("show canvas 1");
        if (!isCanvas1Shown)
        {
            canvas1.SetActive(true);
            canvas2.SetActive(false);
            canvas3.SetActive(false);
            isCanvas1Shown = true;
            isCanvas2Shown = false;
            isCanvas3Shown = false;
        }
    }

    public void ShowCanvas2()
    {
        if (!isCanvas2Shown)
        {
            canvas2.SetActive(true);
            canvas1.SetActive(false);
            canvas3.SetActive(false);
            isCanvas1Shown = false;
            isCanvas2Shown = true;
            isCanvas3Shown = false;
        }
    }

    public void ShowCanvas3()
    {
        if (!isCanvas3Shown)
        {
            canvas3.SetActive(true);
            canvas1.SetActive(false);
            canvas2.SetActive(false);
            isCanvas1Shown = false;
            isCanvas2Shown = false;
            isCanvas3Shown = true;
        }
    }

        public void HideCanvas1()
    {
        if (isCanvas1Shown)
        {
            canvas1.SetActive(false);
            isCanvas1Shown = false;
        }
    }
        public void LoadScene()
    {
        // Charger la scène correspondante au nom donné
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene2()
    {
        // Charger la scène correspondante au nom donné
        SceneManager.LoadScene(sceneName2);
    }

    public void LoadScene3()
    {
        // Charger la scène correspondante au nom donné
        SceneManager.LoadScene(sceneName3);
    }
    public void LoadScene4()
    {
        // Charger la scène correspondante au nom donné
        SceneManager.LoadScene(sceneName4);
    }

    public void QuitGame()
    {
        // Quitter le jeu
        Application.Quit();
    }
}