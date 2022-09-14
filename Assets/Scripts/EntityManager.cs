using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
<<<<<<< Updated upstream
{   
public List<GameObject> players= new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {   players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
         
         players[0].GetComponent<P>().iniciativa=15;
         players[1].GetComponent<P>().iniciativa=12;
         players[2].GetComponent<P>().iniciativa=8;

        ordenarPorIniciativa();
=======
{
    List<GameObject> entities;
    void Start()
    {
        setUpEntities();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
    void ordenarPorIniciativa(){
        for (int i = 0; i < players.Count; i++)
        {
            for (int j = i; j < players.Count-1; j++)
            {
               if (players[i].GetComponent<P>().iniciativa<players[j].GetComponent<P>().iniciativa)
               {
                GameObject aux = players[i];
                players.RemoveAt(i);
                players.Insert(i,players[j]);
                players.RemoveAt(j);
                players.Insert(j,aux);
               }
            }
        }
        foreach (GameObject item in players)
        { Debug.Log(item.GetComponent<P>());
            
        }
        players[0].GetComponent<TacticMovement>().actual=true;
    }
    void entityMovement(){
    
    }
    public List<GameObject> getPlayerList(){

        return players;
    }
=======


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
>>>>>>> Stashed changes
}
