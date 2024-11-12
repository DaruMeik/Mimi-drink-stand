using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiPage : MonoBehaviour
{
    private int currentPage = 0;
    [SerializeField] private GameObject leftIndicator;
    [SerializeField] private GameObject rightIndicator;
    [SerializeField] private GameObject closeIndicator;
    [SerializeField] private TextMeshProUGUI pageText;
    [SerializeField] private GameObject[] pages;
    [SerializeField] private EventBroadcast eventBroadcast;
    [SerializeField] private bool MustRead = true;
    private void OnEnable()
    {
        currentPage = 0;
        foreach(GameObject page in pages)
        {
            page.SetActive(false);
        }
        pages[currentPage].SetActive(true);
        UpdatePage();
        leftIndicator.SetActive(false);
        rightIndicator.SetActive(false);
        closeIndicator.SetActive(false);
        
        if (pages.Length > 1)
        {
            rightIndicator.SetActive(true);
        }
        else
        {
            closeIndicator.SetActive(true);
            eventBroadcast.ReturnableNoti();
        }
        
        if (!MustRead && !closeIndicator.activeSelf)
        {
            closeIndicator.SetActive(true);
            eventBroadcast.ReturnableNoti();
        }

        eventBroadcast.turnLeft += TurnLeft;
        eventBroadcast.turnRight += TurnRight;
        eventBroadcast.turnOffUI += DisableTutorial;
    }
    private void OnDisable()
    {
        eventBroadcast.turnLeft -= TurnLeft;
        eventBroadcast.turnRight -= TurnRight;
        eventBroadcast.turnOffUI -= DisableTutorial;
    }
    private void TurnLeft()
    {

        if (currentPage > 0)
        {
            pages[currentPage].gameObject.SetActive(false);
            currentPage--;
            pages[currentPage].gameObject.SetActive(true);
            UpdatePage();
            rightIndicator.SetActive(true);
            if(currentPage == 0)
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
        if(currentPage < pages.Length - 1)
        {
            pages[currentPage].gameObject.SetActive(false);
            currentPage++;
            pages[currentPage].gameObject.SetActive(true);
            UpdatePage();
            leftIndicator.SetActive(true);
            if(currentPage == pages.Length - 1)
            {
                rightIndicator.SetActive(false);
                if (!closeIndicator.activeSelf)
                {
                    closeIndicator.SetActive(true);
                    eventBroadcast.ReturnableNoti();
                }
            }
            else
            {
                rightIndicator.SetActive(true);
            }
        }
    }
    private void UpdatePage()
    {
        if(pageText != null)
            pageText.text = "-- " + (currentPage + 1) + "/" + pages.Length + " --";
    }
    private void DisableTutorial()
    {
        gameObject.SetActive(false);
    }
}
