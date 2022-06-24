using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFlow;

public class SmartActionSignal : InteractiveBehaviour
{
    private HashSet<Collider2D> insides = new HashSet<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        insides.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        insides.Remove(collision);
    }

    public void DoEmit()
    {
        foreach(var c2d in insides)
        {
            Emit(Signal("player/smart_action"), c2d.gameObject);
        }
    }
}
