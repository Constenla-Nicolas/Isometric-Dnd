using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Tiles : MonoBehaviour {

     public static int cantidad =8;
      int Cantidad;
      public Tiles parent;
      public bool seleccionable,target,actual,visitado,caminable=true,targetedbymouse;
      public List<Tiles> adyacentes = new List<Tiles>();
    public int distancia;
     
  static  List<GameObject> tiles = new List<GameObject>();
  static List<GameObject> terreno = new List<GameObject>();
  static List<List<GameObject>> matriz = new List<List<GameObject>>();
    [MenuItem("Tools/Instanciar matriz")]
     static void Start() {
     GameObject b = GameObject.FindGameObjectWithTag("base");
        for (int j = 0; j < cantidad; j++)
        {
            tiles.Clear();
             for (int i = 0; i < cantidad; i++)
             {
            tiles.Add(Instantiate(b,b.transform.position+new Vector3(i,0,j),b.transform.rotation)as GameObject);
            tiles[i].name="Cubo"+(j)+","+(i);
            tiles[i].tag="Tile";
            terreno.Add(tiles[i]);
             }
             matriz.Add(tiles);
            
        }
        // foreach (GameObject t in terreno)
        // {   
        //     t.AddComponent<Tiles>();
        // }
       Destroy(b);
     
    }
   public void findnegihbors(){
        adyacentes.Clear();
        Vector3 halfextents = new Vector3(.5f,.5f,.5f); //+new Vector3(1,0,1)
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
 
    public void Update() {
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