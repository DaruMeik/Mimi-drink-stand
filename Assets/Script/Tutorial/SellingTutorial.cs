using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingTutorial : MonoBehaviour
{
    [SerializeField] private FirstDayTutorial firstDayTutorial;
    [SerializeField] private Player player;
    private void Update()
    {
        if (firstDayTutorial.currentPage != 4)
            return;
        if (player.currentItem == "Hot Coffee")
        {
            firstDayTutorial.NextPage();
            gameObject.SetActive(false);
        }
    }
}
