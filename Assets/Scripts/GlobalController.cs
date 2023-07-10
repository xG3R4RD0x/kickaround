using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GlobalController : MonoBehaviour
{

	public static GlobalController global;
	public SaveGame globalVariables = new SaveGame();
	public bool intersReady = true;
	int interCounter = 0;
	public bool logedIn = false;

	void Awake()
	{
		global = this;
		// Forces a different code path in the BinaryFormatter that doesn't rely on run-time code generation (which would break on iOS).
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		DontDestroyOnLoad(gameObject);
		//PlayGamesPlatform.Activate();
		Load();
	}

	void Start()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/savegame.rtb");

		SaveData save = new SaveData();

		//Global Variables
		save.currentHigh = globalVariables.currentHigh;
		save.total = globalVariables.total;

		bf.Serialize(file, save);
		file.Close();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/savegame.rtb"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savegame.rtb", FileMode.Open);

			SaveData save = (SaveData)bf.Deserialize(file);

			//Global Variables
			globalVariables.currentHigh = save.currentHigh;
			globalVariables.total = save.total;
			
		}
		else
		{
			//Global Variables
			globalVariables.currentHigh = 0;
			globalVariables.total = 0;
			
		}
	}

	

	[Serializable]
	class SaveData
	{

		public int currentHigh;
		public int total;

		public SaveData()
		{

		}

	}
}






