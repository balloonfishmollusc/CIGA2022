using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class Lv03FirstHiddenPlatform : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal(s));
    }

    void OnSignal(Signal s)
    {
        Subtitle.instance.ShowString("Nemo", "哎呀！这里好像有什么东西...我「看不清楚」...");
        Destroy(this);
    }
}
