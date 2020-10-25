using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerType
{
    LIVES,
    POINTS,
}

public class PowerUpBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public PowerType powerType;

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
        if (transform.position.y < verticalBoundary)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hazard Collided with " + other.gameObject.name);
        var player = other.gameObject.GetComponent<PlayerHUDBehaviour>();
        if (player != null)
        {
            FindObjectOfType<AudioManager>().PlaySound("GainPowerUp");
            switch (powerType)
            {
                case PowerType.LIVES:
                    player.IncreaseLives();
                    break;

                case PowerType.POINTS:
                    player.Add2Score(25);
                    break;
            }

            Destroy(gameObject);
               
        }
    }
}
