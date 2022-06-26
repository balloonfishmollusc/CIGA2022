using UnityEngine;
using GameFlow;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ExitButton : InteractiveBehaviour
{

    [SlotMethod("player/enter")]
    void End(Signal s)
    {
        //transform.parent.GetComponentInChildren<TextMeshPro>().text = "START";
        var cg = GameObject.Find("Canvas/BlackScreen").GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
        PlayerController.instance.enabled = false;
        PlayerActor.instance.enabled = false;
        cg.DOFade(1, 2).OnComplete(
            () => SceneManager.LoadScene("002"));
    }
}
