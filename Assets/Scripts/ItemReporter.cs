using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ItemReporter : MonoBehaviour
{
    public ItemData[] allItems;
    public TextMeshProUGUI[] reportText;

    [SerializeField] private int scoreToWin;
    [SerializeField] private TextMeshProUGUI Result;
    [SerializeField] private AudioSource endSound;

    private void Start()
    {
        Cursor.visible = true;
        if (GameManager.Instance.score >= scoreToWin)
        {
            endSound = GameObject.Find("Win").GetComponent<AudioSource>();
            endSound.Play();
            Result.text = "You Win!";
        }
        else
        {
            endSound = GameObject.Find("Lose").GetComponent<AudioSource>();
            endSound.Play();
            Result.text = "You Lose!";
        }



        for (int i = 0; i < reportText.Length; i++)
        {
            for (int j = 0; j < allItems.Length; j++)
            {
                if (i == j)
                {
                    reportText[i].text = allItems[i].itemPoints + " x " + allItems[i].counter;
                    reportText[i].outlineColor = new Color(0, 0, 0, 1);
                    reportText[i].outlineWidth = 0.5f;
                }

            }
        }

    }
}
