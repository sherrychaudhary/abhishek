using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    [SerializeField]

    public Text ScoreText;

    static int score = 0;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            score = score + 1;
            ScoreText.text = "Coins:" + score;
        }
    }
}
