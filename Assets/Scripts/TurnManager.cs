using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour{ 
    // Start is called before the first frame update
    Queue<GameObject> turnQ = new Queue<GameObject>();
     void Start()
    {  foreach (GameObject item in GameObject.Find("terreno").GetComponent<EntityManager>().getPlayerList())
    { 
      turnQ.Enqueue(item);
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
