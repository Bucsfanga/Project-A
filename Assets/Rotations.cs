using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotations : MonoBehaviour {

    public Transform theParent;
    public Transform theChild;


    void Start()
    {
        Quaternion NewRot = theChild.rotation;
        theChild.rotation = Quaternion.identity;
        theParent.rotation = NewRot;
    }
}
