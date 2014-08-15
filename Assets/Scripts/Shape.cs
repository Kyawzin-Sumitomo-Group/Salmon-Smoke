using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shape : MonoBehaviour {

//	public Vector3[] newVertices;
//	public Vector2[] newUV;
//	public int[] newTriangles;

	//float size;

//	void Awake(){
//		Mesh m = new Mesh();
//		m.name = "Scripted_Plane_New_Mesh";
//		m.vertices = new Vector3[] {new Vector3(0, 0, 0), new Vector3(100, 0, 0), new Vector3(100, 100, 0),new Vector3(0,100,0)};
//		m.uv = new Vector2[]{new Vector2 (0, 0), new Vector2 (0, 1), new Vector2(1, 1), new Vector2 (1, 0)};
//		m.triangles = new int[]{0, 1, 2, 0, 2, 3};
//		m.RecalculateNormals();
//		GameObject obj = new GameObject("New_Plane_Fom_Script", MeshRenderer, MeshFilter, MeshCollider);
//		obj.GetComponent(MeshFilter).mesh = m;
//		print (size);
//
//	}

	void Awake() {

		//set position
		//GameObject player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.transform.localPosition = Vector3.zero;

		//set mesh/collider
		MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));
		meshFilter.mesh = CreateMeshCollider(2, 2);

		//renderer
		MeshRenderer renderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		renderer.material.shader = Shader.Find ("Sprites/Default");

		//texture
		//Texture2D tex = new Texture2D(1, 1);
		//tex.SetPixel(0, 0, Color.green);
		//tex.Apply();

		//material
		//renderer.material.mainTexture = tex;
		renderer.material.color = Color.green;
	}

	Mesh CreateMeshCollider(float width, float height) {
		Mesh m = new Mesh();
		m.name = "ScriptedMesh";
		m.vertices = new Vector3[] {
			new Vector3(-width*Random.value, -height*Random.value, 0.01f), //lower left
			new Vector3(width*Random.value, -height*Random.value, 0.01f), //lower right
			new Vector3(width*Random.value, height*Random.value, 0.01f), //upper right
			new Vector3(-width*Random.value, height*Random.value, 0.01f) //upper left
		};
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2(1, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2, 0, 2, 3};
		m.RecalculateNormals();

		//collider
		PolygonCollider2D collider = (PolygonCollider2D)gameObject.AddComponent (typeof(PolygonCollider2D));
		collider.points = _ConvertVector3Array(m.vertices);
		collider.sharedMaterial = new PhysicsMaterial2D ();
		collider.sharedMaterial.friction = 0;
		collider.sharedMaterial.bounciness = 0;

		return m;
	}

	Vector2[] _ConvertVector3Array(Vector3[] v3) {

		//Vector2[] v2 = new Vector2[];
		List<Vector2> v2 = new List<Vector2>();

		foreach (Vector3 v in v3) {
			v2.Add(new Vector2(v[0],v[1]));
		}

		return v2.ToArray ();
	}

//	void Start2() {
//		Mesh mesh = new Mesh();
//		GetComponent<MeshFilter>().mesh = mesh;
//		mesh.vertices = newVertices;
//		mesh.uv = newUV;
//		mesh.triangles = newTriangles;
//	}
//
//	void Update2() {
//		Mesh mesh = GetComponent<MeshFilter>().mesh;
//		Vector3[] vertices = mesh.vertices;
//		Vector3[] normals = mesh.normals;
//		int i = 0;
//		while (i < vertices.Length) {
//			vertices[i] += normals[i] * Mathf.Sin(Time.time);
//			i++;
//		}
//		mesh.vertices = vertices;
//	}



	void combineMeshes() {
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		int i = 0;
		while (i < meshFilters.Length) {
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.SetActive(false);
			i++;
		}
		transform.GetComponent<MeshFilter>().mesh = new Mesh();
		transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		transform.gameObject.gameObject.SetActive(true);

		//mesh.RecalculateBounds
		//mesh.RecalculateNormals
	}

}
