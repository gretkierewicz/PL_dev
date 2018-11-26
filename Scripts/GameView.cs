using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour {

	public void QuitGame()
    {		
		Debug.Log("Quit game.");
		Application.Quit();		
	}
}
