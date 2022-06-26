using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActor actor;

    public static PlayerController instance { get; private set; }

    [SerializeField] private MoveAction moveAction;
    [SerializeField] private ButtonAction jumpAction;

    private void Awake()
    {
        actor = transform.parent.GetComponent<PlayerActor>();
        instance = this;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        actor.onUpdate += Actor_onUpdate;
        actor.onFixedUpdate += Actor_onFixedUpdate;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        actor.onUpdate -= Actor_onUpdate;
        actor.onFixedUpdate -= Actor_onFixedUpdate;
    }

    private void Actor_onUpdate()
    {
        actor.Move(moveAction.value);

        if (SmartActionKey.key != null)
        {
            if (SmartActionKey.key.wasPressedThisFrame)
            {
                actor.DoSmartAction();
            }
        }
    }

    private void Actor_onFixedUpdate()
    {
        switch (jumpAction.Update())
        {
            case ButtonEvent.ButtonDown: actor.BeginJump(); break;
            case ButtonEvent.ButtonUp: actor.EndJump(); break;
            default: break;
        }
    }
}
