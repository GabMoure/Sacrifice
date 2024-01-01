using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Locker_Script : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject container, yesnt;
    [SerializeField] TMP_InputField input;
    private Item_Script itemscript;
    public bool isActive, Completed, open;
    void Start()
    {
        itemscript = GetComponent<Item_Script>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EnterScene()
    {
        if (container.activeSelf == false)
        {
            container.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isActive = true;
        }
        else
        {
            container.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isActive = false;
        }
    }

    public void ButtonEnter()
    {
        if (input.text != "1926")
        {
            StartCoroutine(falhou());
        }
        else
        {
            open = !open;
            EnterScene();
            animator.SetBool("Open", open);
            itemscript.enabled = false;
            GetComponent<Collider>().enabled = false;
            Completed = true;
        }
    }

    public IEnumerator falhou()
    {
        yesnt.SetActive(true);
        yield return new WaitForSeconds(3f);
        yesnt.SetActive(false);
        EnterScene();
    }
}
