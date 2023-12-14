using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate_Puzzle : MonoBehaviour
{
    public bool Isinteract;
    private string PuzzleScene = "Locker_Puzzle";
    void OnEnable()
    {
        if (Isinteract == true)
        {
            SceneManager.LoadScene("Locker_Puzzle");
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == PuzzleScene)
        {
            
        }
    }   
}
