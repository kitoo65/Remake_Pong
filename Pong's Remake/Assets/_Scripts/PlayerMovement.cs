using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Values
    [SerializeField] float speed = 1f;
    [SerializeField] Vector2 input;
    [SerializeField] Vector2 position;
    //Player Values && Components
    [SerializeField] float halfHeightPlayer;
    Rigidbody2D rbPlayer;
    SpriteRenderer spriteRendererPlayer;
    [SerializeField] GameObject gameControllerGO;
    [SerializeField] GameController gameControllerScript;
    enum State {Inside, BoundarieUp, BoundarieDown};
    State state = State.Inside;


    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
    }
    void GetComponents()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        gameControllerGO = FindObjectOfType<GameController>().gameObject;
        gameControllerScript = gameControllerGO.GetComponent<GameController>();
        spriteRendererPlayer = gameObject.GetComponent<SpriteRenderer>();

    }
    

    // Update is called once per frame
    void Update()
    {
        GetInputToMove();
        MeasurePlayer();
        CheckBoundaries();
    }
    void GetInputToMove()
    {
        if (gameObject.CompareTag("Player1"))
        {
            input.y = Input.GetAxisRaw("Vertical_P1");
            position = transform.position;
        }
        if (gameObject.CompareTag("Player2"))
        {
            input.y = Input.GetAxisRaw("Vertical_P2");
            position = transform.position;
        }
    }
    void MeasurePlayer()
    {
        float offset = 0.5f;
        halfHeightPlayer = spriteRendererPlayer.bounds.size.y/2 + offset;
    }
    void CheckBoundaries()
    {
        if (position.y - halfHeightPlayer > gameControllerScript.minY && position.y + halfHeightPlayer < gameControllerScript.maxY)
        {
            state = State.Inside;
        }
        if (position.y - halfHeightPlayer <= gameControllerScript.minY )
        {
            state = State.BoundarieDown;
        }
        if (position.y + halfHeightPlayer >= gameControllerScript.maxY)
        {
            state = State.BoundarieUp;
        }
    }

    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        if (state == State.Inside)
        {
            rbPlayer.MovePosition(position + input * speed);
        }
        if (state == State.BoundarieUp)
        {
            if (input.y == 1)
            {

            }
            else
                rbPlayer.MovePosition(position + input * speed);
        }
        if (state == State.BoundarieDown)
        {
            if (input.y == -1)
            {

            }
            else
                rbPlayer.MovePosition(position + input * speed);
        }
    }

}
