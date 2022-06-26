using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;
using TMPro;

public class Subtitle : MonoBehaviour
{
    public static Subtitle instance { get; private set; }
    public TextMeshProUGUI textMeshUGUI;
    private CanvasGroup cg;

    private void Awake()
    {
        instance = this;
        cg = GetComponent<CanvasGroup>();
    }

    Task currTask;
    Task coldDownTask;

    public void CDWrapper(System.Action fn)
    {
        if (coldDownTask.IsPlaying()) return;
        coldDownTask = Task.Delay(2.5f); coldDownTask.Play();
        fn();
    }

    public void ShowString(string speaker, string str)
    {
        str = speaker + "£º" + str;
        currTask?.Kill();

        textMeshUGUI.text = str;

        if(cg) cg.alpha = 1;

        currTask = Task.Delay(2).OnComplete(() => cg.alpha = 0);
        currTask.Play();
    }
}
