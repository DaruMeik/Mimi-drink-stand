using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DayEndResult : MonoBehaviour
{
    public bool daySuccess = false;
    [SerializeField] protected TextMeshProUGUI textMesh;
    [SerializeField] protected DayLogic dayLogic;
    [SerializeField] protected SystemSetting systemSetting;
    [SerializeField] protected EventBroadcast eventBroadcast;
    [SerializeField] private GameObject[] stars;
    [SerializeField] private GameObject[] successButton;
    [SerializeField] private GameObject[] failButton;
    [SerializeField] private Sprite[] starSprite;
    private void OnEnable()
    {
        UpdateEndScreen();
    }
    public virtual void UpdateEndScreen()
    {
        if (daySuccess)
        {
            foreach (GameObject gObj in successButton)
            {
                gObj.SetActive(true);
            }
            foreach (GameObject gObj in failButton)
            {
                gObj.SetActive(false);
            }
            textMesh.text = "";
            textMesh.text += "<align=center>-- Day " + systemSetting.currentRound + " result --</align>\n";
            textMesh.text += "- Today earning: " + dayLogic.currentMoney + "\n";
            textMesh.text += "- Failed order: " + (3 - dayLogic.HP) + "\n";
            textMesh.text += "-------------------------\n";
            textMesh.text += "- Total earning: " + (dayLogic.currentMoney + systemSetting.totalMoney) + "\n\n";
            textMesh.text += "- Rating: ";

            // Check star
            int starNum = 1;
            if (dayLogic.HP == 3)
                starNum++;
            if (dayLogic.currentMoney > 4500)
                starNum++;
            for(int i = 0; i < 3; i++)
            {
                if (i < starNum)
                    stars[i].GetComponent<Image>().sprite = starSprite[0];
                else
                    stars[i].GetComponent<Image>().sprite = starSprite[1];
            }
        }
        else
        {
            foreach (GameObject gObj in successButton)
            {
                gObj.SetActive(false);
            }
            foreach (GameObject gObj in failButton)
            {
                gObj.SetActive(true);
            }
            foreach (GameObject gObj in stars)
            {
                gObj.SetActive(false);
            }
            textMesh.text = "";
            textMesh.text += "<align=center>Game over</align>\n";
            textMesh.text += "- The customers weren't satisfied with your service.\n";
            textMesh.text += "- Try to be faster and more accurate next time.\n";
            textMesh.text += "- Let's try again!\n";
        }
    }
    public void NextLevel()
    {
        if (daySuccess)
        {
            systemSetting.currentRound++;
            systemSetting.totalMoney += dayLogic.currentMoney;
        }
        Retry();
    }
    public void Retry()
    {
        if(systemSetting.currentRound < 4)
            SceneManager.LoadScene("Day" + systemSetting.currentRound);
        else
            SceneManager.LoadScene("GameOverScene");
    }
}