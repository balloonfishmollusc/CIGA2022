using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class Lv02Dialogue : InteractiveBehaviour
{
    int triggerCount = 0;

    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal(s));
    }

    void OnSignal(Signal s)
    {
        if (!Camera.main.GetComponent<CameraFollow>().enabled) return;

        if(triggerCount % 2 == 0)
        {
            Subtitle.instance.ShowString("Nemo", "��...����������ȥ...Ҫ�ǡ����С����и���̨�ס��ͺ���");
        }
        else
        {
            Subtitle.instance.ShowString("Nemo", "��...������������ȥ...Ҳ����ϻ���������������");
        }
        triggerCount++;
    }
}
