using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour {

	public Text playerName;

	public void OnEnable()
    {		
		if(DBManager.username != null)
        {			
			playerName.text = DBManager.username;			
		}
	}

	public void PlayGame()
    {		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);		
	}

	public void Logout()
    {		
		DBManager.LogOut();		
	}
}
