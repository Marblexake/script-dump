using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HVector2D vA = new HVector2D();
        vA.x = 1;
        vA.y = 2;

        HVector2D vB = new HVector2D(5, 7);
        HVector2D vSum = vA + vB;

        float dp = vA.dotProduct(vB);

        HVector2D mPos = new HVector2D(10, 10);
        HVector2D displacement = new HVector2D(3, 4);

        HMatrix2D translationMatrix = new HMatrix2D();
        translationMatrix.setTranslationMat(displacement.x, displacement.y);
        mPos = translationMatrix * mPos;

	}

    




}
