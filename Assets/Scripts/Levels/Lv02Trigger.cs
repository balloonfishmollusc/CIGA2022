using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class Lv02Trigger : InteractiveBehaviour
{
    public static bool isEnabled = false;

    [SlotMethod("player/enter")]
    void OnSignal(Signal s)
    {
        //GameObject.Find("Globals/BGM/Normal").SetActive(false);
        GameObject.Find("Globals/BGM/Noise").SetActive(true);

        Subtitle.instance.ShowString("Nemo", "��...���㻹�е���");

        isEnabled = true;
        Destroy(gameObject);
    }
}
