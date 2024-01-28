using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript3 : MonoBehaviour
{


    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(
            () =>
            {
                SceneManager.LoadScene("LivelloPolotti"); 
            }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }

}
