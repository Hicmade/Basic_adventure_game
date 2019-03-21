using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dataStruct;

namespace dataStruct {
    [System.Serializable] public class keyStruct { public Vector3 keyVector; public int keyNumber; }
    [System.Serializable] public class gateStruct { public Vector3 gateVector; public int gateNumber; public Quaternion gateQuat; }
}

[System.Serializable]
public class SaveData
{ 
    public List<Vector3> enemy = new List<Vector3>();
    //public List<Vector3> key = new List<Vector3>();
    //public List<int> keyNumber = new List<int>();
    
    //public List<Vector3> gate = new List<Vector3>();
    //public List<Quaternion> gateQuaternion = new List<Quaternion>();
    //public List<int> gateNumber = new List<int>();


    public List<keyStruct> key = new List<keyStruct>();
    public List<gateStruct> gate = new List<gateStruct>();

    public Vector3 player;
    public Quaternion playerQuaternion;

}
