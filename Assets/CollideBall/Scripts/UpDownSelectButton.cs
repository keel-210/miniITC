using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownSelectButton : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Items = new List<GameObject>();
    [SerializeField]
    PlayerController PC;
    [SerializeField]
    int Default;
    [SerializeField]
    PlayerParam PP;
    int NowNum;
    void Start()
    {
        Items.ForEach(go => go.SetActive(false));
        Activate(Default);
    }
    void Activate(int Num)
    {
        Items[NowNum].SetActive(false);
        Items[Num].SetActive(true);
        NowNum = Num;
    }
    public void Up()
    {
        int nextNum = NowNum + 1;
        if (nextNum > Items.Count - 1)
        {
            nextNum = Items.Count - 1;
        }
        Activate(nextNum);
        PC.ValueSet(NowNum, PP);
    }
    public void Down()
    {
        int nextNum = NowNum - 1;
        if (nextNum < 0)
        {
            nextNum = 0;
        }
        Activate(nextNum);
        PC.ValueSet(NowNum, PP);
    }
}
