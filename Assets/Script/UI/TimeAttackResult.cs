using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TimeAttackResult : DayEndResult
{
    public override void UpdateEndScreen()
    {

        textMesh.text = "";
        textMesh.text += "<align=center>-- Time attack result --</align>\n";
        textMesh.text += "- Today earning: " + dayLogic.currentMoney + "\n";
        textMesh.text += "- Failed order: " + (3 - dayLogic.HP) + "\n";
        textMesh.text += "-------------------------\n";
        textMesh.text += "- Highest earning: " + systemSetting.highestScores[0] + "\n\n";
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void RetryExtra()
    {
        SceneManager.LoadScene("Extra");
    }
}