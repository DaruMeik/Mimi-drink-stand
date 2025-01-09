using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class NameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private SystemSetting systemSetting;
    private bool legitName = false;
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(inputField.gameObject);
        errorText.text = "";
        legitName = true;
        // Temporarily scrap the leaderboard
        TurnOffPage();
    }
    private void OnDisable()
    {
        Debug.Log("User :" + inputField.text);
        //systemSetting.ChangeUserName(inputField.text);         // Temporarily scrap the leaderboard
        systemSetting.ChangeUserName("Player");
        systemSetting.SaveGame();
        eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
    }
    public void CheckString(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            errorText.text = "Empty Name!";
            return;
        }
        else if (name.Contains("pp"))
        {
            errorText.text = "Inapproriate Name!";
            return;
        }
        else if(name.Length >= 10)
        {
            errorText.text = "Name must be within 10 characters";
            return;
        }
        errorText.text = "";
        legitName = true;
    }
    public void TurnOffPage()
    {
        if(legitName)
            gameObject.SetActive(false);
    }
}
