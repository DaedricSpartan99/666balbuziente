using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePlayer : MonoBehaviour
{
    public float endSpeed = 30;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(endSpeed, 0);
    }
}
