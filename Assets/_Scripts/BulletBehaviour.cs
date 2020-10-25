using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public BulletManager bulletManager;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Bullet Collided with " + other.gameObject.name);
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.ApplyDamage(damage);
        }
        bulletManager.ReturnBullet(gameObject);
    }
}

