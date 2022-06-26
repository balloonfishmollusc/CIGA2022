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
            case 0: Subtitle.instance.ShowString("Nemo", "��������ô��������"); break;
            default:
                Subtitle.instance.ShowString("Nemo", "�����ǡ���ô�á�������"); break;
        }
        triggerCount++;
    }


    [SlotMethod("player/smart_action")]
    void OnSignal2(Signal s)
    {
        if (!done)
        {
            Subtitle.instance.ShowString("Nemo", "��...����");
        }
        done = true;

        var hand = PlayerActor.instance.hand;
        hand.Add(gameObject);

        SFX.Play(pickFx);
    }
}
