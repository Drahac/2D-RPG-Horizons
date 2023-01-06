using UnityEngine;

public class Ladder : MonoBehaviour
{

    private bool isInRange;
    private MovePlayer movePlayer;

    [SerializeField] private Collider2D topCollider;
    void Awake()
    {
        movePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            movePlayer.SetIsClimbing(true);
            topCollider.isTrigger = true;
        }

        if (movePlayer.GetIsClimbing() && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            movePlayer.SetIsClimbing(false);
            topCollider.isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            movePlayer.SetIsClimbing(false);
            topCollider.isTrigger = false;
        }
    }
}
