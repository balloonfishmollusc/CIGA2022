using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class WaterTrap : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignal(Signal s)
    {
        Subtitle.instance.ShowString("Nemo", "我不会...游泳...咕噜噜噜");

        PlayerActor.instance.gameObject.SetActive(false);
        Task.Delay(1.2f).OnComplete(TeleportPlayer).Play();
    }

    void TeleportPlayer()
    {
        PlayerActor.instance.ResetSelf();
    }
}
