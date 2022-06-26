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
            Subtitle.instance.ShowString("Nemo", "唔...好像跳不过去...要是「空中」能有个「台阶」就好了");
        }
        else
        {
            Subtitle.instance.ShowString("Nemo", "唔...好像还是跳不过去...也许铁匣子里面会有线索？");
        }
        triggerCount++;
    }
}
