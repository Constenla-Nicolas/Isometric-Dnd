using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Tiles : MonoBehaviour {


       
      public Tiles parent;
      public bool seleccionable,target,actual,visitado,caminable=true,targetedbymouse;
      public List<Tiles> adyacentes = new List<Tiles>();
    public int distancia;

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
            {   
                
                cont++;
                if (cont==4)
                {
                 changeMesh();   
                }
            }
        }
        else{
            // Debug.Log("no toque nada en la direccion " +direction);
        }
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

        if (GetComponent<Renderer>()!=null)
        {
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
         else{ 
            if (targetedbymouse)
        {
           transform.Find("QuadMesh").GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if (actual)
        {

         transform.Find("QuadMesh").GetComponent<Renderer>().material.color= Color.green;
        }
        else if (seleccionable)
        {
           transform.Find("QuadMesh").GetComponent<Renderer>().material.color= Color.red;
        }


        else{
           transform.Find("QuadMesh").GetComponent<Renderer>().material.color=Color.white;
        }}

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