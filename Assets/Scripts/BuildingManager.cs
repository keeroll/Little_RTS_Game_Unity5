using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour 
{
	public GameObject[] buildings;
	private BuildingPlacement buildingPlacement;

	void Start () 
	{
		buildingPlacement = GetComponent<BuildingPlacement> ();
	}

	public void OnTowerButtonClick()
	{
		buildingPlacement.SetItem (buildings [0]);
	}

	public void OnTentButtonClick()
	{
		buildingPlacement.SetItem (buildings [1]);
	}

	public void OnHouseButtonClick()
	{
		buildingPlacement.SetItem (buildings [2]);
	}
}
