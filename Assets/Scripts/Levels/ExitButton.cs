using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;
using DG.Tweening;
using TMPro;

public class ExitButton : InteractiveBehaviour
{

    [SlotMethod("player/enter")]
    void End(Signal s)
    {
        transform.parent.GetComponentInChildren<TextMeshPro>().text = "START";
        var cg = GameObject.Find("Canvas/BlackScreen").GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
        PlayerController.instance.enabled = false;
        cg.DOFade(1, 2);
    }
}
