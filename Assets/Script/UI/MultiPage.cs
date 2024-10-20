using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPage : MonoBehaviour
{
    private int currentPage = 0;
    [SerializeField] private GameObject leftIndicator;
    [SerializeField] private GameObject rightIndicator;
    [SerializeField] private GameObject[] pages;
    [SerializeField] private EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        currentPage = 0;
        foreach(GameObject page in pages)
        {
            page.SetActive(false);
        }
        pages[currentPage].SetActive(true);
        leftIndicator.SetActive(false);
        rightIndicator.SetActive(false);
        if(pages.Length > 1)
            rightIndicator.SetActive(true);

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
            leftIndicator.SetActive(true);
            if(currentPage == pages.Length - 1)
            {
                rightIndicator.SetActive(false);
            }
            else
            {
                rightIndicator.SetActive(true);
            }
        }
    }
    private void DisableTutorial()
    {
        gameObject.SetActive(false);
    }
}
