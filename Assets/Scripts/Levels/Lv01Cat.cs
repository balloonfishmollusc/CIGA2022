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
            case 0: Subtitle.instance.ShowString("Nemo", "猫猫...真可爱..."); break;
            case 1: Subtitle.instance.ShowString("Cat", "前行之路，铁匣之中喵~"); break;
            default:
                Subtitle.instance.ShowString("Cat", "前行之路，「铁匣之中」喵~"); break;
        }
        triggerCount++;
    }
}
