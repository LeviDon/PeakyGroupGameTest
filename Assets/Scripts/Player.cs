using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed = 5f;

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    public Joystick movementJoystick;
    private Rigidbody2D rb;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        float x = UnityEngine.Input.GetAxisRaw("Horizontal");
        float y = UnityEngine.Input.GetAxisRaw("Vertical");

        Vector2 keyboardInput = new Vector2(x, y);
        Vector2 joystickInput = movementJoystick.Direction;

        Vector2 combinedInput = keyboardInput + joystickInput;

        if (combinedInput.magnitude > 1f)
        {
            combinedInput = combinedInput.normalized;
        }

        moveDelta = new Vector3(combinedInput.x, combinedInput.y, 0);

        //moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Horizontal
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * speed * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if ((hit.collider == null) || (movementJoystick.Direction.x != 0))
        {
            transform.Translate(moveDelta.x * speed * Time.deltaTime, 0, 0);
        }
        // Vertical
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * speed * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if ((hit.collider == null) || (movementJoystick.Direction.y != 0))
        {
            transform.Translate(0, moveDelta.y * speed * Time.deltaTime, 0);
        }

        if (movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x * speed * Time.deltaTime, movementJoystick.Direction.y * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    public void BoostSpeedTemporarily()
    {
        StartCoroutine(SpeedBoost());
    }

    private IEnumerator SpeedBoost()
    {
        float sspeed = speed;
        speed += 1f;

        yield return new WaitForSeconds(3f);

        speed = sspeed;
    }
}
