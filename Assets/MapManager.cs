using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 *	Load fro
 *
 */

public class MapManager : MonoBehaviour
{
	//GameObject ObjectToLoadFromFile;
	GameObject ObjectToInstantiate;
	public LevelManager levelmanager;

	public int SpawnCounter;

	//
	public String FirstLevelObject;
	public String SecondLevelObject;
	public String thridLevelObject;
	public String FourthLevelObject;

	public List<GameObject> ListOfActiveGameObjects;

	// Use this for initialization
	void Start()
	{
		SpawnLoop(SpawnCounter, FirstLevelObject);
	}

	// Update is called once per frame
	void Update()
	{
		if (levelmanager.f)
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				levelmanager.GameLevel = 0;
			}
			switch (levelmanager.GameLevel)
				{
					case 1:
					LastObjectCleanup();
					SpawnCounter = 12;
					SpawnLoop(SpawnCounter, SecondLevelObject);
					levelmanager.f = false;
						break;

					case 2:
					LastObjectCleanup();
					SpawnCounter = 30;
					SpawnLoop(SpawnCounter, thridLevelObject);
					levelmanager.f = false;
						break;

					case 3:
					LastObjectCleanup();
					SpawnCounter = 44;
					SpawnLoop(SpawnCounter, FourthLevelObject);
					levelmanager.f = false;
						break;
				}
		}

	}

	void SpwanMap(String FilePath)
	{
		//This loads the object from a file path
		//ObjectToLoadFromFile = Resources.Load<GameObject>("Shapes/" + FilePath);
		//ObjectToInstantiate = Instantiate(ObjectToLoadFromFile, GetRandomLocation(), Quaternion.identity);
		
		//The above is another way of writing this function

		//Instantiates the object, sets a "reference" to that object but this leads to a memory leck so we add it to the list so we can keep that reference
		ObjectToInstantiate = Instantiate(Resources.Load<GameObject>("Shapes/" + FilePath), GetRandomLocation(), Quaternion.identity);

		ListOfActiveGameObjects.Add(ObjectToInstantiate);
	}

	//Only made for testing perporse, no need for it in the project.
	//DO NOT ADD
	Vector3 GetRandomLocation()
	{
		float x = Random.Range(-10.0f, 10.0f);
		float y = Random.Range(-10.0f, 10.0f);
		float z = Random.Range(-10.0f, 10.0f);

		return new Vector3(x,y,z);
	}

	//Written for testing solution, Might be needed for project implementation.
	//
	void LastObjectCleanup()
	{
		foreach (var VARIABLE in ListOfActiveGameObjects)
		{
			Destroy(VARIABLE);
		}

		ListOfActiveGameObjects.Clear();
	}

	//Does what is says it does, pass the number of objects you want to instantiate and the file path.
	void SpawnLoop(int SpawnCounter, String FilePath)
	{
		for (int i = 0; i < SpawnCounter; i++)
		{
			SpwanMap(FilePath);
		}
	}

}
