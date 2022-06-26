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
        Subtitle.instance.ShowString("Nemo", "看起来很好吃...不过太小了，一定是因为这里太吵了！");
    }

    private void OnDestroy()
    {
        Subtitle.instance.ShowString("Nemo", "哇！感觉可以吃好久！");
    }
}
