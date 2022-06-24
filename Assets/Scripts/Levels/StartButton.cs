using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class StartButton : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void DoActivateAll(Signal s)
    {
        foreach (var item in FindObjectsOfType<Activatable>())
        {
            item.enabled = true;
        } 
    }
}
