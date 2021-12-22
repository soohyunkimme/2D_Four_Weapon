using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn.onClick.AddListener(() => GameManager.Instance.ChangeScene("GameScene"));
    }
}
