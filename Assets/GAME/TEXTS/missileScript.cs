using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileScript : MonoBehaviour
  
	{

	Transform target;
	

	public float speed = 5f;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start ( )
		{
		rb = GetComponent<Rigidbody2D> ( );
		}

	void FixedUpdate ( )
		{
		Invoke ( "call",8.5f );
		}

	void OnTriggerEnter2D ( )
		{
		// Put a particle effect here
		Destroy ( gameObject );
		}


	void call ( )
        {
		target = GameObject.FindGameObjectWithTag ( "ship" ).transform;
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize ( );

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
		}
	}