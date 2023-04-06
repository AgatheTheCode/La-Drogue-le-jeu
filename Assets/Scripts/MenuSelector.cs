using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{
    public GameObject CanvaMenu;
    public GameObject CanvaScene;
    public GameObject firstCanvas;
    public GameObject secondCanvas;
    public GameObject thirdCanvas;

    private bool isFirstCanvasShown = true;
    private bool isSecondCanvasShown = false;
    private bool isThirdCanvasShown = false;

    private void Start()
    {
        firstCanvas.SetActive(false);
        secondCanvas.SetActive(false);
        thirdCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (firstCanvas.activeSelf)
            {
                firstCanvas.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                firstCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowFirstCanvas()
    {
        if (!isFirstCanvasShown)
        {
            firstCanvas.SetActive(true);
            isFirstCanvasShown = true;
            isSecondCanvasShown = false;
            isThirdCanvasShown = false;
        }
    }

    public void HideFirstCanvas()
    {
        if (isFirstCanvasShown)
        {
            firstCanvas.SetActive(false);
            isFirstCanvasShown = false;
        }
    }

    public void ShowSecondCanvas()
    {
        if (!isSecondCanvasShown)
        {
            secondCanvas.SetActive(true);
            HideFirstCanvas();
            HideThirdCanvas();
            isFirstCanvasShown = false;
            isSecondCanvasShown = true;
            isThirdCanvasShown = false;
        }
    }

    public void HideSecondCanvas()
    {
        if (isSecondCanvasShown)
        {
            secondCanvas.SetActive(false);
            ShowFirstCanvas();
            isFirstCanvasShown = true;
            isSecondCanvasShown = false;
            isThirdCanvasShown = false;
        }
    }

    public void ShowThirdCanvas()
    {
        if (!isThirdCanvasShown)
        {
            thirdCanvas.SetActive(true);
            HideFirstCanvas();
            HideSecondCanvas();
            isFirstCanvasShown = false;
            isSecondCanvasShown = false;
            isThirdCanvasShown = true;
        }
    }

    public void HideThirdCanvas()
    {
        if (isThirdCanvasShown)
        {
            thirdCanvas.SetActive(false);
            ShowFirstCanvas();
            isFirstCanvasShown = true;
            isSecondCanvasShown = false;
            isThirdCanvasShown = false;
        }
    }
}
