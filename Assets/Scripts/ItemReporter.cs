using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemReporter : MonoBehaviour
{
    public ItemData[] allItems;
    public TextMeshProUGUI[] reportText;

    [SerializeField] private int scoreToWin;
    [SerializeField] private TextMeshProUGUI Result;


    private void Start()
    {
        Cursor.visible = true;
        if (GameManager.Instance.score >= scoreToWin)
        {
            Result.text = "You Win!";
        }
        else
        {
            Result.text = "You Lose!";
        }



        for (int i = 0; i < reportText.Length; i++)
        {
            for (int j = 0; j < allItems.Length; j++)
            {
                if (i == j)
                {
                    reportText[i].text = " x " + allItems[i].counter;

                }

            }
        }

    }
}
