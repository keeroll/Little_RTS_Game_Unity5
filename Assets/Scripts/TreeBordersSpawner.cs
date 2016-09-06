using UnityEngine;
using System.Collections;

public class TreeBordersSpawner : MonoBehaviour 
{
	public GameObject[] prefab;

	void Start() 
	{
		EnviromentSpawn (50, 100, 50, 400);
		EnviromentSpawn (50, 400, 50, 100);
		EnviromentSpawn (400, 450, 50, 400);
		EnviromentSpawn (50, 450, 400, 450);
    }

	void EnviromentSpawn(int currentPositionX, int borderX, int currentPositionY, int borderY)
	{
		for (int x = currentPositionX; x < borderX; x += Random.Range(8,12)) 
		{
			for (int y = currentPositionY; y < borderY; y += Random.Range(18, 40)) 
			{
				int prefabIndex = Random.Range (0, prefab.Length);
				Instantiate (prefab[prefabIndex], new Vector3 (x, 0, y), Quaternion.identity);
			}
		}
	}
}