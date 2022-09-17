using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
     public Image icon;
     ScriptableItem item;
     public void AddItem(ScriptableItem item){
        this.item=item;
        icon.sprite=item.icon;
        icon.enabled=true;
     }
       public void RemoveItem(){
        this.item=null;
        icon.sprite=null;
        icon.enabled=false;
     }
}
