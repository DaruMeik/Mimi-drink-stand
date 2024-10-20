using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTutorial : MonoBehaviour
{
    [SerializeField] private FirstDayTutorial firstDayTutorial;
    [SerializeField] private Player player;
    private void Update()
    {
        if (firstDayTutorial.currentPage != 5)
            return;
        if (player.currentItem == "")
        {
            firstDayTutorial.EndTutorial();
            gameObject.SetActive(false);
        }
    }
}
