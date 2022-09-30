using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Tiles : MonoBehaviour {


       
      public Tiles parent;
      public bool seleccionable,target,actual,visitado,caminable=true,targetedbymouse;
      public List<Tiles> adyacentes = new List<Tiles>();
    public int distancia;


     void Start() {
      checkTile(Vector3.forward);
      checkTile(-Vector3.forward);
      checkTile(Vector3.right);
      checkTile(-Vector3.right);

    }

    void checkTile(Vector3 direction){
          RaycastHit hit;
        if (Physics.Raycast(transform.position,direction,out hit,1f))
        {
            Debug.Log("toque");
            if (hit.transform.gameObject==null)
            {
                Debug.Log("ha, no hay nadie");
            }
            else{Debug.Log(hit.transform.gameObject.name);}
            // if (hit.collider.gameObject.tag.Equals("Tile"))
            // {


            //     current =hit.transform.gameObject.GetComponent<Tiles>();
            //     current.actual=true;




            // if (current!=prevcurrent)
            // {
            //      erasePrevious();
            //     prevcurrent.Reset();
            //     // Debug.Log("difiere");


            //     prevcurrent.actual=false;
            //     distancia= distanciaMax-1;
            //      findSelectableTiles();
            // }


            // }
        }
        else{
            Debug.Log("no toque nada en la direccion " +direction);
        }
    }
   public void findnegihbors(){
        adyacentes.Clear();
        Vector3 halfextents = new Vector3(.5f,.5f,.5f); //+new Vector3(1,0,1)

     try
     {
         Collider[]colliders = Physics.OverlapBox(transform.position,halfextents );
     foreach (Collider item in colliders)
     {
        Tiles t = item.GetComponent<Tiles>();
        if (t.name!=this.name&&(t.transform.position.x/transform.position.x==1||t.transform.position.z/transform.position.z==1))
        {
            adyacentes.Add(t);
        }
     }
     }
     catch (System.NullReferenceException)
     {


     }


    }

    public void Update() {
        Debug.DrawRay(transform.position,Vector3.forward,Color.green);
        Debug.DrawRay(transform.position,-Vector3.forward,Color.green);
        Debug.DrawRay(transform.position,Vector3.right,Color.green);      
        Debug.DrawRay(transform.position,-Vector3.right,Color.green); 
          if (targetedbymouse)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if (actual)
        {

            GetComponent<Renderer>().material.color= Color.green;
        }
        else if (seleccionable)
        {
            GetComponent<Renderer>().material.color= Color.red;
        }


        else{
            GetComponent<Renderer>().material.color=Color.white;
        }

    }
      public void Reset() {
    seleccionable=false;
    actual=false;
    visitado=false;

    // parentGeom=null;
        adyacentes.Clear();
    }
    // public void findnegihbors(){
    // Reset();
    // }

}