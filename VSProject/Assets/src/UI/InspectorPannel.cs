using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InspectorPannel : MonoBehaviour {

    public GameObject m_Inspector;
    private Image m_InspectorImage;
    
	// Use this for initialization
	void Start () {
        m_InspectorImage = m_Inspector.GetComponent<Image>();
    }
	
    public void ChangeInspectorImage(Sprite NewImage)
    {
        m_InspectorImage.sprite = NewImage;
    }

}
