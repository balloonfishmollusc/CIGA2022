using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class MushroomDialogue : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal(s));
    }

    void OnSignal(Signal s)
    {
        Subtitle.instance.ShowString("Nemo", "�������ܺó�...����̫С�ˣ�һ������Ϊ����̫���ˣ�");
    }

    private void OnDestroy()
    {
        Subtitle.instance.ShowString("Nemo", "�ۣ��о����ԳԺþã�");
    }
}
