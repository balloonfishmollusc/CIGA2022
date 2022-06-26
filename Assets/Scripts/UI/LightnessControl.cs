using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightnessControl : MonoBehaviour
{
    public Slider slider;
    public SpriteRenderer background;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
        slider.value = 0.3f;
    }

    void OnValueChanged(float val)
    {
        val = Mathf.Lerp(0, 0.5f, val);
        background.color = (Color.white * val).WithA(1);
    }
}
