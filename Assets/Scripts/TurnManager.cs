using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{
    // Start is called before the first frame update
  public  GameObject entidadActual;
    List<GameObject> playerlist;
    Queue<GameObject> turnQ = new Queue<GameObject>();
     void Start()
    {
     
   
    }

    int aux=0;

    void Update()
    {
      if (aux==0)
      {  
        playerlist = GameObject.Find("terreno").GetComponent<EntityManager>().entities;
        Debug.Log("entidades encontradas "+ playerlist.Count);
        fillQ();
        entidadActual= turnQ.Peek();
        entidadActual.GetComponent<TacticMovement>().actual=true;
        Debug.Log("turnmanager start "+entidadActual);
        aux=1;
      }




      if (!entidadActual.GetComponent<EntityBehaviour>().ismoving&&!entidadActual.GetComponent<EntityBehaviour>().actionAvailable&&!entidadActual.GetComponent<EntityBehaviour>().bonusActionAvailable)
    { 
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
      
      entidadActual.GetComponent<TacticMovement>().actual=false;
      entidadActual.GetComponent<TacticMovement>().erasePrevious();
      entidadActual = turnQ.Dequeue();
      
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
    Debug.Log("La actual era "+entidadActual.name);
    entidadActual.GetComponent<EntityBehaviour>().actionAvailable=false;
    entidadActual.GetComponent<EntityBehaviour>().bonusActionAvailable=false;
  }
}
