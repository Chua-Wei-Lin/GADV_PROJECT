using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _myRb;
    private Vector2 _direction;
    public float speed = 30f;
    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }
    void FixedUpdate()
    {
        if (_direction == Vector2.zero)
        {
            return;
        }

        _myRb.linearVelocity = _direction * speed;
    }
    
}
