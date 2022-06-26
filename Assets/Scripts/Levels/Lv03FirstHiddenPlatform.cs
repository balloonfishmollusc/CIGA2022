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
        Subtitle.instance.ShowString("Nemo", "��ѽ�����������ʲô����...�ҡ����������...");
        Destroy(this);
    }
}
