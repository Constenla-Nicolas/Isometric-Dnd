using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{   
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
        for (int i = 0; i < entities.Count; i++)
        {
            for (int j = i; j < entities.Count-1; j++)
            {
               if (entities[i].GetComponent<EntityBehaviour>().iniciativa<entities[j].GetComponent<EntityBehaviour>().iniciativa)
               {
                GameObject aux = entities[i];
                entities.RemoveAt(i);
                entities.Insert(i,entities[j]);
                entities.RemoveAt(j);
                entities.Insert(j,aux);
               }
            }
        }
        foreach (GameObject item in entities)
        { Debug.Log("foud entity"+item.GetComponent<EntityBehaviour>());
            
        }
        entities[0].GetComponent<TacticMovement>().actual=true;
    }
    void entityMovement(){
    
    }
    public List<GameObject> getPlayerList(){

        return entities;
    }
}
