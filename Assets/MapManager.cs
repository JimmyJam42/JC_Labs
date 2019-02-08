using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 *	Load from file solution testing
 *	Author James Collins
 *
 */

public class MapManager : MonoBehaviour
{
	//GameObject ObjectToLoadFromFile;
	GameObject ObjectToInstantiate;
	public LevelManager levelmanager;

	public int InstantiateCounter;


	public List<String> LevelFilePaths;


	String FirstLevelObject, SecondLevelObject, thridLevelObject, FourthLevelObject;

	public List<GameObject> ListOfActiveGameObjects;

	// Use this for initialization
	void Start()
	{
		//InstantiateObjectLoop(InstantiateCounter, FirstLevelObject);
		InstantiateObjectLoop(InstantiateCounter, LevelFilePaths[0]);
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
					InstantiateCounter = 12;
					//InstantiateObjectLoop(InstantiateCounter, SecondLevelObject);
					InstantiateObjectLoop(InstantiateCounter, LevelFilePaths[1]);
					levelmanager.f = false;
						break;

					case 2:
					LastObjectCleanup();
					InstantiateCounter = 30;
					//InstantiateObjectLoop(InstantiateCounter, thridLevelObject);
					InstantiateObjectLoop(InstantiateCounter, LevelFilePaths[2]);
					levelmanager.f = false;
						break;

					case 3:
					LastObjectCleanup();
					InstantiateCounter = 44;
					//InstantiateObjectLoop(InstantiateCounter, FourthLevelObject);
					InstantiateObjectLoop(InstantiateCounter, LevelFilePaths[3]);
					levelmanager.f = false;
						break;
				}
		}

	}

	void InstantiateObject(String FilePath)
	{
		
		//Instantiates the object, sets a "reference" to that object but this leads to a memory leck so we add it to the list so we can keep that reference
		ObjectToInstantiate = Instantiate(Resources.Load<GameObject>(FilePath), GetRandomLocation(), Quaternion.identity);

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
	void InstantiateObjectLoop(int SpawnCounter, String FilePath)
	{
		for (int i = 0; i < SpawnCounter; i++)
		{
			InstantiateObject(FilePath);
		}
	}

}
