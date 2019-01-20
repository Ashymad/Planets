using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1F;
    public float rotSpeed = 0.01F;

    private Rigidbody rb;
    private ParticleSystem ps;

    void Start ()
    {
	rb = GetComponent<Rigidbody>();
	ps = GetComponent<ParticleSystem>();
	ps.enableEmission = false;
    }

    void FixedUpdate()
    {
	var verticalAxis = Input.GetAxis ("Vertical");

	ps.enableEmission = verticalAxis > 0;

	Vector3 move = transform.forward *verticalAxis;
	move += transform.right * Input.GetAxis ("Horizontal");
	move += transform.up * Input.GetAxis("Depthical");

	rb.AddForce (move * speed);

	Vector3 rot = transform.up * Input.GetAxis ("Horizontal2");
	rot += transform.right * Input.GetAxis ("Vertical2");
	rot += -transform.forward * Input.GetAxis("Depthical2");

	rb.AddTorque (rot * rotSpeed);
    }
}
