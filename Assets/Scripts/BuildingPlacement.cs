using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingPlacement : MonoBehaviour 
{
	private Transform currentBuilding;
	Camera playerCamera;
	private bool hasPlaced;
	private PlacebleBuilding placebleBuilding;

	void Start () 
	{
		playerCamera = GetComponent<Camera> ();
	}
	

	void Update () 
	{

		if (currentBuilding != null && hasPlaced == false) 
		{
			Vector3 theMousePosition = Input.mousePosition;
			theMousePosition = new Vector3 (theMousePosition.x, theMousePosition.y, transform.position.y);
			Vector3 convertMousePosition = playerCamera.ScreenToWorldPoint (theMousePosition);
			currentBuilding.position = new Vector3 (convertMousePosition.x, 0, convertMousePosition.z);
		}

		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject()) 
			if (IsItLegaLPosition ()) 
				hasPlaced = true;

		if (Input.GetMouseButtonDown (1) && placebleBuilding.colliders.Count > 0) 
		{
			DestroyObject(currentBuilding.transform.gameObject);
			currentBuilding = null;
			hasPlaced = true;

		}
	}

	bool IsItLegaLPosition()
	{
		if (placebleBuilding.colliders.Count > 0)
			return false;
		else
			return true;
	}

	public void SetItem(GameObject building)
	{
		Debug.Log (building.name);
		currentBuilding = ((GameObject)Instantiate (building)).transform;
		hasPlaced = false;
		placebleBuilding = currentBuilding.GetComponent<PlacebleBuilding> ();
	}
}
