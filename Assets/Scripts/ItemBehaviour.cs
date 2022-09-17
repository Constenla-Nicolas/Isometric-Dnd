using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : Interactable
{
    // Start is called before the first frame update
    public override void interact()
    {
        base.interact();
        pickUp();
    }

    public void pickUp(){
        Debug.Log("objetoAgarrado");
        Destroy(gameObject);
    }
}
