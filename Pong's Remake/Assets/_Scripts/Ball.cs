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
    [SerializeField] GameObject soundFXsManagerGO;
    [SerializeField] SoundFXsManager soundFXsManagerScript;


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
        soundFXsManagerGO = FindObjectOfType<SoundFXsManager>().gameObject;
        soundFXsManagerScript = soundFXsManagerGO.GetComponent<SoundFXsManager>();
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
        if (gameControllerScript.state == GameController.State.Serving)
        {
            StartCoroutine(gameControllerScript.Serving());
        }
        else if (gameControllerScript.state == GameController.State.Playing)
        {
            MoveBall();
        }
        
        
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
            soundFXsManagerScript.PlayBounceSFX();
        }
        if (coll.gameObject.CompareTag("Player1"))
        {
            movementDirection.x = -movementDirection.x;
            RandomizeMovement();
            soundFXsManagerScript.PlayBounceSFX();

        }
        if (coll.gameObject.CompareTag("Player2"))
        {
            movementDirection.x = -movementDirection.x;
            RandomizeMovement();
            soundFXsManagerScript.PlayBounceSFX();

        }
        if (coll.gameObject.CompareTag("SideP1Collider"))
        {
            Destroy(gameObject);
            gameControllerScript.Score(1);
            soundFXsManagerScript.PlayScoreSFX();
            gameControllerScript.state = GameController.State.Serving;



        }
        if (coll.gameObject.CompareTag("SideP2Collider"))
        {
            Destroy(gameObject);
            gameControllerScript.Score(2);
            soundFXsManagerScript.PlayScoreSFX();

            gameControllerScript.state = GameController.State.Serving;


        }

    }
    void RandomizeMovement()
    {
        speed = Random.Range(0.2f, 0.6f);
        movementDirection.y = startingDirections[Random.Range(0,startingDirections.Length)].y;
    }

    //appear code #TODO
    /*
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.renderer.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.renderer.material.color = newColor;
            yield return null;
        }
    }
    */


}
