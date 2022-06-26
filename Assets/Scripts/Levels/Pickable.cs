using GameFlow;
using UnityEngine;

public class Pickable : InteractiveBehaviour
{
    public AudioClip pickFx;
    int triggerCount = 0;
    bool done = false;

    [SlotMethod("player/enter")]
    void OnSignalWrapper(Signal s)
    {
        Subtitle.instance.CDWrapper(() => OnSignal1(s));
    }

    void OnSignal1(Signal s)
    {
        if (done) return;
        switch (triggerCount)
        {
            case 0: Subtitle.instance.ShowString("Nemo", "我忘记怎么拿箱子了"); break;
            default:
                Subtitle.instance.ShowString("Nemo", "我忘记「怎么拿」箱子了"); break;
        }
        triggerCount++;
    }


    [SlotMethod("player/smart_action")]
    void OnSignal2(Signal s)
    {
        if (!done)
        {
            Subtitle.instance.ShowString("Nemo", "唔...好重");
        }
        done = true;

        var hand = PlayerActor.instance.hand;
        hand.Add(gameObject);

        SFX.Play(pickFx);
    }
}
