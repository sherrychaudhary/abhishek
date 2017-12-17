using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeseason : MonoBehaviour
{

    public Text Season;
    static int Score = 0;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            Score++;
            Season.text = "level 2";

        }
    }
}