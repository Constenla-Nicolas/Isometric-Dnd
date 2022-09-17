using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{   public Transform parentReference;
     Inventory inventory;
     InventorySlot[] slots;
    void Start()
    {   slots=parentReference.GetComponentsInChildren<InventorySlot>();
        inventory= TurnManager.instance.entidadActual.GetComponent<Inventory>();
        inventory.itemChangedCallBack+=UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI(){
        Debug.Log("mira tu inventario papuh");
        for (int i = 0; i < slots.Length; i++)
        {   
            if (i< inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }
   
}
