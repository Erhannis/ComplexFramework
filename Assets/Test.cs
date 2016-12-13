using UnityEngine;
using System.Collections;
using System.Numerics;
using System;

public class Test : MonoBehaviour {
    public ComplexRenderer complexRenderer;

	// Use this for initialization
	void Start () {
        Update();
    }

    // Update is called once per frame
    void Update () {
        //Test000();
        TestQuantumHarmonicOscillator(1);
    }

    private void Test000() {
        float time = Time.realtimeSinceStartup;
        int count = 10;
        Complex[] values = new Complex[count];
        for (int i = 0; i < count; i++) {
            values[i] = Complex.FromPolarCoordinates(1, time + (i * 2 * Mathf.PI / count));
        }

        complexRenderer.SetValues(values);
    }

    private static long Factorial(long n) {
        long result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }

    private void TestQuantumHarmonicOscillator(int n) {
        double t = Time.realtimeSinceStartup;
        int count = 100;
        double scale = 10.0;
        // I wish I knew whether it was actually more efficient to make these constants out here
        //TODO I am suspicious of how
        double h = 1.0;
        double E = 1.0;
        Complex niE_h = -1 * (E / h) * Complex.ImaginaryOne;
        double m = 1;
        double w = 1;
        double psi_a = Math.Sqrt(1.0 / (Math.Pow(2, n) * Factorial(n))) * Math.Pow((m * w) / (Math.PI * h), 0.25);
        double nmw_2h = -1 * m * w / (2 * h);
        double sqrtmw_h = Math.Sqrt(m * w / h);
        Complex[] values = new Complex[count];
        for (int i = 0; i < count; i++) {
            double x = ((i * scale) / count) - (scale / 2);
            //values[i] = Complex.FromPolarCoordinates(1, t + (i * 2 * Mathf.PI / count));
            Complex psi = psi_a * Math.Exp(nmw_2h * x * x) * Hermite(n, sqrtmw_h * x);
            values[i] = psi * Complex.Exp(t * niE_h);
        }

        complexRenderer.SetValues(values);
    }

    private static double Hermite(int n, double x) {
        switch (n) {
            case 0: return 1;
            case 1: return 2*x;
            case 2: return 4*x*x - 2;
            case 3: return 8*Math.Pow(x,3) - 12*x;
            default:
                throw new Exception("Hermite polynomial " + n + " not yet implemented");
        }
    }
}
