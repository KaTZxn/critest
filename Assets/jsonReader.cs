using System.Collections;
using System.Collections.Generic;
using UnityEngine;



 public class JsonData
    {
        public Map[] test;
    }

    [System.Serializable]
    public class Map
    {
        public string Name;
        public double length;
        public double BPM;
        public double[,] notelist;
    }

    [System.Serializable]
    public class NoteList
    {
        public float timing;
        public int rownum;
        public int notetype;
    }




public class jsonReader : MonoBehaviour
{
       void Start()
    {

        string loadjson = Resources.Load<TextAsset>("json/test1").ToString();

        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadjson, jsonData);

        //NoteList[] notes = JsonUtility.FromJson<NoteList>();
        
        foreach (var item in jsonData.test)
        {
            Debug.Log("Name: " + item.Name);
            Debug.Log("length: " + item.length);
            Debug.Log("BPM: " + item.BPM);
            Debug.Log("list: " + item.notelist[1,1]);
            //foreach (var item in jsonData.test1.list1)
                ////ebug.Log("Timing: " );
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
