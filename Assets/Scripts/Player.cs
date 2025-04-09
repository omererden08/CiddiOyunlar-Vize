using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 movement;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        // ClampPosition buradan kaldýrýldý
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
        ClampPosition(); // Rigidbody hareket ettikten sonra sýnýrlama
    }

    void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector2(clampedX, clampedY);
    }
}
