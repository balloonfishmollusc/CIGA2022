using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Lv01Opening : MonoBehaviour, IPointerClickHandler
{
    private List<string> texts = new List<string>()
    {
        "哟，你在这里做什么\n(点击鼠标左键继续)",
        "你问这里是什么地方？",
        "这里可是以我为主角的叫《心之迷宫》的游戏",
        "——虽然我很想这么说",
        "但是当初要做这个游戏的家伙居然沉迷虚拟主播，把我鸽了！",
        "结果除了我以外什么都没完成",
        "开什么玩笑啊！我才不要在这种半成品的游戏里面呆一辈子！",
        "所以总之，你来帮我找到出口，逃离这个游戏吧！",
        "常规的WASD就可以控制我了，不过因为这个游戏只是个半成品，",
        "想要通关可能要思考非常规的方式。"
    };


    public TextMeshProUGUI textMeshPro;

    public bool clicked = false;

    private void Start()
    {
        var cg = GameObject.Find("Canvas/BlackScreen").GetComponent<CanvasGroup>();
        cg.alpha = 1;
        cg.DOFade(0, 2).OnComplete(() => StartCoroutine(OpeningCorontinue()));
    }

    IEnumerator OpeningCorontinue()
    {
        var cg = GetComponent<CanvasGroup>();
        cg.alpha = 1;
        cg.blocksRaycasts = true;

        foreach (var item in texts)
        {
            textMeshPro.text = item;
            yield return new WaitUntil(() => clicked);
            clicked = false;
        }

        Destroy(gameObject);
        PlayerController.instance.enabled = true;
        Camera.main.DOOrthoSize(7, 2.2f);
        Camera.main.GetComponent<CameraFollow>().enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
    }
}
