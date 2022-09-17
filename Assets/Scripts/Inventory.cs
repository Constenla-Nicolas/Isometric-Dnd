using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   public int slots=20;
    public delegate void itemChangedEvent();
    public itemChangedEvent itemChangedCallBack;
   public List<ScriptableItem> items = new List<ScriptableItem>();
   
   public bool Add(ScriptableItem item){
    if (!item.isDefaultItem)
    {if (items.Count>=slots)
    {
        Debug.Log("inventario lleno");
        return false;
    }
        items.Add(item);    
        if (itemChangedCallBack!=null)
        {     
            itemChangedCallBack.Invoke();
        }
        
    }
    return true;
   }
   public void Remove(ScriptableItem item){
    items.Remove(item);
      if (itemChangedCallBack!=null)
        {
            itemChangedCallBack.Invoke();
        }
   }
}
