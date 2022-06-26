using GameFlow;
using UnityEngine;

public class PlayerHitSignal : InteractiveBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Emit(Signal("player/enter"), collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Emit(Signal("player/exit"), collision.gameObject);
    }
}
