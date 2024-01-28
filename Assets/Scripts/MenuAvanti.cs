using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject avanti;
    public GameObject indietro;

    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(
            () =>
            {
                Debug.Log("2");
                avanti.SetActive(false);
                indietro.SetActive(true);
            }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }

}
