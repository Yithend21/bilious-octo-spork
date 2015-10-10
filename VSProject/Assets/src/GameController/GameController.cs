using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private AstronomicalObject Selected;
    private InspectorPannel m_InspectorPannel;
    private InformationPanel m_InformationPannel;

    private bool isSelected;

    // Use this for initialization
    void Start () {
        m_InspectorPannel = GameObject.FindGameObjectWithTag("InspectorPannel").GetComponent<InspectorPannel>();
        m_InformationPannel = GameObject.FindGameObjectWithTag("InformationPannel").GetComponent<InformationPanel>();
        isSelected = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            if (isSelected)
            {
                isSelected = false;
                m_InspectorPannel.ChangeInspectorImage(Selected.GetComponent<SpriteRenderer>().sprite);
                m_InformationPannel.display(Selected);
            }
            else
            {
                Selected = null;
                m_InspectorPannel.ChangeInspectorImage(null);
                m_InformationPannel.display(null);
            }
        }
    } 

    public void OnSelect(AstronomicalObject select)
    {
        isSelected = true;
        Selected = select;
    }


}
