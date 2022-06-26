using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlatform : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color
            = GameObject.Find("Globals/Background").GetComponent<SpriteRenderer>().color;
    }
}
