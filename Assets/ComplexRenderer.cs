using UnityEngine;
using System.Collections;
using System.Numerics; // Illusion; copied in Complex.cs

public class ComplexRenderer : MonoBehaviour {
    public LineRenderer lineRenderer;
    private int count;
    private Complex[] values;
    private Vector3[] positions;

	// Use this for initialization
	void Start () {
        count = -1;
	}

    private void UpdatePositions() {
        for (int i = 0; i < count; i++) {
            Complex val = values[i];
            positions[i] = new Vector3((float)val.Real, (float)val.Imaginary, (((float)i) / count));
        }
    }

    private void UpdateLine() {
        lineRenderer.SetPositions(positions);
    }

    /**
     * If you change the numbers in values after calling this, the lines will not automatically
     * update, fyi.
     */
    public void SetValues(Complex[] values) {
        this.values = values;
        if (values.Length != count) {
            count = values.Length;
            positions = new Vector3[count];
        }
        lineRenderer.SetVertexCount(count);
        UpdatePositions();
        UpdateLine();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
