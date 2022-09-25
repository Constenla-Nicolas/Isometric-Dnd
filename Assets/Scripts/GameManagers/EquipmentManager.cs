using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class EquipmentManager : MonoBehaviour {
   
  
public Equipment[] currentEquipment;
    SkinnedMeshRenderer[] currentMeshes;
    public SkinnedMeshRenderer targetMesh;
    public delegate void equipmentChange(Equipment newItem, Equipment oldItem);
    public equipmentChange onEquipmentChange;
    private void Start() {
       int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
       currentEquipment= new Equipment[numSlots];
       currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip(Equipment newItem){
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem=null;
        if (currentEquipment[slotIndex]!=null)
        {
            oldItem = currentEquipment[slotIndex];
            TurnManager.instance.entidadActual.GetComponent<Inventory>().Add(oldItem);
            if (onEquipmentChange!=null)
            {
                onEquipmentChange.Invoke(newItem, oldItem);
            }
        }
        setBlendShapes(newItem,100);
        currentEquipment[slotIndex]=newItem;
      
        SkinnedMeshRenderer auxMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        
        auxMesh.transform.parent = targetMesh.transform;
        auxMesh.bones=targetMesh.bones;
        auxMesh.rootBone=targetMesh.rootBone;
        currentMeshes[slotIndex]= auxMesh;
    }
    public void Unequip(int slotIndex){
        if (currentEquipment[slotIndex]!=null)
        {   Equipment oldItem = currentEquipment[slotIndex];
            TurnManager.instance.entidadActual.GetComponent<Inventory>().Add(oldItem);
            currentEquipment[slotIndex]=null;
            setBlendShapes(oldItem,0);
           if (onEquipmentChange!=null)
            {
                onEquipmentChange.Invoke(null, oldItem);
            }
            if (currentMeshes[slotIndex]!=null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);   
            }
        }
    }
    public void setBlendShapes(Equipment item, int weight){
       foreach (MeshRegion coveredRegion in item.coveredRegions)
       {
        targetMesh.SetBlendShapeWeight((int)coveredRegion,weight);
       }
    }
    public void UnequipAll(){
            for (int i = 0; i < currentEquipment.Length; i++)
            {
                Unequip(i);
            }
        }
}

