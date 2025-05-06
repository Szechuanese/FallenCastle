using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject UI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("Äã¹ý¹Ø£¡");
            UI.SetActive(true);

            Invoke("ReturnStartScene", 3);
        }
    }

    void ReturnStartScene()
    {
        Application.LoadLevel(0);
    }
}
