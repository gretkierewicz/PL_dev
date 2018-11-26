using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class MainMenu : MonoBehaviour {
	
	public GameObject playMenu;
	public GameObject loginMenu;

    private Component[] buttons;
    public Sprite buttonTexture;
    public Sprite buttonOverTexture;

    public void ApplyChanges()
    {
        buttons = GetComponentsInChildren(typeof(Button), true);
        foreach(Button button in buttons)
        {
            button.image.color = new Color32(255, 255, 255, 255);
            //button.image.rectTransform.sizeDelta = new Vector2(400, 100);
            button.image.sprite = buttonTexture;

            Text tmptext = button.GetComponentInChildren<Text>();
            tmptext.color = new Color32(94, 47, 16, 255);
            tmptext.fontStyle = FontStyle.Normal;
            tmptext.fontSize = 60;

            button.transition = Selectable.Transition.SpriteSwap;
            SpriteState st = new SpriteState();
            st.highlightedSprite = buttonOverTexture;
            st.pressedSprite = buttonOverTexture;
            st.disabledSprite = null;
            button.spriteState = st;

            //ColorBlock cb = button.colors;
            //cb.normalColor = new Color32(255, 255, 255, 255);
            //cb.highlightedColor = new Color32(255, 255, 255, 200);
            //cb.disabledColor = new Color32(255, 255, 255, 120);
            //button.colors = cb;
        }
    }

    public void Start()
    {
        //this.ApplyChanges();

        SaveLoadManager.LoadData();
		if(DBManager.username != null && DBManager.userkey != null)
        {			
			playMenu.SetActive(true);
			loginMenu.SetActive(false);			
		}
	}

	public void QuitGame()
    {		
		Debug.Log("Quit game.");
		
		SaveLoadManager.SaveData();
		Application.Quit();		
	}
}
