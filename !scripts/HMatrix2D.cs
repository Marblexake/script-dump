using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    float[,] entries = new float[3, 3];


    public void setIdentity()
    {
        for(int row=0; row<3; row++)
        {
            for(int col=0; col<3; col++)
            {
                //entries[row, col] = (row == col) ? 1 : 0;
                if (row == col)
                {
                    entries[row, col] = 1;
                }
                else
                {
                    entries[row, col] = 0;
                }
            }
        }
    }

    //default constructor
    public HMatrix2D()
    {
        entries[0, 0] = 1;
        entries[0, 1] = 0;
        entries[0, 2] = 0;
        entries[1, 0] = 0;
        entries[1, 1] = 1;
        entries[1, 2] = 0;
        entries[2, 0] = 0;
        entries[2, 1] = 0;
        entries[2, 2] = 1;

    }

    //constructor
    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12,
                     float m20, float m21, float m22)
    {
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;

    }

    public void setTranslationMat(float transX, float transY)
    {
        setIdentity();
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }
    /*
    public static HMatrix2D operator + (HMatrix2D left, HMatrix2D right)
    {

    }
    */
    public static bool operator == (HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (left.entries[row, col] != right.entries[row, col])
                {
                    return false;
                }

            }

        }

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (left.entries[row, col] == right.entries[row, col])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        HVector2D vResult = new HVector2D();
        vResult.x = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2] * right.h;
        vResult.y = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2] * right.h;

        return vResult;
    }
}
