using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;
using System.Linq;

public class Lv03Trigger : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignal(Signal s)
    {
        PlayerActor.instance.initialPos = transform.GetChild(0).position;

        var platforms = GameObject.Find("HiddenPlatforms").GetComponentsInChildren<HiddenPlatform>();
        foreach (var plat in platforms)
        {
            plat.enabled = true;
        }
        Destroy(gameObject);
    }
}
