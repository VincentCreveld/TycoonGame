using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	public Transform objToFollow;
	[Range(0,1f)]
	public float smoothing;
	private Vector3 offset;

	private void Awake()
	{
		offset = transform.position - objToFollow.position;
	}

	private void Update()
	{
		transform.position = Vector3.Slerp(transform.position, objToFollow.position + offset, smoothing);
	}
}
