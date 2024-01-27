using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject nome;

    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(
            () =>
            {
                Debug.Log("1");
                nome.transform.Translate(677f, 0f, 0f);
            }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }

}
