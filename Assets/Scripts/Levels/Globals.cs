using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public GameObject boxInstance;
    public GameObject boxPrefab;

    public void ResetLevel()
    {
        PlayerActor.instance.ResetSelf();

        Destroy(boxInstance);
        boxInstance = Instantiate(boxPrefab);

        SettingsPanel.instance.enabled = false;
    }
}
