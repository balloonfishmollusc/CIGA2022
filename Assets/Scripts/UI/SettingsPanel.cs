using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public static SettingsPanel instance { get; private set; }

    public VolControl volControl;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        Time.timeScale = 1;
    }

    public void UseTab(string id)
    {
        for (int i = 0; i < transform.Find("$").childCount; i++)
        {
            var g = transform.Find("$").GetChild(i).gameObject;
            if (g.name == "Tabs") continue;
            g.SetActive(g.name == id);
        }
    }
}
