using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class WaterTrap : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        PlayerActor.instance.gameObject.SetActive(false);
        Task.Delay(1.2f).OnComplete(TeleportPlayer).Play();

        Subtitle.instance.CDWrapper(() => Subtitle.instance.ShowString("Nemo", "�Ҳ���...��Ӿ...gulululu"));
    }
    void TeleportPlayer()
    {
        PlayerActor.instance.ResetSelf();
    }
}
