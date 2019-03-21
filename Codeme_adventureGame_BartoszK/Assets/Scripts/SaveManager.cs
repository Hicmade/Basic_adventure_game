using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using dataStruct;

public class SaveManager : MonoBehaviour
{
    private string filename = "savegame.json";
    public GameObject newEnemy;
    public GameObject newKey;
    public GameObject newGate;
    public GameObject newPlayer;
    public GameData gameData;
    public GameController gameController;

    private SaveData collectSavedata() {
        SaveData sav = new SaveData(); 
        GameObject enemyParent = GameObject.Find("Enemies");
        GameObject keyParent = GameObject.Find("Keys");
        GameObject gateParent = GameObject.Find("Gates");
        GameObject player = GameObject.Find("Mummy_Player");

        Debug.Log("Step1");
        foreach (Transform item in enemyParent.transform) {
            sav.enemy.Add(item.position);
        }

        foreach (Transform item in keyParent.transform) {
            //sav.key.Add(item.position);
            //sav.keyNumber.Add(item.GetComponent<KeyData>().keyNumber);
            keyStruct iKey = new keyStruct();
            iKey.keyVector = item.position;
            iKey.keyNumber = item.GetComponent<KeyData>().keyNumber;
            sav.key.Add(iKey);
        }

        foreach (Transform item in gateParent.transform) {
            //sav.gate.Add(item.position);
            //sav.gateNumber.Add(item.GetComponent<KeyData>().keyNumber);
            gateStruct iGate = new gateStruct();
            iGate.gateVector = item.position;
            iGate.gateNumber = item.GetComponent<KeyData>().keyNumber;
            iGate.gateQuat = item.rotation;
            sav.gate.Add(iGate);
        }

        sav.player = player.transform.position;
        sav.playerQuaternion = player.transform.rotation;
        Debug.Log("Save done! ");
        return sav;
    }

    public void SaveThisGame() {
        SaveData data = collectSavedata();

        string dataAsJson = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + filename;
        File.WriteAllText(filePath, dataAsJson);
    }

    public void CleanBeforeLoad() {
        SaveData sav = new SaveData();
        GameObject enemyParent = GameObject.Find("Enemies");
        GameObject keyParent = GameObject.Find("Keys");
        GameObject gateParent = GameObject.Find("Gates");
        GameObject player = GameObject.Find("Mummy_player");

        foreach (Transform item in enemyParent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in keyParent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in gateParent.transform)
        {
            Destroy(item.gameObject);
        }

        gameData.keyNumber[0] = true;
        gameData.keyNumber[1] = true;
        gameData.keyNumber[2] = true;
        gameData.keyNumber[3] = true;
        
        Debug.Log("Clean done! ");
    }

    public void LoadThisGame() {
        CleanBeforeLoad();

        string filePath = Application.persistentDataPath + filename;

        SaveData data = new SaveData();

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<SaveData>(dataAsJson);
            Debug.Log("File exists");
        }
        else
        {
            data = new SaveData();
            Debug.Log("no file");
        }

        GameObject enemyParent = GameObject.Find("Enemies");
        GameObject keyParent = GameObject.Find("Keys");
        GameObject gateParent = GameObject.Find("Gates");
        GameObject player = GameObject.Find("Mummy_Player");
        //int keyCount = 0;
        //int gateCount = 0;

        gameController.ClosePanel();
        
        foreach (Vector3 item in data.enemy)
        {
            Instantiate(newEnemy, item, Quaternion.identity, enemyParent.transform);
        }
        
        
        foreach (keyStruct item in data.key)
        {
            //GameObject newOne = Instantiate(newKey, item, Quaternion.identity, keyParent.transform);
            //newOne.GetComponent<KeyData>().keyNumber = data.keyNumber[keyCount];
            //if (keyCount < data.keyNumber.Count-1)
            //{
            //    keyCount++;

            //}

            GameObject newOne = Instantiate(newKey, item.keyVector, Quaternion.identity, keyParent.transform);
            newOne.GetComponent<KeyData>().keyNumber = item.keyNumber;
        }
        
        
        foreach (gateStruct item in data.gate)
        {
            //GameObject newOne = Instantiate(newGate, item, data.gateQuaternion[gateCount], gateParent.transform);
            //newOne.GetComponent<KeyData>().keyNumber = data.gateNumber[gateCount];
            //if (gateCount < data.gateNumber.Count - 1)
            //{
            //    gateCount++;
            //}
            GameObject newOne = Instantiate(newGate, item.gateVector, item.gateQuat, gateParent.transform);
            newOne.GetComponent<KeyData>().keyNumber = item.gateNumber;
        }
        
        
        foreach (keyStruct item in data.key) {
            gameData.keyNumber[item.keyNumber-1] = false;
        }

        player.transform.position = data.player;
        player.transform.rotation = data.playerQuaternion;
        
        
    }


}
