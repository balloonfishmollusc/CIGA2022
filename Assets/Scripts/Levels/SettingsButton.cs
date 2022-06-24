using GameFlow;
using UnityEngine;

public class SettingsButton : InteractiveBehaviour
{
    [SlotMethod("player/smart_action")]
    void OnSignal(Signal s)
    {
        var hand = PlayerActor.instance.hand;
        hand.Add(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Emit(Signal("prop/settings/enter"), collision.gameObject);
    }
}
