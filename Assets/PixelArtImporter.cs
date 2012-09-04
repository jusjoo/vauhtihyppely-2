using UnityEngine;
using System.Collections;

public class PixelArtImporter : MonoBehaviour {
	
	public Vector2 sizeInPixels;
	public Texture2D image;
	
	
	private float cubeSize = 0.2f;
	private float cubeSpacing = 0.05f;
	
	// Use this for initialization
	void Start () {
		
		for (int x=0; x < sizeInPixels.x; x++) {
			
			for (int y=0; y < sizeInPixels.y; y++)  {
				
				Color color = image.GetPixel(x, y);
                Debug.Log(color);
				
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
               
                cube.transform.localScale = new Vector3(cubeSize-cubeSpacing, cubeSize-cubeSpacing, cubeSize-cubeSpacing);
                
                cube.transform.parent = this.transform;
				
				cube.renderer.material.shader = Shader.Find("Transparent/Diffuse");
                cube.renderer.material.color = color;
				// testilisäys versionhallintaan
				// tämä rivi lisätty toiselta koneelta
				// vielä yks testi

				cube.transform.position = new Vector3(this.transform.position.x + x*cubeSize, this.transform.position.y + y*cubeSize, 0);
                
				
			}
			
		}
		
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
