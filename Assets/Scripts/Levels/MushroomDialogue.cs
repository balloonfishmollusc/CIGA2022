using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class MushroomDialogue : InteractiveBehaviour
{
    int triggerCount = 0;

    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal(s));
    }

    void OnSignal(Signal s)
    {
        if (triggerCount % 2 == 0)
        {
            Subtitle.instance.ShowString("Nemo", "�������ܺó�...����̫С��");
        }
        else
        {
            Subtitle.instance.ShowString("Nemo", "��ЩĢ��̫С�ˣ�һ������Ϊ����̫���ˣ�");
        }
        triggerCount++;
    }

    private void OnDestroy()
    {
        Subtitle.instance.ShowString("Nemo", "�ۣ��о����ԳԺþã�");

    }
}
