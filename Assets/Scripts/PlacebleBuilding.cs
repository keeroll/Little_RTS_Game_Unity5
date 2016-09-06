using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacebleBuilding : MonoBehaviour 
{
	[HideInInspector]
	public List<Collider> colliders = new List<Collider>();

	void OnTriggerEnter(Collider currentCollider)
	{
		if (currentCollider.tag == "Building")
			colliders.Add (currentCollider);
	}

	void OnTriggerExit(Collider currentCollider)
	{
		if (currentCollider.tag == "Building")
			colliders.Remove (currentCollider);
	}
}
