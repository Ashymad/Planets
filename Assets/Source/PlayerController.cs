using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1F;

    private Rigidbody rb;

    void Start ()
    {
	rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
	Vector3 moveH = this.transform.right * Input.GetAxis ("Horizontal");
	Vector3 moveV = this.transform.forward * Input.GetAxis ("Vertical");

	rb.AddForce ((moveH + moveV) * speed);
    }
}
