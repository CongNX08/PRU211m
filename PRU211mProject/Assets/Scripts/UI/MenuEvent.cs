using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuEvent : MonoBehaviour
{
    public GameObject gameoverPanel;
    public void Play(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ReStartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Character");
    }

    public void ShowGameoverPanel(bool isShow)
    {
        gameoverPanel.SetActive(isShow);
    }
}
