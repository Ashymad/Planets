﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1F;
    public float rotSpeed = 0.01F;
    public float volumeStep = 0.1F;

    private Rigidbody rb;
    private ParticleSystem.EmissionModule em;
    private AudioSource aso;
    private Transform diamondTransform;
    private Transform cameraTransform;

    void Start ()
    {
	rb = GetComponent<Rigidbody>();
	em = GetComponent<ParticleSystem>().emission;
	aso = GetComponent<AudioSource>();
	em.enabled = false;
	aso.volume = 0;
	cameraTransform = transform.GetChild(0);
	diamondTransform = cameraTransform.GetChild(1);
    }

    void FixedUpdate()
    {
	var verticalAxis = Input.GetAxis ("Vertical");

	em.enabled = verticalAxis > 0;
	if (verticalAxis > 0 && !aso.isPlaying)
	{
	    aso.Play();
	}
	else if (verticalAxis > 0 && aso.isPlaying && aso.volume < 1)
	{
	    aso.volume += Time.fixedDeltaTime*volumeStep;
	}
	else if (verticalAxis <= 0 && aso.isPlaying)
	{
	    if (aso.volume >= Time.fixedDeltaTime*volumeStep)
	    {
		aso.volume -= Time.fixedDeltaTime*volumeStep;
	    }
	    else
	    {
		aso.Stop();
	    }
	}

	Vector3 move = transform.forward*2*verticalAxis;
	move += transform.right * Input.GetAxis ("Horizontal");
	move += transform.up * Input.GetAxis("Depthical");

	rb.AddForce (move * speed);

	Vector3 rot = transform.up * Input.GetAxis ("Horizontal2");
	rot += transform.right * Input.GetAxis ("Vertical2");
	rot += -transform.forward * Input.GetAxis("Depthical2");

	rb.AddTorque (rot * rotSpeed);

	diamondTransform.localPosition = diamondTransform.localPosition.magnitude * cameraTransform.InverseTransformDirection(rb.velocity).normalized;
	diamondTransform.LookAt(cameraTransform);
    }
}
