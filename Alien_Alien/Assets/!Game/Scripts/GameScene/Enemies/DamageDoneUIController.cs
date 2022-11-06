using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageDoneUIController : MonoBehaviour
{
    private void Start()
    {
        Destroy(this, 3);
        
        var text = this.GetComponent<TMP_Text>();
        transform.DOLocalMoveY(transform.position.y + 1, 3f, false);
        transform.DOScale(2f, 3f).SetEase(Ease.OutQuart);
        text.DOFade(0, 2.5f);
    }
}
