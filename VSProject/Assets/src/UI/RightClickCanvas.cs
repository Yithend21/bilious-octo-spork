using UnityEngine;
using System.Collections;

public class RightClickCanvas : MonoBehaviour {
    RectTransform m_RectTransform;

	// Use this for initialization
	void Start () {
        m_RectTransform = gameObject.GetComponent<RectTransform>();
        //gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPosition(Vector2 NewPos)
    {
        m_RectTransform.position = new Vector3(NewPos.x, NewPos.y, 0);
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
