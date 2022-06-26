using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;
public class Lv01Cat : InteractiveBehaviour
{
    int triggerCount = 0;

    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal(s));
    }


    void OnSignal(Signal s)
    {
        bool flip = PlayerActor.instance.position.x > transform.position.x;
        GetComponent<SpriteRenderer>().flipX = flip;

        switch (triggerCount)
        {
            case 0: Subtitle.instance.ShowString("Nemo", "èè...��ɰ�..."); break;
            case 1: Subtitle.instance.ShowString("Cat", "ǰ��֮·����ϻ֮����~"); break;
            default:
                Subtitle.instance.ShowString("Cat", "ǰ��֮·������ϻ֮�С���~"); break;
        }
        triggerCount++;
    }
}
