using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public MenuManager menuManager;
    private MenuManager _menuManagerInstance;
    private int player1 = 0;
    private int player2 = 0;
    public TextMeshProUGUI textPlayer1;
    public TextMeshProUGUI textPlayer2;
    public TextMeshProUGUI textWinner;
    public GameObject player1Object;
    public GameObject player2Object;
    private PlayerScript _player1Script;
    private PlayerScript _player2Script;

    void OnCollisionEnter(Collision collision) {
        if( collision.gameObject.tag.Equals("player1") == true ){
            Debug.Log("player1");
            player1++;
            textPlayer1.text = player1.ToString();
            RespawnAll();
        }
        if( collision.gameObject.tag.Equals("player2") == true ){
            Debug.Log("player2");
            player2++;
            textPlayer2.text = player2.ToString();
            RespawnAll();
        }

        _menuManagerInstance = menuManager.GetComponent<MenuManager>();

        if (player1==3)
        {
            textWinner.text = "Player 1 wins!";
            _menuManagerInstance.OnWin();
        }

        if (player2==3)
        {   
            textWinner.text = "Player 2 wins!";
            _menuManagerInstance.OnWin();

        }
    }
    
    private void RespawnAll ()
    {
        _player1Script = player1Object.GetComponent<PlayerScript>();
        _player2Script = player2Object.GetComponent<PlayerScript>();
        _player1Script.Respawn(); 
        _player2Script.Respawn();
    }
}