using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehaviour : MonoBehaviour, IDamageable
{
    public float verticalSpeed;
    public float verticalBoundary;
    public HazardManager hazardManager;
    public int damage;
    [SerializeField]
    private GameObject LivesObject;
    [SerializeField]
    private GameObject PointsObject;
    [SerializeField]
    private int health;
    [SerializeField]
    private int pointsPerKill;

    // Start is called before the first frame update
    void Start()
    {
        hazardManager = FindObjectOfType<HazardManager>();
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
        if (transform.position.y < verticalBoundary)
        {
            hazardManager.ReturnHazard(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hazard Collided with " + other.gameObject.name);

        if (other.GetComponent<PlayerHUDBehaviour>() != null)
        {
            other.GetComponent<PlayerHUDBehaviour>().ReduceLives();
            hazardManager.ReturnHazard(gameObject);
        }
        
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("Explosion");
            var player = GameObject.FindObjectOfType<PlayerHUDBehaviour>();
            player.Add2Score(pointsPerKill);

            if (Random.Range(1, 100) <= 15)
            {
                if (Random.Range(0, 2) == 1)
                {
                    GameObject extraLives = Instantiate(LivesObject, transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject extraPoints = Instantiate(PointsObject, transform.position, Quaternion.identity);
                }
            }

            hazardManager.ReturnHazard(gameObject);
        }
    }
}
