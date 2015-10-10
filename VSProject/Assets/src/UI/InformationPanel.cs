using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InformationPanel : MonoBehaviour {

    public Text NameText;

    public void display(AstronomicalObject o)
    {
        if (o != null)
        {
            NameText.text = o.ObjectName;
        }
        else
        {
            NameText.text = "";
        }
    }

    public void Start()
    {
    }

}
