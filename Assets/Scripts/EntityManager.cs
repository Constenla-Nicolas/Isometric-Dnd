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
         
         entities[0].GetComponent<EntityBehaviour>().iniciativa=15;
         entities[1].GetComponent<EntityBehaviour>().iniciativa=12;
         entities[2].GetComponent<EntityBehaviour>().iniciativa=8;

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
    void entityMovement(){
    
    }
    public List<GameObject> getPlayerList(){

        return entities;
    }
}
