using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int contact_damage;

    [SerializeField] private Transform[] waypoints;

    private SpriteRenderer spriteRenderer;
    private Transform target;
    private int waypointId;

    // Start is called before the first frame update
    void Start()
    {
        waypointId = 0;
        target = waypoints[waypointId];

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            waypointId = (waypointId + 1)% waypoints.Length;
            target = waypoints[waypointId];
        }

        if(dir.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }else if(dir.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(contact_damage);
        }
    }
}
