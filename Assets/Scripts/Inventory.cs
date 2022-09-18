using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   public int slots=20;
    public delegate void itemChangedEvent();
    public itemChangedEvent itemChangedCallBack;
    public delegate void entityChangedEvent();
    public entityChangedEvent entityChangedCallBack;
   public List<ScriptableItem> items = new List<ScriptableItem>();
    public delegate void changeEntity();
    public changeEntity changeEntityInventory;
   public bool Add(ScriptableItem item){
    if (!item.isDefaultItem)
    {
        if (items.Count>=slots)
    {
        Debug.Log("inventario lleno");
        return false;
    }
        items.Add(item);    
        if (itemChangedCallBack!=null)
        {     
            itemChangedCallBack.Invoke();
        }
        else{
            Debug.Log("el error esta aca");
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
