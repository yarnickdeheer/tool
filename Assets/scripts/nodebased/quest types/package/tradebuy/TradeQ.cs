using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeQ : MonoBehaviour
{
    public string QuestID;
    public string QuestInfo;

    [HideInInspector] public bool complete;
    public QuestUI UI;

    [HideInInspector] public int amount;
    public GameObject[] shoppinglist;
    //public GameObject[] alternative;
    public List<GameObject> bought;
    //money?
    public int Money;
    public int goodTrashhold;
    public List<Catalog> catalog;

    private int checks;
    private int checks2;
    public GameObject cashout;

    public bool goodEnd = false;

    string list;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < catalog.Count; i++)
        {
            catalog[i].product.AddComponent<Product>();
            catalog[i].product.GetComponent<Product>().price = catalog[i].price;
            catalog[i].product.GetComponent<Product>().main = this;
        }

        //==========================
        // UI 
        //==========================

        UI.titel.text = QuestID;
      

        for (int i = 0; i< shoppinglist.Length;i++)
        {
            list += shoppinglist[i].name.ToString() + System.Environment.NewLine;
        }
        UI.info.text = list;
        UI.Qcomplete.text = "incomplete";
    }

    // Update is called once per frame
    void Update()
    {
        UI.progress.text = amount.ToString();
        if (complete == true)
        {
            UI.Qcomplete.text = "complete";
        }
    }

    public void completed()
    {
        if (shoppinglist.Length < bought.Count)
        {
            //incomplete
        }
        else if(shoppinglist.Length == bought.Count)
        {
            //complete
            if (Money < goodTrashhold)
            {
                goodEnd = true;
            }
            complete = true;
        }
    }
    
    public void check()
    {
        for (int i = 0; i< catalog.Count; i++)
        {
            

            if (shoppinglist[i] == bought[i])
            {
                //its the same check next product
                Debug.Log(bought[i].name);
                checks++;
            }
            else
            {
                // not complete
            }
            if (checks == shoppinglist.Length)
            {
                // 
                Debug.Log("done");
                break;
            }
            else
            {
                Debug.Log("noppers" + shoppinglist.Length + "  " + checks);
                //not complete
                break;
            }


        }

        for (int i = 0; i < shoppinglist.Length; i++)
        {
            if (bought[checks2] == shoppinglist[i])
            {
                Debug.Log("its on the list");
            }
            else
            {
                Debug.Log("not this one" + " " + shoppinglist[i].name);
            }
                
        }
    }





    





}


[System.Serializable]
public class Catalog
{
    public GameObject product;
    public int price;
}
