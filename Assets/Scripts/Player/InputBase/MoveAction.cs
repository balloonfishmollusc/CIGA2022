using UnityEngine;

[System.Serializable]
public sealed class MoveAction : CustomInputAction
{
    /// <summary>
    /// Speed from (1 or -1) to 0, units/sec
    /// </summary>
    [SerializeField] float gravity = 3;

    /// <summary>
    /// Speed from 0 to (1 or -1), units/sec
    /// </summary>
    [SerializeField] float sensitivity = 3;

    /// <summary>
    /// Reset to 0 immediately when the player wants to change direction
    /// </summary>
    [SerializeField] bool snap = true;

    private float prevVal;
    private float prevTime;

    protected override void Initialize()
    {
        prevTime = Time.time;
        prevVal = 0;
    }

    public static int Sign(float x)
    {
        if (Mathf.Approximately(x, 0)) return 0;
        return (int)Mathf.Sign(x);
    }

    public float rawValue => action.ReadValue<float>();

    public float value
    {
        get
        {
            float val = rawValue;

#if UNITY_EDITOR
            Debug.Assert(rawValue == 1 || rawValue == -1 || rawValue == 0);
#endif

            float deltaTime = Time.time - prevTime;

            if (snap && Sign(val) * Sign(prevVal) == -1)
                val = 0;
            else
            {
                float maxDeltaVal = deltaTime *
                    (Mathf.Abs(val) > Mathf.Abs(prevVal) ? sensitivity : gravity);
                float deltaVal = val - prevVal;
                deltaVal = Sign(deltaVal) * Mathf.Min(Mathf.Abs(deltaVal), maxDeltaVal);
                val = prevVal + deltaVal;
            }

            prevTime = Time.time;
            prevVal = val;

            return val;
        }
    }
}
