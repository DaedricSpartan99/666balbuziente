using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverRestart : MonoBehaviour
{

    private float timer=0.000f;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer>0.755f){
            Image ticinesi= GameObject.FindWithTag("Ticinesi").GetComponent<Image>();
            ticinesi.color=new Color(ticinesi.color.r,ticinesi.color.g,ticinesi.color.b,1.0f);
        
        }
        if (timer>5.0f){
            SceneManager.LoadScene(GlobalVariables.Instance.lastSceneName);
        }
        
        

        
        

        
        

    }
}
