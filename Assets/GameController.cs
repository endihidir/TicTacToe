using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public Text[] buttonList; 
    private string playerSide;
    Text oTextColor;
    Text xTextColor;
    int clickCounter;
    public GameObject gameOverPanel;
    public GameObject playAgainButton;
    public Text gameOverText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        //SetGameControllerReferenceOnButtons();
    }
    private void Start()
    {
        ChooseYourSide();
    }

    /*
void SetGameControllerReferenceOnButtons()
{
   for (int i = 0; i < buttonList.Length; i++)
   {
       buttonList[i].GetComponentInParent<GridSpaces>().SetGameControllerReference(this);
   }
}*/
    public void SetPlayerSide(Text childText)
    {

        playerSide = childText.text;
        SetPlayerSideInteractblity(false);
        ChangeSideTextColor();
        ChooseYourSide();
    }

    public void EndTurn()
    {
        clickCounter++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        else if (clickCounter >= 9)
        {
            SetGameOverText("It is a Draw!");
        }
        else
        {
            ChangeSides();
        }
        
    }

    public void PlayAgainButton()
    {
        playAgainButton.SetActive(false);
        gameOverPanel.SetActive(false);
        SetPlayerSideInteractblity(true);
        clickCounter = 0;
        oTextColor.color = Color.black;
        xTextColor.color = Color.black;
        for (int i = 0; i < buttonList.Length; i++)
        {
            ButtonTextsValue(null);
        }
        
    }


    void GameOver()
    {
        ButtonInteractable(false);
        SetGameOverText(playerSide + " Win!");
    }   

    private void SetGameOverText(string condition)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = condition;
        playAgainButton.SetActive(true);     
    }

    private void ButtonTextsValue(string text)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<Text>().text = text;
        }
    }

    private void ButtonInteractable(bool con)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = con;
        }
    }

    void ChangeSides()
    {
        
        playerSide = (playerSide == "X") ? "O" : "X";
        ChangeSideTextColor();
    }

    private void ChangeSideTextColor()
    {
        if (playerSide == "X")
        {
            xTextColor = GameObject.FindGameObjectWithTag("X").GetComponentInChildren<Text>();
            oTextColor = GameObject.FindGameObjectWithTag("O").GetComponentInChildren<Text>();
            oTextColor.color = Color.black;
            xTextColor.color = Color.red;
        }
        if (playerSide == "O")
        {
            oTextColor = GameObject.FindGameObjectWithTag("O").GetComponentInChildren<Text>();
            xTextColor = GameObject.FindGameObjectWithTag("X").GetComponentInChildren<Text>();
            oTextColor.color = Color.red;
            xTextColor.color = Color.black;
        }
    }
    private static void SetPlayerSideInteractblity(bool bl)
    {
        GameObject.FindGameObjectWithTag("X").GetComponent<Button>().interactable = bl;
        GameObject.FindGameObjectWithTag("O").GetComponent<Button>().interactable = bl;
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    private void ChooseYourSide()
    {
        if (playerSide == null)
        {
            ButtonInteractable(false);
        }
        else
        {
            ButtonInteractable(true);
        }
    }
}
