using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemReader : MonoBehaviour {
    ArrayList items;
    // Use this for initialization
    public ArrayList Read () {
        StreamReader inp_stm = new StreamReader("items.csv");
        string[] tmp;

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            tmp = inp_ln.Split(',');
            items.Add(tmp);
        }

        inp_stm.Close();

        return items;
    }

}
