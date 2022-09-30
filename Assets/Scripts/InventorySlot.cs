using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventorySlot : MonoBehaviour
{    public TextMeshProUGUI text;
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
      public void useItem(){
        if (item!=null)
        { 
            item.Use();
            
        }
    }
      
    public ScriptableItem getItem(){
      return item;
    }
}
