using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lata_Script : MonoBehaviour
{
    [SerializeField] Locker_Script locker_Script;
    [SerializeField] BoxCollider chave;
    private Item_Script itemscript;
    public bool isOpen;
    void Start()
    {
        itemscript = GetComponent<Item_Script>();
    }

    // Update is called once per frame
    void Update()
    {  
        if(locker_Script.Completed == true)
        {
            itemscript.enabled = true;
        }   
    }

    public void Abre()
    {
        chave.enabled = true;
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
