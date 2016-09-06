using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISystem : MonoBehaviour 
{

	public GameObject shopMenuPanel;
	public GameObject[] gridPlanes;
	public GameObject exitMenu;
	public Text backToGameButton;
	public Text confirmExitButton;
	public AudioSource mainAudio;
	public Image muteImage;
	public Image unMuteImage;

	void Start()
	{
		exitMenu.SetActive (false);
		backToGameButton.enabled = false;
		confirmExitButton.enabled = false;
		muteImage.enabled = false;
		unMuteImage.enabled = true;
	}

	void Update()
	{
		CheckExitMenu ();
	}

	public void ShowAndHideMenu()
	{
		if (shopMenuPanel.activeSelf) 
			shopMenuPanel.SetActive (false);
		else 
			shopMenuPanel.SetActive (true);
	}

	public void HideMenu()
	{
		if(shopMenuPanel.activeSelf)
			shopMenuPanel.SetActive (false);
	}

	public void ShowAndHideGrid()
	{
		for (int i = 0; i < gridPlanes.Length; i++) 
		{
			if (gridPlanes[i].GetComponent<MeshRenderer> ().enabled == true)
				gridPlanes[i].GetComponent<MeshRenderer> ().enabled = false;
			else
				gridPlanes[i].GetComponent<MeshRenderer> ().enabled = true;
		}
	}

	void CheckExitMenu()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Time.timeScale = 0;
			exitMenu.SetActive (true);
			backToGameButton.enabled = true;
			confirmExitButton.enabled = true;
		}
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void ContinueGame()
	{
		Time.timeScale = 1;
		exitMenu.SetActive (false);
		backToGameButton.enabled = false;
		confirmExitButton.enabled = false;
	}

	public void MuteAndUnmuteAudio()
	{
		if (mainAudio.mute && muteImage.enabled == true) 
		{
			mainAudio.mute = false;
			unMuteImage.enabled = true;
			muteImage.enabled = false;
		}
		else if (!mainAudio.mute && unMuteImage.enabled == true) 
		{
			mainAudio.mute = true;
			unMuteImage.enabled = false;
			muteImage.enabled = true;
		}
	}
}

