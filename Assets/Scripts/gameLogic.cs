using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    //private MenuManager _menuManager;
    private int player1 = 0;
    private int player2 = 0;
    public TextMeshProUGUI textPlayer1;
    public TextMeshProUGUI textPlayer2;

    void OnCollisionEnter(Collision collision) {
        if( collision.gameObject.tag.Equals("player1") == true ){
            Debug.Log("player1");
            player1++;
            textPlayer1.text = player1.ToString();
        }
        if( collision.gameObject.tag.Equals("player2") == true ){
            Debug.Log("player2");
            player2++;
            textPlayer2.text = player1.ToString();
        }

        /*
         if (player1==3)
        {
            _menuManager.OnWin(true);
        }

        if (player2 == 3)
        {
            _menuManager.OnWin(false);
        }
        */
    }
}