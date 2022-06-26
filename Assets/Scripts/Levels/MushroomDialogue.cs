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
            Subtitle.instance.ShowString("Nemo", "看起来很好吃...不过太小了");
        }
        else
        {
            Subtitle.instance.ShowString("Nemo", "这些蘑菇太小了，一定是因为这里太吵了！");
        }
        triggerCount++;
    }

    private void OnDestroy()
    {
        Subtitle.instance.ShowString("Nemo", "哇！感觉可以吃好久！");

    }
}
