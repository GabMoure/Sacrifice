using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Abrir_Alcapao : MonoBehaviour
{
    [SerializeField] Animator anim1, anim2;

    [SerializeField] GameObject cadeado,peca;
    [SerializeField] Transform T1, T2;
    [SerializeField] GameObject Player;
    [SerializeField] Player_Inventory player_Inventory;
    private int requiredID = 2;
    private bool opened, first;

    void Start()
    {
        opened = false;
    }
    void Update()
    {
        if (opened)
        {
           Change();
           opened = !opened;
        }
    }
    public void Open()
    {
        if(player_Inventory.itemsID.Contains(requiredID))
        {
            StartCoroutine(AnimAbrir());
        }
    }

    public IEnumerator AnimAbrir()
    {
        cadeado.SetActive(false);
        yield return new WaitForSeconds(1f);
        anim1.SetBool("Open", true);
        yield return new WaitForSeconds(1f);
        peca.SetActive(false);
        anim2.SetBool("Open", true);
        yield return new WaitForSeconds(1.4f);
        opened = true;
        first = true;
    }


    void Change()
    {
        if(first == true)
        {
            Player.SetActive(false);
            Player.transform.position = T2.position;
            Physics.SyncTransforms();
            Player.SetActive(true);
        }
        else
        {
            Player.SetActive(false);
            Player.transform.position = T1.position;
            Player.SetActive(true);
            Physics.SyncTransforms();
            first = true;
        }
    }
}
