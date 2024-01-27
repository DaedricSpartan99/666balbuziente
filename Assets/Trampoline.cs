using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class Trampoline : MonoBehaviour {
	public float springForce = 1000;
	private Collision2D collision;
	private bool bouncing = false;
	private bool? clickStatus = false;

	void OnCollisionEnter2D(Collision2D coll) {
		if (!bouncing) {
			bouncing = true;
			collision = coll;
		}
	}

	void Update() {
		if (Input.GetMouseButtonDown(0) && gameObject.name == "Trampolino"){
			Debug.Log((Variables.Object(gameObject).Get("clickStatus")) as bool?);
			clickStatus = !(Variables.Object(gameObject).Get("clickStatus") as bool?);
			Variables.Application.Set("clickStatus",clickStatus);
   		}
	}

	void FixedUpdate () {
		if (bouncing && ((Variables.Object(gameObject).Get("clickStatus") as bool?) == true)) {
			var rb = collision.gameObject.GetComponent<Rigidbody2D> ();
			rb.velocity = new Vector3 (0, 0, 0);
			rb.AddForce (new Vector2 (0f, springForce));
			bouncing = false;
		}
	}
}