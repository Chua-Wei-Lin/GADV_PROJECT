using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _myRb;
    private Vector2 _direction;
    public float speed = 30f;
    private Animator anim;

    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //  Assign Animator
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
            UpdateDirectionBools(_direction);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
            UpdateDirectionBools(_direction);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
            UpdateDirectionBools(_direction);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
            UpdateDirectionBools(_direction);
        }
        else
        {
            _direction = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            _myRb.linearVelocity = _direction * speed; 
        }
        else
        {
            _myRb.linearVelocity = Vector2.zero;
        }
    }

    void UpdateDirectionBools(Vector2 dir)
    {
        bool movingUp = dir.y > 0.1f;
        bool movingDown = dir.y < -0.1f;
        bool movingRight = dir.x > 0.1f;
        bool movingLeft = dir.x < -0.1f;

        anim.SetBool("Up", movingUp);
        anim.SetBool("Down", movingDown);
        anim.SetBool("Left", movingLeft);
        anim.SetBool("Right", movingRight);
    }
}
