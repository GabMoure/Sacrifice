using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestOrder : MonoBehaviour
{
    public bool isgone = false;
    public int armazen;
    public int generalOrder;
    public FadeScript fade;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Update()
    {
        fade = FindObjectOfType<FadeScript>();
        if (generalOrder == 4)
        {
            if (isgone == false)
            {
                StartCoroutine(ChangeScene());
                isgone = true;
            }
        }
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("OutDoor 1");
        fade.FadeOut();
    }
}
