using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // This ensures that Rigidbody2D component is attached to the GameObject
public class EnemyController : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D rb;
    [SerializeField] private float _speed = 3f; // Adjust this value to change the enemy's movement speed

    public Transform PlayerTransform
    {
        set { _playerTransform = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        if (_playerTransform != null)
        {
            // Calculate the direction to move towards the player
            Vector2 direction = (_playerTransform.position - transform.position).normalized;

            // Set the velocity of the Rigidbody2D to move towards the player
            rb.velocity = direction * _speed;
        }
        else
        {
            // If playerTransform is null, stop moving
            rb.velocity = Vector2.zero;
        }
    }
}
