using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class InitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.Instance.lastSceneName = SceneManager.GetActiveScene().name;
    }


}
