using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{   
public List<GameObject> players= new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {   players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
         
         players[0].GetComponent<P>().iniciativa=15;
         players[1].GetComponent<P>().iniciativa=12;
         players[2].GetComponent<P>().iniciativa=8;

        ordenarPorIniciativa();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
