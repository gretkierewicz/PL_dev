using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RegisterForm : MonoBehaviour {

	public GameObject registerForm;
	public GameObject loginMenu;

	public InputField loginField;
	public InputField passwordField;
    public InputField repeatPassField;

    private Button submitButton;
	public Text submitButtonText;

	public Text prompt;

	public void Start()
    {
        prompt.text = "";
        this.VerifyInputs();
    }

	public void CallRegister()
    {		
		StartCoroutine(Register());		
	}

	IEnumerator Register()
    {
        if (passwordField.text == repeatPassField.text)
        {
            WWWForm form = new WWWForm();
            form.AddField("login", loginField.text);
            form.AddField("password", passwordField.text);
            WWW www = new WWW("https://az-serwer1803583.online.pro/punylords/register.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("User created successfully.");
                prompt.text = "User created successfully.";
                yield return new WaitForSeconds(2);
                loginMenu.SetActive(true);
                registerForm.SetActive(false);
            }
            else
            {
                Debug.Log("User creation failed. Error #" + www.text);
                if (www.text == null || www.text.Length == 0)
                {
                    prompt.text = "Connection failed.";
                }else
                {
                    prompt.text = www.text.Split('\t')[1];
                }
            }
        }
        else
        {
            Debug.Log("User creation failed. Passwords do not match.");
            prompt.text = "Passwords do not match!";
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

	public void VerifyInputs()
    {
        submitButton = GameObject.Find("RegisterButton").GetComponent<Button>();

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
