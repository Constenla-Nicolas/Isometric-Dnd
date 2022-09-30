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
<<<<<<< Updated upstream
     
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
            tiles[i].isStatic= true;
            terreno.Add(tiles[i]);
             }
             matriz.Add(tiles);
            
=======

    int cont;
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
            
            if (hit.transform.gameObject!=null)
            {   Debug.Log("toque a " + hit.transform.name);
                cont++;

                 if (cont==4)
                {
                    changeMesh();
                }
            }
            
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
>>>>>>> Stashed changes
        }
        // foreach (GameObject t in terreno)
        // {   
        //     t.AddComponent<Tiles>();
        // }
       Destroy(b);
     
    }
    private Mesh BuildQuad (float width, float height)
	{
		Mesh mesh = new Mesh ();
		
		// Setup vertices
		Vector3[] newVertices = new Vector3[4];
		float halfHeight = height * 0.5f;
		float halfWidth = width * 0.5f;
		newVertices [0] = new Vector3 (-halfWidth, -halfHeight, 0);
		newVertices [1] = new Vector3 (-halfWidth, halfHeight, 0);
		newVertices [2] = new Vector3 (halfWidth, -halfHeight, 0);
		newVertices [3] = new Vector3 (halfWidth, halfHeight, 0);
		
		// Setup UVs
		Vector2[] newUVs = new Vector2[newVertices.Length];
		newUVs [0] = new Vector2 (0, 0);
		newUVs [1] = new Vector2 (0, 1);
		newUVs [2] = new Vector2 (1, 0);
		newUVs [3] = new Vector2 (1, 1);
		
		// Setup triangles
		int[] newTriangles = new int[] { 0, 1, 2, 3, 2, 1 };
		
		// Setup normals
		Vector3[] newNormals = new Vector3[newVertices.Length];
		for (int i = 0; i < newNormals.Length; i++) {
			newNormals [i] = Vector3.forward;
		}
		
		// Create quad
		mesh.vertices = newVertices;
		mesh.uv = newUVs;
		mesh.triangles = newTriangles;
		mesh.normals = newNormals;
       
		return mesh;
	}

    void changeMesh(){

        Destroy(transform.GetComponent<MeshRenderer>());
        transform.Find("QuadMesh").GetComponent<MeshRenderer>().enabled=true;
        // transform.Rotate(90,0,0);
                
    }
   public void findnegihbors(){
   
        adyacentes.Clear();
        Vector3 halfextents = new Vector3(.5f,.2f,.5f);  
     Collider[]colliders = Physics.OverlapBox(transform.position,halfextents);
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
<<<<<<< Updated upstream
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
        
=======
        Debug.DrawRay(transform.position,Vector3.forward,Color.green);
        Debug.DrawRay(transform.position,-Vector3.forward,Color.green);
        Debug.DrawRay(transform.position,Vector3.right,Color.green);      
        Debug.DrawRay(transform.position,-Vector3.right,Color.green); 
        //   if (targetedbymouse)
        // {
        //     GetComponent<Renderer>().material.color = Color.magenta;
        // }
        // else if (actual)
        // {

        //     GetComponent<Renderer>().material.color= Color.green;
        // }
        // else if (seleccionable)
        // {
        //     GetComponent<Renderer>().material.color= Color.red;
        // }


        // else{
        //     GetComponent<Renderer>().material.color=Color.white;
        // }

>>>>>>> Stashed changes
    }
      public void Reset() {
    seleccionable=false;
    actual=false;
    visitado=false;
    
    // parentGeom=null;
        adyacentes.Clear();
    }
   
   
}