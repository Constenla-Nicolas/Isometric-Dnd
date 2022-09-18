using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{   
     public static InventoryUI instance;
     private void Awake() {
     if (instance !=null)
     {
      Debug.LogWarning("more than 1 turn manager at the time!");
     } 
     instance=this;
    }
    
    
    public Transform parentReference;
     List<Inventory> inventories = new List<Inventory>();
 
     InventorySlot[] slots;
    void Start()
    {   
        slots=parentReference.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < EntityManager.instance.entities.Count; i++)
        {
            inventories.Add(EntityManager.instance.entities[i].GetComponent<Inventory>());
              inventories[i].itemChangedCallBack+=UpdateUI;
         
        }
      
    }

    // Update is called once per frame
    void Update()
    {    

    }
    void UpdateUI(){
         
        Debug.Log("mira tu inventario papuh");
        for (int i = 0; i < slots.Length; i++)
        {   
            if (i< TurnManager.instance.entidadActual.GetComponent<Inventory>().items.Count)
            {
                slots[i].AddItem(TurnManager.instance.entidadActual.GetComponent<Inventory>().items[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }
    public void changeEntity(){
        
        Debug.Log("para el ui, la entida actual es " + TurnManager.instance.entidadActual);
        UpdateUI();
    }
   
}
