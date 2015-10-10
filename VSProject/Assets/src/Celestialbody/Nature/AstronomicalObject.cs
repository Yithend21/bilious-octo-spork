using UnityEngine;
using System.Collections;

public class AstronomicalObject : MonoBehaviour
{
    private Rigidbody2D m_Riggebody2D;
    private Vector2 velocity;
    private CircleCollider2D m_Collider;

    public bool isRevolution;
    public AstronomicalObject RevolutionObject;
    public float RevolutionVelocity;
    private float RevolutionDistance;
    bool phyC;

    public string ObjectName;
    public string Type;

    private GameController m_GameController;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<Rigidbody2D>();
        m_Riggebody2D = gameObject.GetComponent<Rigidbody2D>();
        m_Riggebody2D.drag = 0;
        m_Riggebody2D.angularDrag = 0;

        gameObject.AddComponent<CircleCollider2D>();
        m_Collider = gameObject.GetComponent<CircleCollider2D>();
        m_Collider.isTrigger = true;

        m_GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        phyC = false;
            
        physicsRevolutionIntialize();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Revolution();
        DoFixedUpdate();
    }

    void Update()
    {
        DoUpdate();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            DoLeftClick();
        else if (Input.GetMouseButtonDown(1))
            DoRightClick();
            
    }

    void Revolution()
    {
        if (isRevolution)
        {
            Vector2 gravityDirection = -(getPosition() - RevolutionObject.getPosition()).normalized;
            gameObject.transform.position = RevolutionObject.getPosition() + (-gravityDirection) * RevolutionDistance;
            if (phyC)
            {
                m_Riggebody2D.velocity = velocity;
                m_Riggebody2D.AddForce(gravityDirection);
                velocity = m_Riggebody2D.velocity;
            }
            else
            {
                Vector2 moveDirection = new Vector2(gravityDirection.y, -gravityDirection.x);
                velocity = RevolutionObject.getVelocity() + moveDirection * RevolutionVelocity;
                m_Riggebody2D.velocity = velocity;
            }
        }
    }

    //get the position of the object
    public Vector2 getPosition()
    {
        return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    public Vector2 getVelocity()
    {
        return velocity;
    }

    void physicsRevolutionIntialize()
    {
        if (isRevolution)
        {
            Vector2 moveDirection = new Vector2();
            moveDirection = (getPosition() - RevolutionObject.getPosition()).normalized;
            Vector2 move = new Vector2(-moveDirection.y, moveDirection.x);
            m_Riggebody2D.velocity = move * RevolutionVelocity;
            velocity = move * RevolutionVelocity;
            RevolutionDistance = (RevolutionObject.getPosition() - getPosition()).magnitude;
        }
    }

    public virtual void DoLeftClick(){
        m_GameController.OnSelect(this);
    }

    public virtual void DoRightClick() { }


    public virtual void DoFixedUpdate(){}
    public virtual void DoUpdate() { }

}