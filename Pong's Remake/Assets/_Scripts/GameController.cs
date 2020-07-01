using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Score. The ball interacts with the scoreColliders or side colliders and the Player Scores!
   //Show Score.

        //TODO> UI Score text! -  Sound of Scoring - 

    //Camera Boundaries:
    public float minX, maxX, minY, maxY;
    public int scoreP1;
    public int scoreP2;

    [SerializeField] GameObject ballGO;



    // Start is called before the first frame update
    void Start()
    {
        //GetComponents();
        MeasureScreen();
    }

   /* void GetComponents()
    {
    }
    */
    void MeasureScreen()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }
    public void Score(int player)
    {
        if (player == 1)
        {
            ScoreP1();
        }
        if(player == 2)
        {
            ScoreP2();
        }
        
        Invoke("Reload", 1f);
    }
    void ScoreP1()
    {
        //text Player 1 Scores!
        scoreP1++;
    }
    void ScoreP2()
    {
        //text Player 2 Scores!

        scoreP2++;
    }
    void Reload()
    {
        Instantiate(ballGO, new Vector3(0, 0, 0), Quaternion.identity);
    }
   
   

    // Update is called once per frame
    void Update()
    {
        
    }


}
