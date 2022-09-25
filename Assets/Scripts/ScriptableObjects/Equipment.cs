using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Equipment",menuName ="Inventory/Equipment")]
public class Equipment : ScriptableItem
{
    public EquipmentSlot equipSlot;
    public MeshRegion[] coveredRegions; 
    public SkinnedMeshRenderer mesh;
    
    public int armorClass;
    public int dmgDice;
    public int range;
    public override void Use()
    {
        base.Use();
        TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().Equip(this);
        removeFromInventory();
    }
  
}

public enum EquipmentSlot{Head,Chest,Legs,Hand_1,Hand_2,Feet}
public enum MeshRegion{Torso,Legs,Arms,Hand_1,Hand_2}