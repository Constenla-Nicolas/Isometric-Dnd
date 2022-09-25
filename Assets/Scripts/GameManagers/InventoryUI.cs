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
    public Transform attackParentReference;
     List<Inventory> inventories = new List<Inventory>();
     InventorySlot[] slots;
     InventorySlot[] atackSlots;
    void Start()
    {   atackSlots= attackParentReference.GetComponentsInChildren<InventorySlot>();
        Debug.Log(atackSlots.Length);
        slots=parentReference.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < EntityManager.instance.entities.Count; i++)
        {
            inventories.Add(EntityManager.instance.entities[i].GetComponent<Inventory>());
            inventories[i].itemChangedCallBack+=UpdateUI;
            
        
        }
        for (int i = 0; i < atackSlots.Length; i++)
        {
            atackSlots[i].RemoveItem();
        }
        UpdateUI();
      
    }

    // Update is called once per frame
    void Update()
    {    
       
    }
    int aux;
    void UpdateAttackUI(){
        Debug.Log("Ataques Actualizados");
    
       

        for (int i = 0; i < atackSlots.Length; i++)
        {  
            if (i< TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().currentEquipment.Length)
            {

                try
                {
                     atackSlots[aux].AddItem(TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().currentEquipment[i]);
                     aux=+1;
                Debug.Log("mostrar arma");
                }
                catch (System.Exception)
                {
                    
                  
                }
               
            }
            else
            {
                atackSlots[i].RemoveItem();
            }
        }
        
    }
    void UpdateUI(){
        Debug.Log("UI actualizada");
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
        UpdateAttackUI();
    }
    public void changeEntity(){
        
        Debug.Log("para el ui, la entida actual es " + TurnManager.instance.entidadActual);
        UpdateUI();
    }
   
}
