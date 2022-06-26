using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class StartButton : InteractiveBehaviour
{
    bool firstShow = true;

    [SlotMethod("player/enter")]
    void Text(Signal s)
    {
        if (!firstShow) return;
        Subtitle.instance.ShowString("Nemo", "快拿开快拿开！尼莫不喜欢它！");
        firstShow = false;
    }
}
