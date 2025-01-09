using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    private int currentPage = 0;
    [SerializeField] private GameObject leftIndicator;
    [SerializeField] private GameObject rightIndicator;
    [SerializeField] private Image[] stars;
    [SerializeField] private Sprite[] starSprites;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private EventBroadcast eventBroadcast;
    private GameObject lastSelectedObj;
    private void OnEnable()
    {
        currentPage = 0;
        UpdatePage();
        leftIndicator.SetActive(false);
        rightIndicator.SetActive(false);
        if (systemSetting.highestScores.Count > 1)
        {
            rightIndicator.SetActive(true);
        }
        lastSelectedObj = eventSystem.currentSelectedGameObject;
        eventSystem.SetSelectedGameObject(null);
        eventBroadcast.turnOffUI += Return;
    }
    private void OnDisable()
    {
        eventSystem.SetSelectedGameObject(lastSelectedObj);
        eventBroadcast.turnOffUI -= Return;
    }

    private void Update()
    {
        if (systemSetting.PressLeft())
            TurnLeft();
        else if (systemSetting.PressRight())
            TurnRight();
        else if (systemSetting.PressEast())
            Return();
        else if (systemSetting.PressSouth())
            SelectStage();
    }
    private void TurnLeft()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
            rightIndicator.SetActive(true);
            if (currentPage == 0)
            {
                leftIndicator.SetActive(false);
            }
            else
            {
                leftIndicator.SetActive(true);
            }
        }
    }
    private void TurnRight()
    {
        if (currentPage < systemSetting.highestScores.Count - 1)
        {
            currentPage++;
            UpdatePage();
            leftIndicator.SetActive(true);
            if (currentPage == systemSetting.highestScores.Count - 1)
            {
                rightIndicator.SetActive(false);
            }
            else
            {
                rightIndicator.SetActive(true);
            }
        }
    }
    public void Return()
    {
        gameObject.SetActive(false);
    }
    public void SelectStage()
    {
        systemSetting.currentRound = currentPage;
        SceneManager.LoadScene("Day" + systemSetting.currentRound);
    }
    private void UpdatePage()
    {
        string menu = "";
        switch (currentPage)
        {
            case 0:
                menu += "<sprite name=ItemSprite_19>  <sprite name=ItemSprite_24>\n";
                break;
            case 1:
                menu += "<sprite name=ItemSprite_19>  <sprite name=ItemSprite_21>  <sprite name=ItemSprite_24>  <sprite name=ItemSprite_26>\n";
                break;
            case 2:
                menu += "<sprite name=ItemSprite_19>  <sprite name=ItemSprite_21>  <sprite name=ItemSprite_24>  <sprite name=ItemSprite_26>  <sprite name=ItemSprite_27>\n";
                break;
            case 3:
                menu += "<sprite name=ItemSprite_19>  <sprite name=ItemSprite_24>  <sprite name=ItemSprite_27>\n";
                break;
            case 4:
                menu += "<sprite name=ItemSprite_28>  <sprite name=ItemSprite_29>  <sprite name=ItemSprite_30>\n";
                break;
            case 5:
                menu += "<sprite name=ItemSprite_19>  <sprite name=ItemSprite_21>  <sprite name=ItemSprite_24>  <sprite name=ItemSprite_26>  <sprite name=ItemSprite_28>  <sprite name=ItemSprite_29>  <sprite name=ItemSprite_30>\n";
                break;
        }

        textMesh.text = "<align=center>-- <u>Day "+ (currentPage+1) +"</u> --</align>\n";
        textMesh.text += "-Menu: "+ menu +"\n";
        textMesh.text += "-Highscore: " + systemSetting.highestScores[currentPage] + "\n\n";
        textMesh.text += "-Rating: ";
        foreach (Image img in stars)
        {
            img.sprite = starSprites[1];
        }
        if(systemSetting.highestScores[currentPage] >= 1500)
        {
            stars[0].sprite = starSprites[0];
        }
        if (systemSetting.highestScores[currentPage] >= 3000)
        {
            stars[1].sprite = starSprites[0];
        }
        if (systemSetting.highestScores[currentPage] >= 4500)
        {
            stars[2].sprite = starSprites[0];
        }
    }
}
