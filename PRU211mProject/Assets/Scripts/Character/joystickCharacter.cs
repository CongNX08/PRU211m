using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        if(rb.transform.position.x > 8 && move.x > 0)
        {
            move.x = 0;
            move.y = 0;
            return;
        }
    }
}
