using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 movement;
    [SerializeField] private float speed; // Player speed
    private Animator animator; // Animator component
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource itemSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        itemSound = GetComponent<AudioSource>();
        Cursor.visible = false; // fare imlecini gizle
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            animator.SetBool("isWalking", false); // Animasyonu durdur
            return; // Geri kalan kodlarý çalýþtýrma
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        // ClampPosition buradan kaldýrýldý
        bool isWalking = movement != Vector2.zero;
        animator.SetBool("isWalking", isWalking);

        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            rb.linearVelocity = Vector2.zero; // Oyun bittiðinde hareketi durdur
            return;
        }
        rb.linearVelocity = movement * speed;
        ClampPosition(); // Rigidbody hareket ettikten sonra sýnýrlama
    }

    void ClampPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector2(clampedX, clampedY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemSound.Play();
        }
    }
}
