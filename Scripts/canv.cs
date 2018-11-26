using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canv : MonoBehaviour {

    public void QuitGame()
    {
        Debug.Log("Quit game.");
        
        Application.Quit();
    }
}
