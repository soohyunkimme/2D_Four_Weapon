using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject GamePanel;
    public Text titleText;

    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(DOTween.To(() => titleText.fontSize, (x) => titleText.fontSize = x, 150, 0.5f)).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(GamePanel.GetComponent<Image>().DOFade(1, 1f));
            seq.OnComplete(() => GameManager.Instance.ChangeScene("MenuScene"));
        }
    }
}
