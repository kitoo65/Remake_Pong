using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundido : MonoBehaviour
{
    public Image fundido;
    public string[] scenes;
   

    // Start is called before the first frame update
    void Start()
    {
        fundido.CrossFadeAlpha(0,0.5f,false);

       
    }

    public void FadeOut(int s)
    {
        fundido.CrossFadeAlpha(1,0.5f,false);
        StartCoroutine(ChangeScene(scenes[s]));

    }
    IEnumerator ChangeScene(string scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
