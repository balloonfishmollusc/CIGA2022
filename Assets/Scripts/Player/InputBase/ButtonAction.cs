public enum ButtonEvent
{
    None,
    ButtonDown,
    ButtonUp
}

public sealed class Trigger
{
    public bool value;

    public bool TS()
    {
        if (value)
        {
            value = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}

[System.Serializable]
public sealed class ButtonAction : CustomInputAction
{
    private Trigger startedTag = new Trigger();
    private Trigger canceledTag = new Trigger();

    protected override void Initialize()
    {
        action.started += (_) => startedTag.value = true;
        action.canceled += (_) => canceledTag.value = true;
    }

    public ButtonEvent Update()
    {
        if (!action.enabled) return ButtonEvent.None;

        if (startedTag.TS()) return ButtonEvent.ButtonDown;
        if (canceledTag.TS()) return ButtonEvent.ButtonUp;

        return ButtonEvent.None;
    }
}