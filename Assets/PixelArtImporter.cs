using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PixelArtImporter : MonoBehaviour {
	
	public Vector2 sizeInPixels;
	public Texture2D sprite;
	public int amountOfFrames;
	public float framesPerSecond;
	
	private float cubeSize = 0.2f;
	private float cubeSpacing = 0.05f;
	
	private List<GameObject> cubes;
	
	// time spent in current animation state
	private float animationStateTime;
	
	// Use this for initialization
	void Start () {
		
		cubes = new List<GameObject>();
		
		for (int x=0; x < sizeInPixels.x; x++) {
			
			for (int y=0; y < sizeInPixels.y; y++)  {
				
				Color color = sprite.GetPixel(x, sprite.height - y);
                Debug.Log(color);
				
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
               
                cube.transform.localScale = new Vector3(cubeSize-cubeSpacing, cubeSize-cubeSpacing, cubeSize-cubeSpacing);
                
                cube.transform.parent = this.transform;
				
				cube.renderer.material.shader = Shader.Find("Transparent/Diffuse");
                cube.renderer.material.color = color;
				// testilisäys versionhallintaan
				// tämä rivi lisätty toiselta koneelta
				// vielä yks testi

				cube.transform.position = new Vector3(this.transform.position.x + x*cubeSize, this.transform.position.y - y*cubeSize, 0);
				
                cubes.Add(cube);
				
			}
			
		}
		
	}


	
	// Update is called once per frame
	void Update () {
	
		
		
		
	}
}
