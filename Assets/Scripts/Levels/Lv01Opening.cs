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
        "Ӵ������������ʲô\n(�������������)",
        "����������ʲô�ط���",
        "�����������Ϊ���ǵĽС���֮�Թ�������Ϸ",
        "������Ȼ�Һ�����ô˵",
        "���ǵ���Ҫ�������Ϸ�ļһ��Ȼ�����������������Ҹ��ˣ�",
        "�������������ʲô��û���",
        "��ʲô��Ц�����ҲŲ�Ҫ�����ְ��Ʒ����Ϸ�����һ���ӣ�",
        "������֮�����������ҵ����ڣ����������Ϸ�ɣ�",
        "�����WASD�Ϳ��Կ������ˣ�������Ϊ�����Ϸֻ�Ǹ����Ʒ��",
        "��Ҫͨ�ؿ���Ҫ˼���ǳ���ķ�ʽ��"
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
