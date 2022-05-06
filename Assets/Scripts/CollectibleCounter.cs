using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCounter : MonoBehaviour
{
    public GameObject Player;

    public Image CollectiblesImage1;
    public Image CollectiblesImage2;
    public Image CollectiblesImage3;
    public Image CollectiblesImage4;
    public Image CollectiblesImage5;
    public Image CollectiblesImage6;
    public bool allCollectables = false;



    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().collectedCollectibles == 1)
        {
            TurnOnCollectible1();
        }
        else if (Player.GetComponent<Player>().collectedCollectibles == 2)
        {
            TurnOnCollectible2();
        }
        else if (Player.GetComponent<Player>().collectedCollectibles == 3)
        {
            TurnOnCollectible3();
        }
        else if (Player.GetComponent<Player>().collectedCollectibles == 4)
        {
            TurnOnCollectible4();
        }
        else if (Player.GetComponent<Player>().collectedCollectibles == 5)
        {
            TurnOnCollectible5();
        }
        else if (Player.GetComponent<Player>().collectedCollectibles == 6)
        {
            TurnOnCollectible6();
            allCollectables = true;
        }
    }

    private void TurnOnCollectible1()
    {
        CollectiblesImage1.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
    }
    private void TurnOnCollectible2()
    {
        CollectiblesImage2.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
    }
    private void TurnOnCollectible3()
    {
        CollectiblesImage3.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
    }
    private void TurnOnCollectible4()
    {
        CollectiblesImage4.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
    }
    private void TurnOnCollectible5()
    {
        CollectiblesImage5.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
    }
    private void TurnOnCollectible6()
    {
        CollectiblesImage6.GetComponent<Image>().color += new Color(0, 0, 0, 1f);
    }
}