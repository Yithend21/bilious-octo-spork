using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private AstronomicalObject Selected;

    private InspectorPannel m_InspectorPannel;
    private InformationPanel m_InformationPannel;
    private RightClickCanvas m_RightClickCanvas;

    private bool isSelected;

    // Use this for initialization
    void Start () {
        m_InspectorPannel = GameObject.FindGameObjectWithTag("InspectorPannel").GetComponent<InspectorPannel>();
        m_InformationPannel = GameObject.FindGameObjectWithTag("InformationPannel").GetComponent<InformationPanel>();
        m_RightClickCanvas = GameObject.FindGameObjectWithTag("RightClickCanvas").GetComponent<RightClickCanvas>();
        isSelected = false;
        m_RightClickCanvas.setActive(false);
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
                m_RightClickCanvas.setActive(false);
            }
            else
            {
                Selected = null;
                m_InspectorPannel.ChangeInspectorImage(null);
                m_InformationPannel.display(null);
                m_RightClickCanvas.setActive(false);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (Selected != null) { 
               m_RightClickCanvas.setActive(true);
               m_RightClickCanvas.setPosition(Selected.getPosition());  
            } else
            {
                m_RightClickCanvas.setActive(false);
            }
        }
    } 

    public void OnSelect(AstronomicalObject select)
    {
        isSelected = true;
        Selected = select;
    }


}
