using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
     InventorySlot selec;
    void Start()
    { 
        atackSlots= attackParentReference.GetComponentsInChildren<InventorySlot>();
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
        atackSlots[0].AddItem(TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().UnarmedStrike);
        atackSlots[0].text.text = atackSlots[0].getItem().name;
    }

    // Update is called once per frame
    
    int aux=1;
   public void UpdateAttackUI(){
        
    for (int i = 1; i < atackSlots.Length; i++)
    {
        atackSlots[i].RemoveItem();
        atackSlots[i].text.text="";
    }
       

        for (int i = 0; i < atackSlots.Length; i++)
        {  
            if (i< TurnManager.instance.entidadActual.GetComponent<EquipmentBehaviour>().currentEquipment.Length)
            {
                if (TurnManager.instance.entidadActual.GetComponent<EquipmentBehaviour>().currentEquipment[i]!=null&&TurnManager.instance.entidadActual.GetComponent<EquipmentBehaviour>().currentEquipment[i].dmgDice!=0)
            {
                atackSlots[aux].AddItem(TurnManager.instance.entidadActual.GetComponent<EquipmentBehaviour>().currentEquipment[i]);
                atackSlots[aux].text.text=atackSlots[aux].getItem().name;
            }
            }
             
       
        }
         Debug.Log("Ataques Actualizados");
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
        
    }
    public void guardarArma(InventorySlot selec){
        this.selec=selec;
        }
    public Equipment getArmaGuardada(){
        
        return (Equipment)selec.getItem();
    }
    public void changeEntity(){
        
        Debug.Log("para el ui, la entida actual es " + TurnManager.instance.entidadActual);
        UpdateUI();
        UpdateAttackUI();
    }
   
}
