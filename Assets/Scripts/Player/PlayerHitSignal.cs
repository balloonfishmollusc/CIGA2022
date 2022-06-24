using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class PlayerHitSignal : InteractiveBehaviour
{
    private PlayerModel model;

    private void Awake()
    {
        model = GetComponentInParent<PlayerModel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Emit(Signal("player/enter").AddData("model", model), collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Emit(Signal("player/exit").AddData("model", model), collision.gameObject);
    }
}
