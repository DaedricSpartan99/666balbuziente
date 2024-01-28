using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                avanti.transform.Translate(750f, 0f, 0f);
                indietro.transform.Translate(750f, 0f, 0f);
            }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }

}
