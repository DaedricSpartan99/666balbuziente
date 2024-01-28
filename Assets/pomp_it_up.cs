using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pomp_it_up : MonoBehaviour
{

    public float period = 3.0f; // time that a block takes to reboost up again, in seconds
    public float force = 500f; // force impulse to apply

    //float shift;
    bool apply = true;

    // Start is called before the first frame update
    void  Start()
    {
       StartCoroutine( wait_start() );
    }

    IEnumerator wait_start() {
       apply = true;
       yield return new WaitForSeconds(Random.value * period);
       apply = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(!apply)
      {
        StartCoroutine( routine() );
      }
    }

    private IEnumerator routine() {
        apply = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        yield return new WaitForSeconds( period );
        apply = false;
    }
}
