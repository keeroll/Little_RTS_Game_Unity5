using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeginTheGame : MonoBehaviour 
{
	[SerializeField]
	private GameObject description;
	[SerializeField]
	private GameObject menu;

	void Start () 
	{
		Time.timeScale = 0;
		description.SetActive (true);
		menu.SetActive (false);
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.F) && description.activeSelf && !menu.activeSelf) 
		{
			description.SetActive (false);
			Time.timeScale = 1;
			menu.SetActive (true);
		}
	}
	

}
