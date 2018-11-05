using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridSpaces : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerSide;

    private GameController gameController;
    
    public void SetSpace()
    {
        gameController = FindObjectOfType<GameController>(); //Yorum satırı olanlar yerine bunu yazdım çalıştı ancak hala neden aşağıdaki şekilde bir kullanımda bulunduğunu anlamadım.
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
    /*
    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }*/

}
