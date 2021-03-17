using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/// <summary>
/// alternative fishing
/// </summary>

public class collectQ : MonoBehaviour
{
    public GameObject pickableObject;
    public List<GameObject> Qobjects;
    public string QuestID;
    public string QuestInfo;
    [HideInInspector] public bool complete;
    public int minA, maxA;
    [HideInInspector] public int amount;
    public GameObject player;

    public QuestUI UI;
    public bool reposition;
    private int reposA;
    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";
    public GameObject transUI;
    string json;
    Vector3 loadedjson;

    string[] contents;
    // cubes need to spawn in saved position (jason file saves)
    // first time use can be spawned random amount after that it saves and uses that amount
    
    void Awake()
    {
        QuestID = "collect quest";
        int r = Random.Range(minA, maxA);
        amount = r;
        Debug.Log(amount);
        for (int i = 0; i < r; i++)
        {
            GameObject spawn = Instantiate(pickableObject, new Vector3(i + 1, 1, i + 1), Quaternion.identity);
            spawn.GetComponent<pickupable>().matchingQuest = QuestID;
            spawn.GetComponent<pickupable>().PCQ = this.gameObject.GetComponent<collectQ>();
            Qobjects.Add(spawn);
        }
        UI.titel.text = QuestID;
        UI.info.text = QuestInfo;
        UI.Qcomplete.text = "incomplete";
        load();

    }
    // Update is called once per frame
    void Update()
    {
        if (amount == 0)
        {
            complete = true;
        }



        UI.progress.text = amount.ToString();
        if (complete == true)
        {
            UI.Qcomplete.text = "complete";
        }

        if (reposition ==true)
        {

            //UI

            transUI.SetActive(true);

            // reposition
   
            if (Input.GetKeyDown(KeyCode.G))
            {
                Reposition();
            }

            //save
            if (Input.GetKeyDown(KeyCode.K))
            {
                save();
            }
            //load
            if (Input.GetKeyDown(KeyCode.L))
            {
                load();
            }
        }
        else
        {
            transUI.SetActive(false);
        }

    }
    void Reposition()
    {
        if (reposA >= amount)
        {
            reposA = 0;
        }
        Qobjects[reposA].transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z);
        reposA++;
    }

    private void save()
    {

        List<SaveObject> saveObject = new List<SaveObject>();
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = Qobjects[i].transform.position;
            SaveObject saveobject = new SaveObject
            {
                pos = position,
            };
            saveObject.Add(saveobject);


        }

        json = JsonHelper.ToJson(saveObject.ToArray());
        File.WriteAllText(Application.dataPath + "/save.txt", json);
        Debug.Log("saved!");
    }
    private void load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        SaveObject[] save = JsonHelper.FromJson<SaveObject>(saveString);

        for (int i = 0; i < amount; i++)
        {

            Qobjects[i].transform.position = save[i].pos;
        }
        

    }
    [System.Serializable]
    private class SaveObject
    {
        public Vector3 pos;
    }
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }

    }
}


