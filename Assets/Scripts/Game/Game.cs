using UnityEngine;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();

        //Wrecking Ball & Coin
        Physics2D.IgnoreLayerCollision(8, 9);

        //Zombie & Coin
        Physics2D.IgnoreLayerCollision(7, 9);

        //Coin & Coin
        Physics2D.IgnoreLayerCollision(9, 9);

        //Zombie & Zombie
        Physics2D.IgnoreLayerCollision(7, 7);

        //NPC & NPC
        Physics2D.IgnoreLayerCollision(10, 10);

        //NPC & Wrecking Ball
        Physics2D.IgnoreLayerCollision(10, 8);

        //NPC & Coin
        Physics2D.IgnoreLayerCollision(10, 9);
    }
}
