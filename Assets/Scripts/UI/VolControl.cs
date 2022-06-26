using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class VolControl : MonoBehaviour
{
    public Slider slider;

    public static float threshold = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
        slider.value = 1.0f;
    }

    void OnValueChanged(float val)
    {
        AudioListener.volume = val;

        if (Lv02Trigger.isEnabled && val < threshold)
        {
            var g = GameObject.Find("MushroomTrigger");
            if (!g) return;

            GameObject.Find("Mushrooms").GetComponent<PlayableDirector>().enabled = true;
            Destroy(g, 1f);
        }
    }

}
