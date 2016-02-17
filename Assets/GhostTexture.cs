using UnityEngine;
using System.Collections;

public class GhostTexture : MonoBehaviour {

	private Texture[] baseTextures;
	private Texture skullTexture;
	private Renderer renderer;
	private int hideTimer;
	// Use this for initialization
	void Start () {
		hideTimer = 100;
		renderer = gameObject.GetComponent<Renderer>();
		baseTextures = new Texture[renderer.materials.Length];//gameObject.GetComponent<Renderer>().materials;
		skullTexture = Resources.Load("skulls") as Texture;
		for(int i = 0; i < baseTextures.Length; i++) {
			baseTextures[i] = renderer.materials[i].mainTexture;
			renderer.materials[i].mainTexture = skullTexture;
		}
	}
	
	// Update is called once per frame
	void Update () {
		hideTimer--;
		if(hideTimer == 0) {
			for(int i = 0; i < baseTextures.Length; i++) {
				renderer.materials[i].mainTexture = skullTexture;
			}
		}
		else if(hideTimer < 0) {
			for(int i = 0; i < baseTextures.Length; i++) {
				renderer.materials[i].mainTextureOffset = new Vector2(Time.time * 0.30f, 0f);
			}
		}
		else {
			for(int i = 0; i < renderer.materials.Length; i++) {
				renderer.materials[i].mainTexture = baseTextures[i];
			}
		}

	}

	public void hideSkulls() {
		hideTimer = 100;
	}
}
