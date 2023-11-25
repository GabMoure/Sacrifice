using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject textobject;
    
    enum doorKey{
        Trancada,
        Destrancada,
    }
    doorKey Chave;
    //booleanas animação
   public bool doorState = false;
   public bool fresta = false;
   //range
   public bool inRange = false;
    //componentes
    public Animator animator;
    /*
    && itemScript.ItemList.Contains(itemScript.chave)
    [SerializeField] ItemScript itemScript;*/

    void Start()
    {
        animator = GetComponent<Animator>();
        Chave = doorKey.Trancada;
        textobject.SetActive(false);

    }
    void Update()
    {
        if (inRange == true)
        {
            switch(Chave)
            {
                case doorKey.Trancada:
                {
                    if (Input.GetKeyDown(KeyCode.E) )
                    {
                        Debug.Log("Destrancou");
                        //itemScript.ItemList.Remove(itemScript.chave);
                       // itemScript.chave = null;   
                        Chave = doorKey.Destrancada;
                    }
                    break;
                }
                case doorKey.Destrancada:
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        doorState = !doorState;
                        animator.SetBool("DoorState", doorState);
                        if (animator.GetBool("DoorState"))
                        {
                            fresta = false;
                        }                        
                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        fresta = !fresta;
                        animator.SetBool("fresta", fresta);
                    }   
                    break;
                }
            }
        }
    }

    void OnTriggerEnter(Collider colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            inRange = true;
            textobject.SetActive(true);
        }

    }
    void OnTriggerExit(Collider colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            inRange = false;
            textobject.SetActive(false);
        }
    }
}
