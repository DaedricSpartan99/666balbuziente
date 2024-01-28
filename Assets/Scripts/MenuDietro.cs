using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript2 : MonoBehaviour
{
    public GameObject avanti;
    public GameObject indietro;

    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(
            () =>
            {
                Debug.Log("1");
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
