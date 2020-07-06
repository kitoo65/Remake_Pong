using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
   
        //TODO> UI MENUS

    //Camera Boundaries:
    public float minX, maxX, minY, maxY;
    public int scoreP1;
    public int scoreP2;


    //UI variables
    public Text scoreP1Text;
    public Text scoreP2Text;

    [SerializeField] GameObject ballGO;



    // Start is called before the first frame update
    void Start()
    {
      //  GetComponents();
        MeasureScreen();
    }

  // void GetComponents()
  //  {

  //  }
    
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
        scoreP1Text.text = scoreP1.ToString();
    }
    void ScoreP2()
    {
        //text Player 2 Scores!

        scoreP2++;
        scoreP2Text.text = scoreP2.ToString();
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
