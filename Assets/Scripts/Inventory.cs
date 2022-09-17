using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   public int slots=20;
 
   public List<ScriptableItem> items = new List<ScriptableItem>();
   
   public bool Add(ScriptableItem item){
    if (!item.isDefaultItem)
    {if (items.Count>=slots)
    {
        Debug.Log("inventario lleno");
        return false;
    }
        items.Add(item);    
    }
    return true;
   }
   public void Remove(ScriptableItem item){
    items.Remove(item);
   }
}
