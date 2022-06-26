using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class WaterTrap : InteractiveBehaviour
{
    [SlotMethod("player/enter")]
    void OnSignal(Signal s)
    {
        Subtitle.instance.ShowString("Nemo", "�Ҳ���...��Ӿ...��������");

        PlayerActor.instance.gameObject.SetActive(false);
        Task.Delay(1.2f).OnComplete(TeleportPlayer).Play();
    }

    void TeleportPlayer()
    {
        PlayerActor.instance.ResetSelf();
    }
}
