using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {
	
	public static void SaveData()
    {		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = new FileStream(Application.persistentDataPath + "/playerData.sav", FileMode.OpenOrCreate);
		
		PlayerData data = new PlayerData();
		if (PlayerPrefs.HasKey("AutoLogin") && PlayerPrefs.GetInt ("AutoLogin") == 1)
        {			
			data.dbuserkey = DBManager.userkey;
			data.dbusername = DBManager.username;
		}else
        {
			data.dbuserkey = null;
			data.dbusername = null;
		}
		
		bf.Serialize(file, data);
		Debug.Log ("\n Data saved.");
		file.Close();		
	}
	public static void LoadData()
    {		
		if (File.Exists(Application.persistentDataPath + "/playerData.sav"))
        {			
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = new FileStream(Application.persistentDataPath + "/playerData.sav", FileMode.Open);
		
			PlayerData data = bf.Deserialize(file) as PlayerData;
			DBManager.userkey = data.dbuserkey;
			DBManager.username = data.dbusername;
			
			Debug.Log ("\n Data loaded.");
			file.Close ();
		}else
        {			
			Debug.Log("File does not exist.");
			DBManager.userkey = null;
			DBManager.username = null;
		}
	}
}

[Serializable]
public class PlayerData
{	
	public string dbuserkey;
	public string dbusername;
}