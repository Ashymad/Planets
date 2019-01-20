using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialVelocity : MonoBehaviour
{
    public float initialX = 0F;
    public float initialY = 0F;
    public float initialZ = 0F;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
	rb.velocity = new Vector3(initialX, initialY, initialZ);
    }

}
