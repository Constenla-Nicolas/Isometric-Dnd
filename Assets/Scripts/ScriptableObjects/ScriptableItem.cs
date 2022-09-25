using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New item")]
public class ScriptableItem : ScriptableObject
{
    new public string name="new item";
    public Sprite icon=null;
    public bool isDefaultItem=false;
    public virtual void Use(){
        Debug.Log("usando "+this.name);
    }
    public void removeFromInventory(){
        TurnManager.instance.entidadActual.GetComponent<Inventory>().Remove(this);
    }
}
