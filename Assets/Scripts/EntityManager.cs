using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    List<GameObject> entities;
    void Start()
    {
        setUpEntities();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void setUpEntities(){
        entities= new List<GameObject>();
        entities.AddRange(GameObject.FindGameObjectsWithTag("Entity"));
        entities[0].GetComponent<EntityBehaviour>().iniciativa=15;
        entities[1].GetComponent<EntityBehaviour>().iniciativa=7;
        entities[2].GetComponent<EntityBehaviour>().iniciativa=12;
        List<GameObject> orderedList =entities ;
        orderedList.Sort(
            delegate(GameObject p1, GameObject p2)
            {
                return p1.GetComponent<EntityBehaviour>().iniciativa.CompareTo(p2.GetComponent<EntityBehaviour>().iniciativa);
            }
        );

       orderedList.Reverse();
       entities=orderedList;
      
      

    }
    public List<GameObject> getEntities(){
        return entities;
    }  
}
