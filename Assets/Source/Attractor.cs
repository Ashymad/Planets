using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
   private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    const float G = 6.6740831e0F;

    static List<Attractor> attractors;

    void FixedUpdate()
    {

	foreach (Attractor attractor in attractors)
	{
	    if (attractor != this)
	    {
		Attract(attractor);
	    }
	}
    }

    void OnEnable()
    {
	if (attractors == null)
	{
	    attractors = new List<Attractor>();
	}
	attractors.Add(this);
    }
    void OnDisable()
    {
	attractors.Remove(this);
    }
    void Attract(Attractor otherAttractor)
    {
	Rigidbody otherRigidbody = otherAttractor.rb;
	Vector3 direction = rb.position - otherRigidbody.position;

	float distance = direction.magnitude;
	
	float forceMagnitude =	G * (rb.mass * otherRigidbody.mass) / Mathf.Pow(distance, 2);

	Vector3 force = direction.normalized * forceMagnitude;

	otherRigidbody.AddForce(force);
    }
}
