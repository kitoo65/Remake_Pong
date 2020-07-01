using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    [SerializeField] Vector2[] startingDirections;
    [SerializeField] Vector2 movementDirection;
    [SerializeField] Vector2 ballPosition;

    [SerializeField] float speed;
    [SerializeField] float halfHeightBall;

    Rigidbody2D rbBall;
    SpriteRenderer spriteRendererBall;

    [SerializeField] GameObject gameControllerGO;
    [SerializeField] GameController gameControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        SetDirectionAndSpeed();
        MeasureBall();
    }
    void GetComponents()
    {
        rbBall = GetComponent<Rigidbody2D>();
        gameControllerGO = FindObjectOfType<GameController>().gameObject;
        gameControllerScript = gameControllerGO.GetComponent<GameController>();
        spriteRendererBall = gameObject.GetComponent<SpriteRenderer>();
    }
    void SetDirectionAndSpeed()
    {
        movementDirection = startingDirections[Random.Range(0, startingDirections.Length)];
        speed = Random.Range(0.2f, 0.4f);

    }
    void MeasureBall()
    {
        float offset = 0.3f;
        halfHeightBall = spriteRendererBall.bounds.size.y / 2 + offset;
        Debug.Log(halfHeightBall);
    }
    // Update is called once per frame
    void Update()
    {
        GetBallPosition();
    }
    void GetBallPosition()
    {
        ballPosition = transform.position;
    }

    void FixedUpdate()
    {

        MoveBall();
        
    }
    void MoveBall()
    {
        rbBall.MovePosition(ballPosition + movementDirection * speed);
        
    }


    /////////////////////////////////////COLLISIONS/////////////////////////////////////////////////////////
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("LateralCollider"))
        {
            movementDirection.y = -movementDirection.y;
        }
        if (coll.gameObject.CompareTag("Player1"))
        {
            movementDirection.x = -movementDirection.x;
            RandomizeMovement();
        }
        if (coll.gameObject.CompareTag("Player2"))
        {
            movementDirection.x = -movementDirection.x;
            RandomizeMovement();
        }
        if (coll.gameObject.CompareTag("SideP1Collider") || coll.gameObject.CompareTag("SideP2Collider"))
        {
            movementDirection.x = -movementDirection.x;

        }
    }
    void RandomizeMovement()
    {
        speed = Random.Range(0.2f, 0.6f);
        movementDirection.y = startingDirections[Random.Range(0,startingDirections.Length)].y;
    }


}
