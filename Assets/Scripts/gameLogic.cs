using UnityEngine;

public class gameLogic : MonoBehaviour{
    private int player1 = 0;
    private int player2 = 0;
    void OnCollisionEnter(Collision collision) {
        if( collision.gameObject.tag.Equals("player1") == true ){
            Debug.Log("player1");
            player1++;
        }
        if( collision.gameObject.tag.Equals("player2") == true ){
            Debug.Log("player2");
            player2++;
        }
    }
}