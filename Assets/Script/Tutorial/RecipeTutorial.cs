using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeTutorial : MonoBehaviour
{
    [SerializeField] private FirstDayTutorial firstDayTutorial;
    [SerializeField] private MultiPage recipePage;
    private void Update()
    {
        if (firstDayTutorial.currentPage != 0)
            return;
        if (recipePage.gameObject.activeSelf)
        {
            firstDayTutorial.NextPage();
            gameObject.SetActive(false);
        }
    }
}
