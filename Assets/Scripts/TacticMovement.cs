using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TacticMovement : MonoBehaviour
{    public int distanciaMax =6;
     private NavMeshAgent agent;
    public bool moving=false;
    public int distancia;
    Tiles current,prevcurrent,targetedbymouse;
    public GameObject p;
     private Tiles aux;
    Stack<Tiles>path=new Stack<Tiles>();
     protected List<  Tiles> seleccionables ;
    // Start is called before the first frame update
    protected void Start(){
       agent=GetComponent<NavMeshAgent>();
         current= new Tiles();
         seleccionables = new List<Tiles>();
         

    }

    private void Update() {
          if(!moving){
        checkMouse();
     }
     else{
        caminar();
     }
    
          prevcurrent=current;
     
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit,2f))
        {    
      
            if (hit.collider.gameObject.tag.Equals("Tile"))
            {
              
               
                current =hit.transform.gameObject.GetComponent<Tiles>();
                current.actual=true;
                 
            // Debug.DrawRay(transform.position,Vector3.down * 10,Color.green);
               
         
            if (current!=prevcurrent)
            {   erasePrevious();
                prevcurrent.Reset();
                Debug.Log("difiere");
                
               
                prevcurrent.actual=false;
                distancia= distanciaMax-1;
                 findSelectableTiles();
            }
           
           
            }
        }
        
          
    }
   

    void findSelectableTiles(){
        Queue<Tiles> proceso = new Queue<Tiles>();
        proceso.Enqueue(current);
        seleccionables.Add(current);
        computeAdjacencyList(proceso.Peek());
        while (proceso.Count!=0)
        {   aux = proceso.Dequeue();
            aux.seleccionable = true;
            if (aux!=current)
            {  
              seleccionables.Add(aux);  
              
            }
            current.visitado=true;
            if(aux.distancia<this.distancia){
                foreach (Tiles t in aux.adyacentes)
                {
                    if (!t.visitado)
                    { t.seleccionable = true;
                    t.visitado=true;
                    t.distancia= aux.distancia+1;
                    computeAdjacencyList(t);
                    proceso.Enqueue(t);
                    
                    
                    }
                    
                }
            }
            
        }
        Debug.Log(seleccionables.Count);
    }

    void computeAdjacencyList(Tiles t){
        t.findnegihbors();
       
    }
   public void erasePrevious(){
        
        foreach (Tiles a in seleccionables)
        {   if (!a.actual)
        {
            a.distancia=0;
        }
           a.Reset();
            
        }
       
       Debug.Log("antes de borrar: "+seleccionables.Count);
        seleccionables.Clear();
       
    }
    protected void moveToTile(Tiles t){
    // Vector3 pos = t.transform.position;
    // pos.y = this.transform.position.y;
    agent.SetDestination(t.transform.position);

    }
       private void checkMouse(){
        // si se suelta el boton de la izquierda del mouse(boton 0)
        if (Input.GetMouseButtonUp(0))
        {

        //raycast apuntando a la posicion del mouse
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit ;

            if (Physics.Raycast(r, out hit))
            {    
                 if (hit.collider.tag=="Tile")
            {
                  targetedbymouse = hit.collider.GetComponent<Tiles>();
                 
                 if (targetedbymouse.seleccionable)
                 {    
                     moveToTile(targetedbymouse);
                  
                    Debug.Log("toque a "+targetedbymouse.name);

                 }
            }

            }
            else
            {
                 
            }

        }
    }
    protected void caminar(){
        if (path.Count>0){

        }
        else{
            
            moving=false;
        }
    }

}
