using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : ShowInteractionText
{
    [SerializeField] Transform playerHand;
    [SerializeField] public List<GameObject> inventory;
    [SerializeField] public List<int> itemsID;
    [SerializeField] Camera cam;
    private Ray ray;
    private float raydistance = 5.0f;
    private bool onHand;
    public bool isitem;
    public bool isDoor;
    

    void Start()
    {
        inventory = new List<GameObject>();
        itemsID = new List<int>();
    }

    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, raydistance))
        {
            if (hit.collider.gameObject.tag == "Item")
            {
                isitem = true;
                Item_Script itemscript = hit.collider.gameObject.GetComponent<Item_Script>();
                base.Show(itemscript.texto);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Grab(hit.collider.gameObject);
                }
            }
            else
            {
                isitem = false;
                base.Hide();
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
            StartCoroutine(LittleTime(item));
        }

        if (itemscript.name == "puzzle")
        {
            if (item.tag == "Locker")
            {
                Gate_Puzzle gate_Puzzle = item.GetComponent<Gate_Puzzle>();
                gate_Puzzle.enabled = true;
                gate_Puzzle.Isinteract = true;
            }
        }

        if (itemscript.name == "nada")
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
    IEnumerator LittleTime(GameObject item)
    {
        yield return new WaitForSeconds(.3f);
        item.SetActive(false);
    }
}
