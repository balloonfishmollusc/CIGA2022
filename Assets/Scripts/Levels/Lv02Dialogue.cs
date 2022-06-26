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

        switch (triggerCount)
        {
            default:
                Subtitle.instance.ShowString("Nemo", "唔...好像还是跳不过去...能不能用什么垫一下脚呢..."); break;
        }
        triggerCount++;
    }
}
