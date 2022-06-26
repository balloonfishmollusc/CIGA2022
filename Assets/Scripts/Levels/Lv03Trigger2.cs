using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class Lv03Trigger2 : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal(s));
    }

    void OnSignal(Signal s)
    {
        Subtitle.instance.ShowString("Nemo", "看！exit！我能逃出去了！");
        Destroy(gameObject);
    }
}
