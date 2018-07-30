using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HVector2D : MonoBehaviour {

    public float x;
    public float y;
    public float h;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1;
    }

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1;

    }

    public static HVector2D operator + (HVector2D left, HVector2D right)
    {
        HVector2D vResult = new HVector2D();
        vResult.x = left.x + right.x;
        vResult.y = left.y + right.y;

        return vResult;
    }

    public static HVector2D operator *(HVector2D left, float scalar)
    {
        HVector2D vResult = new HVector2D();
        vResult.x = left.x * scalar;
        vResult.y = left.y * scalar;
        return vResult;
    }

    public float dotProduct(HVector2D vec)
    {
        return x * vec.x + y * vec.y;
    }

    public HVector2D projection(HVector2D vec)
    {
        float AdotB = this.dotProduct(vec);
        float BdotB = vec.dotProduct(vec);
        return vec * (AdotB / BdotB);

    }

    public void print()
    {
        Debug.Log("HVector2D(" + x + ", " + y + ")");
    }

    /*
    float a = 3.5f;
    float b = 6.7f;
    float answer = a + b;
    

    //Makes new vector object
    HVector2D vA = new HVector2D(3, 4);
    HVector2D vB = new HVector2D(5, 7);

    //adds the two vectors
    HVector2D vSum = vA + vB;

    //does the dotProduct betweem vA and vB
    float dp = vA.dotProduct(vB);
    */

    

    

}

