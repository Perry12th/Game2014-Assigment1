using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float rotateSpeed = 200f;
    [SerializeField]
    private float verticalBounds;
    [SerializeField]
    private int health;
    [SerializeField]
    private int pointPerKill;
    private Rigidbody2D rb;
    private EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
    }

    void _Move()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;


        if (target.position.y < rb.position.y)
        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    void _CheckBounds()
    {
        if (transform.position.y < verticalBounds)
        {
            enemyManager.ReturnEnemy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.GetComponent<PlayerHUDBehaviour>() != null)
        {
            other.GetComponent<PlayerHUDBehaviour>().ReduceLives();
            enemyManager.ReturnEnemy(gameObject);
        }

    }

    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("Explosion");
            var player = GameObject.FindObjectOfType<PlayerHUDBehaviour>();
            player.Add2Score(pointPerKill);
            enemyManager.ReturnEnemy(gameObject);
        }
    }
}
