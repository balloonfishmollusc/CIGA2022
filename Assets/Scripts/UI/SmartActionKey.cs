using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class SmartActionKey : MonoBehaviour
{
    private Button button;

    public static KeyControl key { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(() => StartCoroutine(OnClick()));
    }

    CanvasGroup tipsPanel => GameObject.Find("Canvas/TipsPanel").GetComponent<CanvasGroup>();

    IEnumerator OnClick()
    {
        tipsPanel.blocksRaycasts = true;
        tipsPanel.alpha = 1;

        while (true)
        {
            foreach (var item in Keyboard.current.allKeys)
            {
                if (item.wasPressedThisFrame)
                {
                    key = item;
                    button.GetComponentInChildren<TextMeshProUGUI>().text = key.name.ToUpper();

                    tipsPanel.blocksRaycasts = false;
                    tipsPanel.alpha = 0;

                    yield return new WaitForEndOfFrame();
                    yield return new WaitForEndOfFrame();
                    yield return new WaitForEndOfFrame();
                    yield break;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
