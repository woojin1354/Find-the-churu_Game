using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight = 8f;
    InputAction jumpAction; // 점프키 입력시 점프 처리용

    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("jump");
    }

    // Update is called once per frame
    void Update()
    {

        if (jumpAction.WasPressedThisFrame() && transform.position.y < -2.6)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            Vector2 jumpVelocity = Vector2.up * jumpHeight;
            rigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        else if (transform.position.y < -5)
        {
            GameManager.instance.Fail();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            GameManager.instance.Scoring();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            GameManager.instance.Fail();
            Destroy(gameObject);
        }
    }
}
