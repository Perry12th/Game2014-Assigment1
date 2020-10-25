/* Source file Name: PlayerController.cs
 * Student Name: Flavio Araujo Silva
 * StudentID: 101173562
 * Last Date Mod: 2020-10-25
 * Description: Controller for the player ship
 * Revision History: Added in proper movement and bullet firing along with colliison triggers
 */
using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float horizontalBoundary;

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    public float TValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;
    private PlayerHUDBehaviour m_playerHUD;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_playerHUD = GetComponent<PlayerHUDBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _FireBullet()
    {
        // delay bullet firing 
        if (Time.frameCount % 120 == 0 && bulletManager.HasBullets())
        {
            FindObjectOfType<AudioManager>().PlaySound("FireBullet");
            bulletManager.GetBullet(transform.position + new Vector3(0.0f, 1.0f));
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            _FireBullet();
            

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.x, TValue), transform.position.y);
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }


    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y);
        }

        // check left bounds
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y);
        }

    }
}

