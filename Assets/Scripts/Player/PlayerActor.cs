using GameFlow;
using UnityEngine;
using DG.Tweening;

[DefaultExecutionOrder(32)]
public class PlayerActor : RigidbodyActor2D
{
    public static PlayerActor instance { get; private set; }

    public float speed = 6f;

    [Header("Jumping")]
    public float minHeight = 2f;
    public float maxHeight = 4f;
    public GroundDetector foot;

    [Header("Body")]
    public SmartActionSignal smartActionSignal;
    public PlayerHand hand;

    private Transform obj;
    private Animator animator;

    [System.NonSerialized] public Vector3 initialPos;

    [Header("Audios")]
    public AudioClip jumpFx;

    public void ResetSelf()
    {
        transform.position = initialPos;
        transform.Find("$").localScale = Vector3.one;
        velocity = Vector2.zero;
        gameObject.SetActive(true);
        Camera.main.GetComponent<CameraFollow>().enabled = true;
    }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        initialPos = transform.position;
        obj = transform.Find("$");
        animator = obj.GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (animator)
        {
            animator.SetBool("is_grounded", foot.isGrounded);
            animator.SetFloat("h_abs_speed", Mathf.Abs(velocity.x));
            animator.SetFloat("v_speed", velocity.y);
        }
    }

    public void Move(float dir)
    {
        velocity = velocity.WithX(dir * speed);

        if (!Mathf.Approximately(dir, 0))
        {
            obj.localScale = obj.localScale.WithX(
                Mathf.Abs(obj.localScale.x) * Mathf.Sign(velocity.x));
        }
    }

    private JumpTask jumpTask;

    public void BeginJump()
    {
        if (!foot.isGrounded) return;
        if (jumpTask.IsPlaying()) return;
        jumpTask = new JumpTask(this, minHeight, maxHeight).SetOwner(this);
        jumpTask.Play();

        SFX.Play(jumpFx);
    }

    public void EndJump()
    {
        jumpTask?.Kill();
    }

    public void DoSmartAction()
    {
        if (hand.hasProp)
        {
            hand.Throw();
        }
        else
        {
            smartActionSignal.DoEmit();
        }
    }
}


public class JumpTask : Task
{
    private PlayerActor actor;
    private float minHeight, maxHeight;

    public JumpTask(PlayerActor actor, float minHeight, float maxHeight)
    {
        this.actor = actor;
        this.minHeight = minHeight;
        this.maxHeight = maxHeight;
    }

    protected override void OnPlay()
    {
        float g = -Physics2D.gravity.y * 1;
        float t = Mathf.Sqrt(2 * minHeight / g);
        float v0 = g * t;
        float ts = (maxHeight - v0 * Mathf.Sqrt(2 * minHeight / g) + minHeight) / v0;

        actor.r2d.gravityScale = 0;
        //actor.velocity += new Vector2(0, v0);
        actor.velocity = actor.velocity.WithY(v0);

        Task.Delay(ts)
            .OnComplete(() =>
            {
                actor.r2d.gravityScale = 1;
                Complete();
            })
            .SetOwner(owner)
            .Play();
    }

    protected override void OnKill()
    {
        actor.r2d.gravityScale = 1;
    }
}