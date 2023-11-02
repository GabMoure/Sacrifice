using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //checar objetos baseado em colliders, identificar qual é um npc
            float radius = 4f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, radius);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out IInteractable interactions))
                {
                    interactions.Interacion(transform);
                }
            }
        }
    }

    public NPC_Interaction GetInteractable()
    {
        float radius = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPC_Interaction npcinteraction))
            {
                return npcinteraction;
            }
        }
        return null;
    }
}
