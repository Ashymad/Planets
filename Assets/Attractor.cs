using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rigidbody;

    const float G = 6.6740831e-11F;

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
	Rigidbody otherRigidbody = otherAttractor.rigidbody;
	Vector3 direction = rigidbody.position - otherRigidbody.position;

	float distance = direction.magnitude;
	
	float forceMagnitude =	G * (rigidbody.mass * otherRigidbody.mass) / Mathf.Pow(distance, 2);

	Vector3 force = direction.normalized * forceMagnitude;

	otherRigidbody.AddForce(force);
    }
}
