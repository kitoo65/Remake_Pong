using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PausePanel : MonoBehaviour
{
    /*
     * TODO: Interaccion con botones
     * 
     */
    [SerializeField] GameObject gameControllerGO;
    [SerializeField] GameController gameControllerScript;

    [SerializeField] GameObject[] buttons;
    [SerializeField] Text[] buttonsComp;
    [SerializeField] Text highlightComp;

    // Start is called before the first frame update
    void Start()
    {
        InitiateComponents();
        StartFadeDown();   
    }
    void InitiateComponents()
    {
        gameControllerGO = FindObjectOfType<GameController>().gameObject;
        gameControllerScript = gameControllerGO.GetComponent<GameController>();
    }
    public void ContinueGame(int selection)
    {
        if (selection == 0)
        {
            //continue game, start coroutine of counting
            gameObject.SetActive(false);
            gameControllerScript.state = GameController.State.Playing;
            Time.timeScale = 1;

        }

    }
    public void RestartGame(int selection)
    {
        if (selection == 1)
        {
            //restart game
        }

    }
    public void EnableSound(int selection)
    {
        if (selection == 2)
        {
            //enable/disable sound
        }

    }
    
    public void ExitGame(int selection)
    {
        if (selection == 3)
        {
            //restart game
        }

    }

    public void HighLightButton(int button)
    {
        GetButtonComp(button);
        highlightComp.CrossFadeAlpha(1, 0.2f, false);

    }
    void GetButtonComp(int button) {

        highlightComp = buttons[button].GetComponent<Text>();

    }
    public void RestoreButton(int button)
    {
        GetButtonComp(button);
        highlightComp.CrossFadeAlpha(0.2f, 0.2f, false);

    }
    void StartFadeDown()
    {
        for (int i =0; i <buttons.Length; i++)
        {
            buttonsComp[i] = buttons[i].GetComponent<Text>();
            buttonsComp[i].CrossFadeAlpha(0.2f, 0.02f, false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
        {
            ContinueGame(0);
        }
    }
}
