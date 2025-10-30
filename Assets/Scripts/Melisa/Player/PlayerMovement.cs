using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    public Vector2 MoveInput { get; private set; }
    public Vector2 LastMoveDirection { get; private set; }
    public bool CanMove { get; set; } = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!CanMove) return;

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveInput = input.normalized;

        if (MoveInput != Vector2.zero)
            LastMoveDirection = MoveInput;

        if (input != Vector2.zero)
        {
            playerAnimator.SetFloat("Horizontal", input.x);
            playerAnimator.SetFloat("Vertical", input.y);
        }

        playerAnimator.SetFloat("Speed", MoveInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        if (!CanMove) return;

        playerRb.MovePosition(playerRb.position + MoveInput * speed * Time.fixedDeltaTime);
    }

    public void SetCanMove(bool value)
    {
        CanMove = value;

        if (!value)
            playerAnimator.SetFloat("Speed", 0);
    }
}
