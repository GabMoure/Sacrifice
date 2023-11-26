using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    [SerializeField] Transform playerHand;
    [SerializeField] List<GameObject> inventory;
    [SerializeField] public List<int> itemsID;
    [SerializeField] GameObject Ui;
    [SerializeField] Camera cam;
    private Ray ray;
    private float raydistance = 5.0f;
    private bool onHand;

    void Start()
    {
        inventory = new List<GameObject>();
        itemsID = new List<int>();
    }

    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if(Physics.Raycast(ray, out hit, raydistance))
        {
            if (hit.collider.gameObject.tag == "Item")
            {
                Ui.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Grab(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && onHand == true)
        {
            var dropitem = playerHand.GetChild(0);
            var dropitemscript = dropitem.GetComponent<Item_Script>();
            Collider dropitemcollider = dropitem.GetComponent<Collider>();
            Rigidbody dropitembody = dropitem.GetComponent<Rigidbody>();
            inventory.Remove(dropitem.gameObject);
            itemsID.Remove(dropitemscript.id);
            Drop(dropitemcollider, dropitembody);
        }
    }
    void Grab(GameObject item)
    {
        onHand = true;
        inventory.Add(item);
        Item_Script itemscript = item.GetComponent<Item_Script>();
        itemsID.Add(itemscript.id);
        if (itemscript.name == "lantern")
        {
            Transform itempos = item.transform;
            Collider itemcollider = item.GetComponent<Collider>();
            Rigidbody itembody = item.GetComponent<Rigidbody>();
            itempos.parent = playerHand;
            itemcollider.enabled = false;
            itembody.useGravity = false;
            //setting position
            itempos.position = playerHand.position;
            itempos.rotation = cam.transform.rotation;
            //
            itembody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }

        if (itemscript.name == "key")
        {
            item.SetActive(false);
        }
    }
    void Drop(Collider icollider, Rigidbody body)
    {
        icollider.enabled = true;
        body.useGravity = true;
        body.constraints = RigidbodyConstraints.None;
        playerHand.DetachChildren();
        onHand = false;
    }
}
