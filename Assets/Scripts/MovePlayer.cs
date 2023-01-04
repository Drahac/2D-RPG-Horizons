using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    private bool isGrounded;

    private Transform groudedLeft;
    private Transform groudedRight;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        groudedLeft = GameObject.Find("GroundedLeft").transform;
        groudedRight = GameObject.Find("GroundedRight").transform;
    
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groudedLeft.position, groudedRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") & isGrounded)
        {
            isJumping = true;
        }

        Move(horizontalMovement);
        Flip(body.velocity.x);

        float characterVelocity = Mathf.Abs(body.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    private void Move(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, body.velocity.y);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            body.AddForce(new Vector2(0f, jumpForce));
            isJumping=false;
        }
    }

    private void Flip(float _velocity)
    {

        if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }else if(_velocity>0.1f){
            spriteRenderer.flipX = false;
        }
    }
}
