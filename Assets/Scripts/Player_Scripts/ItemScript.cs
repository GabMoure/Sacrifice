using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject chave;
    public GameObject luz;
    public List<GameObject> ItemList;

    void Start()
    {
        ItemList = new List<GameObject>();
        chave = null;
        luz = null;
    }
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //o ray em si
        RaycastHit HitData; // acertou
        if (Physics.Raycast(ray, out HitData)) //SE acertar(ray, o que acertar))
        {
            if (HitData.collider.gameObject.tag == "luz" && Input.GetKeyDown(KeyCode.E))
            {
                GameObject Lantern = HitData.collider.gameObject;
                if (luz == null)
                {
                    luz = Lantern;
                    ItemList.Add(Lantern);
                }
            }
            if (HitData.collider.gameObject.tag == "chave" && Input.GetKeyDown(KeyCode.E))
            {
                GameObject KeyItem = HitData.collider.gameObject;
                if (chave == null)
                {
                    ItemList.Add(KeyItem);
                    chave = KeyItem;
                    Destroy(KeyItem);
                }
            }
        }

    }
}
