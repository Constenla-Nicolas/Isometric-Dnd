using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{   
       public static EntityManager instance;
     private void Awake() {
     if (instance !=null)
     {
      Debug.LogWarning("more than 1 entity manager at the time!");
     } 
     instance=this;
    }
public List<GameObject> entities= new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {   entities.AddRange(GameObject.FindGameObjectsWithTag("Entity"));
         
         foreach (var item in entities)
         {
            item.GetComponent<EntityBehaviour>().iniciativa= UnityEngine.Random.Range(5,25);
            Debug.Log("iniciativas: "+item.GetComponent<EntityBehaviour>().iniciativa);
         }
         

        ordenarPorIniciativa();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ordenarPorIniciativa(){
       List<GameObject> orderedList = entities;
    orderedList.Sort(
    delegate(GameObject p1,GameObject p2)
    {
        return p1.GetComponent<EntityBehaviour>().iniciativa.CompareTo(p2.GetComponent<EntityBehaviour>().iniciativa);
    }
);  
    orderedList.Reverse();
    entities=orderedList;
        foreach (GameObject item in entities)
        { Debug.Log("found entity"+item.GetComponent<EntityBehaviour>());
            
        }
        entities[0].GetComponent<TacticMovement>().actual=true;
    }
    public void grabItem(){
      TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().setFocus(TurnManager.instance.entidadActual.GetComponent<EntityBehaviour>().getFocus().GetComponent<Interactable>());
    }
    public List<GameObject> getPlayerList(){

        return entities;
    }
}
