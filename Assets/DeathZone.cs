using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField]
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverPage");
        }





    }
}

