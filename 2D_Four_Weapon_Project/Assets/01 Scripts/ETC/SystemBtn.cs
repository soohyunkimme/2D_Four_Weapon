using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemBtn : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause()
    {
        if (!PausePanel.activeSelf)
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            PausePanel.SetActive(false);
        }
    }

    public void GameOut()
    {
        GameManager.Instance.ChangeScene("MenuScene");
    }
}
