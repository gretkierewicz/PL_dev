using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoginForm : MonoBehaviour {

	public GameObject loginForm;
	public GameObject playMenu;

	public InputField loginField;
	public InputField passwordField;
	public Toggle autoLoginToggle;

	public Button submitButton;
	public Text submitButtonText;

    public Text prompt;

    public void OnEnable()
    {	
		if (PlayerPrefs.GetInt("AutoLogin") == 1)
        {			
			autoLoginToggle.isOn = true;
		}else
        {				
			autoLoginToggle.isOn = false;
		}
	}

    public void Start()
    {
        prompt.text = "";
        this.VerifyInputs();
    }

    public void saveAutoLogin()
    {	
		if (autoLoginToggle.isOn)
        {		
			PlayerPrefs.SetInt("AutoLogin", 1);
		}else
        {			
			PlayerPrefs.SetInt("AutoLogin", 0);
		}
	}

	public void CallLogin()
    {		
		StartCoroutine(Login());		
	}

	IEnumerator Login()
    {		
		WWWForm form = new WWWForm();
		form.AddField("login", loginField.text);
		form.AddField("password", passwordField.text);
		WWW www = new WWW("https://az-serwer1803583.online.pro/punylords/login.php", form);
		yield return www;
		if (www.text != null && www.text.Length != 0 && www.text[0] == '0')
        {			
			Debug.Log("User logged in successfully.");
			DBManager.username = loginField.text;
			DBManager.userkey = www.text.Split('\t')[1];
			SaveLoadManager.SaveData();
			yield return new WaitForSeconds(.5f);
			playMenu.SetActive(true);
			loginForm.SetActive(false);			
		}else
        {		
			Debug.Log("User login failed. Error# " + www.text);
            if (www.text == null || www.text.Length == 0)
            {
                prompt.text = "Connection failed.";
            }
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

	public void VerifyInputs()
    {		
		if (loginField.text.Length > 0 && passwordField.text.Length > 0)
        {			
			submitButton.interactable = true;
			submitButtonText.color = new Color32(94, 47, 16, 255);			
		}else
        {			
			submitButton.interactable = false;
			submitButtonText.color = new Color32(94, 47, 16, 100);			
		}
	}
}
