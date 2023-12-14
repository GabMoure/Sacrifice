using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    public void load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // proxima cena na fila
    }
    public void quit()
    {
        //Debug.Log("Saiu");
        Application.Quit();
    }
}
