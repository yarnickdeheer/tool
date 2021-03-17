using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Product : MonoBehaviour
{
    [HideInInspector] public TradeQ main;
    public int price;

    private Button b;

    /// <summary>
    /// dit gaat op een product
    /// of in trade quest de producten enh dat ik dit script genereer op het object
    /// 
    /// anders moeten ze dit script op alle objecten slepen en aanpassen 
    /// maaaaaar als ik het genereen moeten ze de prijs kunnen instellen
    /// </summary>
    // Start is called before the first frame update
    void Awake()
    {
        if (this.GetComponent<Button>() != null)
        {
            b = this.GetComponent<Button>();
            b.onClick.AddListener(Bought);
        }
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    public void Bought()
    {
        Debug.Log("pressed");
        if (main.Money > (main.Money + price) && main.shoppinglist.Length < main.bought.Count)
        {

            main.Money = -price;
            main.bought.Add(this.gameObject);
            main.completed();
        }
    }


}
