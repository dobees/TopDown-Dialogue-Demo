using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove)
        {
            moveInput = Vector2.zero;
            return;
        }

        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            ).normalized; //대각선이동 빨라짐 방지
    }

    private void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + moveInput * moveSpeed * Time.fixedDeltaTime
            );
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
