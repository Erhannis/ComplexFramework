using UnityEngine;
using System.Collections;
using System.Numerics;

public class Test : MonoBehaviour {
    public ComplexRenderer complexRenderer;

	// Use this for initialization
	void Start () {
        Update();
    }

    // Update is called once per frame
    void Update () {
        float time = Time.realtimeSinceStartup;
        int count = 10000;
        Complex[] values = new Complex[count];
        for (int i = 0; i < count; i++) {
            values[i] = Complex.FromPolarCoordinates(1, time + (i * 2 * Mathf.PI / count));
        }

        complexRenderer.SetValues(values);
    }
}
