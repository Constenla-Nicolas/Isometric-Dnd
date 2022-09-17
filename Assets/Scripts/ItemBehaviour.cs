using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : Interactable
{
    public ScriptableItem item;
    public override void interact()
    {
        base.interact();
        pickUp();
    }

    public void pickUp(){
        Debug.Log("objetoAgarrado "+item.name);
        bool wasPickedUp = TurnManager.instance.entidadActual.GetComponent<Inventory>().Add(item);
        if (wasPickedUp)
        {
         Destroy(gameObject);     
        }
       
    }
}
