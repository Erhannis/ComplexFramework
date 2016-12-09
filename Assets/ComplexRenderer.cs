using UnityEngine;
using System.Collections;
using System.Numerics; // Illusion; copied in Complex.cs

public class ComplexRenderer : MonoBehaviour {
    private int count;
    private Complex[] values;
    private Vector3[] positions;

    //TODO Make actual material or something
    private Material lineMat;

    // Use this for initialization
    void Start () {
        count = -1;
        lineMat = new Material("Shader \"Lines/Colored Blended\" {" + "SubShader { Pass { " + "    Blend SrcAlpha OneMinusSrcAlpha " + "    ZWrite Off Cull Off Fog { Mode Off } " + "    BindChannels {" + "      Bind \"vertex\", vertex Bind \"color\", color }" + "} } }");
        //TODO Use shader?
    }

    private void UpdatePositions() {
        for (int i = 0; i < count; i++) {
            Complex val = values[i];
            positions[i] = new Vector3((float)val.Real, (float)val.Imaginary, (((float)i) / count));
        }
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
        UpdatePositions();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void DoRender() {
        GL.PushMatrix();
        GL.Begin(GL.LINES);
        GL.MultMatrix(transform.localToWorldMatrix);

        lineMat.SetPass(0);
        GL.Color(new Color(0f, 0f, 0f, 1f));
        
        for (int i = 0; i < positions.Length; i++) {
            Vector3 pos = positions[i];
            GL.Vertex3(pos.x, pos.y, pos.z);
            if (i < positions.Length - 1) {
                pos = positions[i+1];
                GL.Vertex3(pos.x, pos.y, pos.z);
            }
        }

        GL.End();
        GL.PopMatrix();
    }
}
