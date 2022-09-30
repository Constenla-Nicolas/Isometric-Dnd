using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{
      Queue<GameObject> TurnQ;
      GameObject currentEntity;
    // Start is called before the first frame update
  public  GameObject entidadActual;
    List<GameObject> playerlist;
    Queue<GameObject> turnQ = new Queue<GameObject>();
     void Start()
    {   
        
    }

    // Update is called once per frame
    int aux=0;
    void Update()
    {    if(aux==0){
      TurnQ=new Queue<GameObject>();
         foreach (GameObject item in GameObject.Find("terreno").GetComponent<EntityManager>().getEntities())
         {
            TurnQ.Enqueue(item);
            Debug.Log(item.name);
         }
         currentEntity= TurnQ.Peek();
         currentEntity.GetComponent<TacticMovement>().actual=true;
         aux=1;
    }
      
        if (!currentEntity.GetComponent<EntityBehaviour>().actionAvailable&&!currentEntity.GetComponent<EntityBehaviour>().bonusActionAvailable&&!currentEntity.GetComponent<TacticMovement>().moving
      )
    {   
        if (TurnQ.Count==0)
        {
           for (int i = 0; i < GameObject.Find("terreno").GetComponent<EntityManager>().getEntities().Count; i++)
           {
            GameObject.Find("terreno").GetComponent<EntityManager>().getEntities()[i].GetComponent<EntityBehaviour>().actionAvailable=true;
            GameObject.Find("terreno").GetComponent<EntityManager>().getEntities()[i].GetComponent<EntityBehaviour>().bonusActionAvailable=true;
            // GameObject.Find("terreno").GetComponent<EntityManager>().getEntities()[i].GetComponent<TacticMovement>().distancia= GameObject.Find("terreno").GetComponent<EntityManager>().getEntities()[i].GetComponent<TacticMovement>().distanciaMax;
        
           }
           foreach (GameObject item in GameObject.Find("terreno").GetComponent<EntityManager>().getEntities())
           {
            TurnQ.Enqueue(item);
           }
        }
        currentEntity.GetComponent<TacticMovement>().erasePrevious();
        currentEntity.GetComponent<TacticMovement>().actual=false;
        currentEntity= TurnQ.Dequeue();
        currentEntity.GetComponent<TacticMovement>().actual=true;
        currentEntity.GetComponent<TacticMovement>().findSelectableTiles();
    }
        
    }

  public void saltarTurno(){ 
    currentEntity.GetComponent<EntityBehaviour>().actionAvailable=false;
    currentEntity.GetComponent<EntityBehaviour>().bonusActionAvailable=false;
  }
}
