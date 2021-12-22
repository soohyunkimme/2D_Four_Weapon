using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public List<RectTransform> panels;
    private bool isMoveing = false;
    private bool skillMenu = true;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && isMoveing == false)
        {
            if (skillMenu)
            {
                isMoveing = true;
                skillMenu = false;
                Sequence seq = DOTween.Sequence();
                seq.Append(panels[0].DOAnchorPosX(-1920, 1f));
                seq.Join(panels[1].DOAnchorPosX(0, 1f));
                seq.OnComplete(() => isMoveing = false);
            }
            else
            {
                isMoveing = true;
                skillMenu = true;
                Sequence seq = DOTween.Sequence();
                seq.Append(panels[0].DOAnchorPosX(0, 1f));
                seq.Join(panels[1].DOAnchorPosX(1920, 1f));
                seq.OnComplete(() => isMoveing = false);
            }
        }
    }


}
