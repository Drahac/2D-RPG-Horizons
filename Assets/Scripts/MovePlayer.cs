using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    private bool isGrounded;

    private Transform groundedCheck;
    private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask collisionLayer;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float horizontalMovement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        groundedCheck = GameObject.Find("GroundedCheck").transform;
        
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundedCheck.position, groundCheckRadius, collisionLayer);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") & isGrounded)
        {
            isJumping = true;
        }

        
        Flip(body.velocity.x);

        float characterVelocity = Mathf.Abs(body.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        Move(horizontalMovement);
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
