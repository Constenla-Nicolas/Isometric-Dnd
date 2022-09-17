using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{
    // Start is called before the first frame update
    public static TurnManager instance;
     private void Awake() {
     if (instance !=null)
     {
      Debug.LogWarning("more than 1 turn manager at the time!");
     } 
     instance=this;
    }
  public  GameObject entidadActual;
    List<GameObject> playerlist;
    Queue<GameObject> turnQ = new Queue<GameObject>();
     void Start()
    {  playerlist =EntityManager.instance.entities;
        Debug.Log("entidades encontradas "+ playerlist.Count);
        fillQ();
        entidadActual= turnQ.Dequeue();
        entidadActual.GetComponent<TacticMovement>().actual=true;
        Debug.Log("turnmanager start "+entidadActual);
        aux=1;
     
   
    }

    int aux=0;

    void Update()
    {
   




      if (!entidadActual.GetComponent<EntityBehaviour>().ismoving&&!entidadActual.GetComponent<EntityBehaviour>().actionAvailable&&!entidadActual.GetComponent<EntityBehaviour>().bonusActionAvailable)
    { Debug.Log("la actual es "+entidadActual.name);
      if (turnQ.Count==0)
      {
        for (int i = 0; i < playerlist.Count; i++)
        { playerlist[i].GetComponent<EntityBehaviour>().actionAvailable=true;
       playerlist[i].GetComponent<EntityBehaviour>().bonusActionAvailable=true;
        // playerlist[i].GetComponent<TacticMovement>().setDistancia(GameObject.Find("terreno").GetComponent<EntityManager>().players[i].GetComponent<TacticMovement>().getDistanciaMax());
        }
        foreach (GameObject item in playerlist)
        {
          turnQ.Enqueue(item);
        }
      }
      Debug.Log("con actionavailable y bonus action en "+entidadActual.GetComponent<EntityBehaviour>().actionAvailable +", "+ entidadActual.GetComponent<EntityBehaviour>().bonusActionAvailable);
      entidadActual.GetComponent<TacticMovement>().actual=false;
      entidadActual.GetComponent<TacticMovement>().erasePrevious();
      entidadActual = turnQ.Dequeue();
      Debug.Log("y ahora la actual es"+entidadActual.name);
      Debug.Log("con actionavailable y bonus action en "+entidadActual.GetComponent<EntityBehaviour>().actionAvailable +", "+ entidadActual.GetComponent<EntityBehaviour>().bonusActionAvailable);

      entidadActual.GetComponent<TacticMovement>().actual=true;
       entidadActual.GetComponent<TacticMovement>().erasePrevious();
      entidadActual.GetComponent<TacticMovement>().findSelectableTiles();
    }

    }
    void fillQ(){
          foreach (GameObject item in playerlist)
    {
      turnQ.Enqueue(item);
    }
    }

  public void mostrarActual(){
 
    entidadActual.GetComponent<EntityBehaviour>().actionAvailable=false;
    entidadActual.GetComponent<EntityBehaviour>().bonusActionAvailable=false;
  }
}
