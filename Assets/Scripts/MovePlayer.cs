using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    private bool isGrounded;
    private bool isClimbing;

    private Transform groundedCheck;
    private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask collisionLayer;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float horizontalMovement;
    private float verticalMovement;

    public static MovePlayer Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de MovePlayer dans la scène");
            return;
        }

        Instance = this;
    }

        void Start()
    {
        body = GetComponent<Rigidbody2D>();

        groundedCheck = GameObject.Find("GroundedCheck").transform;
        
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundedCheck.position, groundCheckRadius, collisionLayer);//test perso

        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

        
        Flip(body.velocity.x);

        float characterVelocity = Mathf.Abs(body.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing",isClimbing);

        Move(horizontalMovement, verticalMovement);// test perso

    }

    void FixedUpdate()
    {
        /*isGrounded = Physics2D.OverlapCircle(groundedCheck.position, groundCheckRadius, collisionLayer);

        Move(horizontalMovement,verticalMovement);*/
    }

    private void Move(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, body.velocity.y);
            body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);

            if (isJumping)
            {
                body.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);

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

    public void SetIsClimbing(bool climb)
    {
        isClimbing = climb;
    }

    public bool GetIsClimbing()
    {
        return isClimbing;
    }

    public void ChangeSpeed(int speedBonus)
    {
        moveSpeed+= speedBonus;
    }
}
