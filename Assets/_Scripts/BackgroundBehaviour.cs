/* Source file Name: BackgroundController.cs
 * Student Name: Flavio Araujo Silva
 * StudentID: 101173562
 * Last Date Mod: 2020-10-23
 * Description: Controller for the Space Background
 * Revision History: 
 */
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBoundary);
    }

    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalBoundary) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the left side of the screen then reset
        if (transform.position.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
}

