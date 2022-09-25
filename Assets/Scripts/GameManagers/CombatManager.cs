using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
   public static CombatManager instance;
     private void Awake() {
     if (instance !=null)
     {
      Debug.LogWarning("more than 1  manager at the time!");
     } 
     instance=this;
    }

    public void atacar(){
      Debug.Log("messi");
      SeleccionarEnemigo();
      // TurnManager.instance.entidadActual.GetComponent<EquipmentManager>()
    }
    

    void SeleccionarEnemigo(){
      
    }
}
