using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleDayAndNightCycle : MonoBehaviour 
{
	public Slider dayNightSlider;
	public Transform sceneLight;
	float timeForPartOfDay = 6000f;
	public Image fillColor;
	float speedOfLight = 0.025f;
	public GameObject[] streetLamps;

	void Start () 
	{
		dayNightSlider.value = timeForPartOfDay;
		InvokeRepeating ("ChangeDayAndNight", 0f, 0.01f);
		fillColor.color = Color.blue;
	}
	

	void Update () 
	{
		EnableAndDisableStreetLamps ();
	}

	void ChangeDayAndNight()
	{
		dayNightSlider.value -= 1f;
		sceneLight.Rotate (speedOfLight, 0f, 0f);

		if (dayNightSlider.value == 0f && fillColor.color == Color.blue) 
		{
			dayNightSlider.value = timeForPartOfDay;
			fillColor.color = Color.black;
			speedOfLight = 0.035f;
		} 
		else if (dayNightSlider.value == 0f && fillColor.color == Color.black) 
		{
			dayNightSlider.value = timeForPartOfDay;
			fillColor.color = Color.blue;
			speedOfLight = 0.025f;
		}
	}

	void EnableAndDisableStreetLamps()
	{
		for (int i = 0; i < 7; i++) 
		{
			if (streetLamps [i].activeSelf && fillColor.color == Color.blue)
				streetLamps [i].SetActive (false);
			else if (!streetLamps [i].activeSelf && fillColor.color == Color.black)
				streetLamps [i].SetActive (true);
		}
	}

}
