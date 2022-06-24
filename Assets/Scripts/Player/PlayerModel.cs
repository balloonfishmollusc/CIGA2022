using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] string key;

    private static Dictionary<string, PlayerModel> modelDic = new Dictionary<string, PlayerModel>();

    public static int aliveCount => modelDic.Count;

    public static void Apply(System.Action<string, PlayerModel> act)
    {
        var copiedDic = new Dictionary<string, PlayerModel>(modelDic);
        foreach (var item in copiedDic)
            act(item.Key, item.Value);
    }

    private void Awake()
    {
        modelDic[key] = this;
    }

    public static void DestroyAll()
    {
        Apply((key, model) => model.DestroySelf());
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        modelDic.Remove(this.key);
    }
}
