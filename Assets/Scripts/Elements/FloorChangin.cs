using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChangin : MonoBehaviour
{
    /*
    private bool hasEntered;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (hasEntered == true)
        {
            Scene scene = SceneManager.GetActiveScene();
            ChangeRoom(scene);
        }
    }

   void OnTriggerEnter(Collider collider)
   {
        if (collider.gameObject.tag == "Player")
        {
            hasEntered = !hasEntered;
        }
   }

   void OnTriggerExit(Collider collider)
   {
        if (collider.gameObject.tag == "Player")
        {
            hasEntered = !hasEntered;
        }
   }

   void ChangeRoom(Scene scene)
   {
        if (scene.name == "Apartamento_1" || scene.name == "Apartamento_1d")
        {
            SceneManager.LoadScene("Apartamento_2");          
        }


        if (scene.name == "Apartamento_2")
        {
            SceneManager.LoadScene("Apartamento_1d");
        }
        hasEntered = false;
   }*/
   public string scenename;
   void OnTriggerEnter(Collider collider)
   {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scenename);
        }
   }
}
