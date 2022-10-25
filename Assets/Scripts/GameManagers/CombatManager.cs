using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CombatManager : MonoBehaviour
{
   public static CombatManager instance;
   public Image EntityIcon;
   [SerializeField] GameObject SelectedEntity;
     
 
   public TextMeshProUGUI EntityName;
     private void Awake() {
     if (instance !=null)
     {
      Debug.LogWarning("more than 1  manager at the time!");
     }
     instance=this;
    }
    private void Start() {
      
    }
double checkDistance(){
        TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().setFocus(SelectedEntity.GetComponent<Interactable>());
        Vector2 targetVector2 = new Vector2(SelectedEntity.transform.position.x, SelectedEntity.transform.position.z);
        Vector2 entityVector2 = new Vector2(TurnManager.instance.entidadActual.transform.position.x, TurnManager.instance.entidadActual.transform.position.z);
        //convierte la trfanslacion interna del juego en distancia de dnd en pies
       var resultado = Math.Sqrt((Math.Pow(entityVector2.x - targetVector2.x, 2) + Math.Pow(entityVector2.y - targetVector2.y, 2)));
       resultado = Math.Round(resultado);
        resultado = Math.Abs(resultado) *5;
        Debug.Log("El objetivo esta a "+resultado+" pies");
        return resultado;
}
void atacar(){
  
  // if (SelectedEntity!=null)
  // { 
  //   if (checkHands().range>=checkDistance())
  //   {
  //   attackRoll();
  //   //reproducir animacion de ataque
  //   }
  //   else
  //   {
  //   Debug.Log("te quedaste corto");
  //   }
  // }
  
}

void attackRoll(){
    var AttackDice = UnityEngine.Random.Range(1,20);
    Debug.Log("tirada de ataque:" +AttackDice);
      try
    {
      if (AttackDice>CameraScript.instance.currentSelected.GetComponent<EquipmentBehaviour>().currentEquipment[1].armorClass)
    {
      Debug.Log("es un hit");
      TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().focus.takeDmg(dmgRoll());
      TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().actionAvailable=false;
      reiniciarHUD();
    }
    }
    catch (System.Exception)
    {
      if (AttackDice>10)
      {
        Debug.Log("no tiene armor, es un hit");
        TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().focus.takeDmg(dmgRoll());
        TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().actionAvailable=false;
        reiniciarHUD();
      }
      
    }
    // if (TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().getFocus().GetComponent<EntityBehaviour>().getCurrentHealth()>=0){
    // TurnManager.instance.entidadActual.GetComponent<ClassManager>().exp+=  TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().getFocus().GetComponent<EntityBehaviour>().dropExp;
    // }

    TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().removeFocus();
   
}

int dmgRoll(){                  // checkHands().dmgDice
  return UnityEngine.Random.Range(1,0);
}
 

 public void reiniciarHUD(){
  
 }
public  void SeleccionarEnemigo(){
  Debug.Log("no deberia moverme");
    TurnManager.instance.entidadActual.GetComponent<TacticMovement>().Seleccionando=true;
    // Selecteditem=item;
  }
private void Update() {
  if (CameraScript.instance.currentGO!=null)
  {
    EntityIcon.sprite= CameraScript.instance.currentGO.Icon;
    EntityName.text= CameraScript.instance.currentGO.name;
  }
  if (CameraScript.instance.currentSelected!=null)
  {
    SelectedEntity=CameraScript.instance.currentSelected;
    atacar();
    CameraScript.instance.currentSelected=null;
    
  }
  
}

public void noMoreSelec(){
  TurnManager.instance.entidadActual.GetComponent<TacticMovement>().Seleccionando=false;
}

// Equipment checkHands(){
//   if (TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().currentEquipment[3]!=null)
//   {
//     return TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().currentEquipment[3];
    
//   }
//   else if (TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().currentEquipment[4]!=null)
//   {
//       return TurnManager.instance.entidadActual.GetComponent<EquipmentManager>().currentEquipment[4];
//   }
//   else
//   {  
//     return TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().UnarmedStrike;
//   }
// }
}
