using UnityEngine;
using System.Collections;

public class GhostTexture : MonoBehaviour {

	private Material[] baseTextures;
	private Texture skullTexture;
	private Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<Renderer>();
		baseTextures = gameObject.GetComponent<Renderer>().materials;
		skullTexture = Resources.Load("skulls") as Texture;
		for(int i = 0; i < baseTextures.Length; i++) {
			renderer.materials[i].mainTexture = skullTexture;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < baseTextures.Length; i++) {
			renderer.materials[i].mainTextureOffset = new Vector2(Time.time * 0.90f, 0f);
		}
	}
}
