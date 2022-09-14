using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{
<<<<<<< Updated upstream
=======
      Queue<GameObject> TurnQ;
      GameObject currentEntity;
>>>>>>> Stashed changes
    // Start is called before the first frame update
  public  GameObject entidadActual;
    List<GameObject> playerlist;
    Queue<GameObject> turnQ = new Queue<GameObject>();
     void Start()
<<<<<<< Updated upstream
    {
     
   
    }

    int aux=0;

    void Update()
    {
      if (aux==0)
      {  
        playerlist = GameObject.Find("terreno").GetComponent<EntityManager>().players;
        Debug.Log("entidades encontradas "+ playerlist.Count);
        fillQ();
        entidadActual= turnQ.Peek();
        entidadActual.GetComponent<TacticMovement>().actual=true;
        Debug.Log("turnmanager start "+entidadActual);
        aux=1;
      }




      if (!entidadActual.GetComponent<P>().ismoving&&!entidadActual.GetComponent<P>().actionAvailable&&!entidadActual.GetComponent<P>().bonusActionAvailable)
    { 
      if (turnQ.Count==0)
      {
        for (int i = 0; i < playerlist.Count; i++)
        { playerlist[i].GetComponent<P>().actionAvailable=true;
       playerlist[i].GetComponent<P>().bonusActionAvailable=true;
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
    entidadActual.GetComponent<P>().actionAvailable=false;
    entidadActual.GetComponent<P>().bonusActionAvailable=false;
=======
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
>>>>>>> Stashed changes
  }
}
