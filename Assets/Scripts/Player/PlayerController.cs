using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActor actor;

    [SerializeField] private MoveAction moveAction;
    [SerializeField] private ButtonAction jumpAction;
    [SerializeField] private ButtonAction smartAction;

    private void Awake()
    {
        actor = transform.parent.GetComponent<PlayerActor>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        smartAction.Enable();
        actor.onUpdate += Actor_onUpdate;
        actor.onFixedUpdate += Actor_onFixedUpdate;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        smartAction.Disable();
        actor.onUpdate -= Actor_onUpdate;
        actor.onFixedUpdate -= Actor_onFixedUpdate;
    }

    private void Actor_onUpdate()
    {
        actor.Move(moveAction.value);
    }

    private void Actor_onFixedUpdate()
    {
        switch (jumpAction.Update())
        {
            case ButtonEvent.ButtonDown: actor.BeginJump(); break;
            case ButtonEvent.ButtonUp: actor.EndJump(); break;
            default: break;
        }

        switch (smartAction.Update())
        {
            case ButtonEvent.ButtonUp: actor.DoSmartAction(); break;
            default: break;
        }
    }
}
