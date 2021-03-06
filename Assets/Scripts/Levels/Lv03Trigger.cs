using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;
using System.Linq;

public class Lv03Trigger : InteractiveBehaviour
{
    public static bool isEnabled = false;

    [SlotMethod("player/enter")]
    void OnSignal(Signal s)
    {
        Subtitle.instance.ShowString("Nemo", "????Ҳ?У?");

        PlayerActor.instance.initialPos = transform.GetChild(0).position;

        var platforms = GameObject.Find("HiddenPlatforms").GetComponentsInChildren<HiddenPlatform>();
        foreach (var plat in platforms)
        {
            plat.enabled = true;
        }

        isEnabled = true;
        if (SettingsPanel.instance.volControl.slider.value <= VolControl.threshold)
            SettingsPanel.instance.volControl.slider.value = 1.0f;
        Destroy(gameObject);
    }
}
