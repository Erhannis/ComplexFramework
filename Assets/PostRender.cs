using UnityEngine;
using System.Collections;

public class PostRender : MonoBehaviour {
    public ComplexRenderer[] renderers;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnPostRender() {
        //TODO I don't like that I need to put a script on the camera.
        foreach (ComplexRenderer renderer in renderers) {
            renderer.DoRender();
        }
    }
}
