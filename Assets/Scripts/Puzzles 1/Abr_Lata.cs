using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Abr_Lata : MonoBehaviour
{
    public bool completed;
    public int requiredID;
    [SerializeField] Player_Inventory player_Inventory;  
    [SerializeField] GameObject container;  
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Lata_Script lata_script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        if (player_Inventory.itemsID.Contains(requiredID))
        {
            if (completed == false)
            {
                lata_script.Abre();
                completed = true;
            }
        }
    }

    public IEnumerator msg()
    {
        container.SetActive(true);
        text.text = "Abriu a lata.";
        yield return new WaitForSeconds(2f);
        container.SetActive(false);
        text.text = "";
    }
}
