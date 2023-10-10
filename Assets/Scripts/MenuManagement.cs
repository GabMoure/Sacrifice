using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    public bool sair;
    public int level;
    public void load()
    {
        Scene cenaatual = SceneManager.GetActiveScene();
        string cena = cenaatual.name;
        if (cena == "Menu")
        {
            if (sair == true)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(level);
            }
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
