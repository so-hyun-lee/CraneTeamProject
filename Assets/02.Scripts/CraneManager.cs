using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneManager : MonoBehaviour
{
    enum CraneState
    {
        Idle,
        XMove, //CraneRoot
        ZMove, //HoistRoot
        Down,
        SecondDown,
        Up,
        Return,
        OpenHoist,
        CloseHoist,

    }
    CraneState craneState;
    float moveSpeed = 2.5f; //�̵� �ӵ�
    float downSpeed = 2.5f; //�ϰ� �ӵ�
    float seconddownSpeed = 3.2f;
    float downTime = 2.5f; //�ϰ� �ð�
    float grabSpeed = 0.15f; //��� �ӵ�
    float grabTime = 0.6f; //��� �ð�
    Vector3 originPos;
    //private bool coilAttached = false;

    public GameObject coil;
    public GameObject liftRoot;
    
    // Start is called before the first frame update
    void Start()
    {
        craneState = CraneState.Idle;
        originPos = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            craneState = CraneState.ZMove;
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            craneState = CraneState.XMove;
        }

        switch(craneState)
        {
            case CraneState.Idle:
                Idle();
                break;
            case CraneState.XMove:
                XMove();
                break;
            case CraneState.ZMove:
                ZMove();
                break;
            case CraneState.Down:
                Down();
                break;         
            case CraneState.Up:
                Up();
                break;
            case CraneState.SecondDown:
                SecondDown();
                break;
            case CraneState.Return:
                Return();
                break;
            case CraneState.OpenHoist:
                break;
            case CraneState.CloseHoist:
                break;
                 
        }
    }

    void Idle()
    {
        craneState = CraneState.XMove;
    }

    void XMove()
    {
        GameObject craneRoot = GameObject.Find("CraneRoot");
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0);
        dir = dir.normalized;
        craneRoot.transform.position += dir * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            craneState = CraneState.Down;
            StartCoroutine(CraneDownStop());
        }
        if (Input.GetMouseButtonDown(0))
        {
            craneState = CraneState.SecondDown;
            StartCoroutine(CraneDownStop());
        }
    }

    void ZMove()
    {
        GameObject hoistRoot = GameObject.Find("HoistRoot");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(0, 0, v);
        dir = dir.normalized;
        hoistRoot.transform.position += dir * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            craneState = CraneState.Down;
            StartCoroutine(CraneDownStop());
        }
        if (Input.GetMouseButtonDown(0))
        {
            craneState = CraneState.SecondDown;
            StartCoroutine(CraneDownStop());
        }
    }

    void Down()
    {
        GameObject liftRoot = GameObject.Find("LiftRoot");
        Vector3 dir = new Vector3(0, -6f, 0); //����(�ϰ�)
        dir = dir.normalized;
        liftRoot.transform.position += dir * downSpeed * Time.deltaTime; //������Ʈ �ϰ� 
    }

    void SecondDown()
    {
        GameObject liftRoot = GameObject.Find("LiftRoot");
        Vector3 dir = new Vector3(0, -6f, 0); //����(�ϰ�)
        dir = dir.normalized;
        liftRoot.transform.position += dir * 3.2f * Time.deltaTime; //������Ʈ �ϰ� 
    }



    void Up()
    {
        GameObject liftRoot = GameObject.Find("LiftRoot");
        Vector3 dir = new Vector3(0, 6f, 0); //����(���)
        dir = dir.normalized;
        liftRoot.transform.position += dir * downSpeed * Time.deltaTime; //������Ʈ ��� 
    }

    void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime; //����ġ�� ����
        }
        else
        {
            transform.position = originPos;
            craneState = CraneState.OpenHoist;
            liftRoot.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(CraneLay());
        }
    }
    

    IEnumerator CraneDownStop()
    {
        yield return new WaitForSeconds(downTime); //������Ʈ 1�� �ϰ� �� �ϰ� ����
        craneState = CraneState.CloseHoist;
        StopAllCoroutines();
        StartCoroutine(CraneGrab());
    }

    IEnumerator CraneUpStop()
    {
        yield return new WaitForSeconds(downTime); //������Ʈ 1�� �ϰ� �� �ϰ� ����
        craneState = CraneState.Return;
    }

    IEnumerator CraneGrab()
    {
        yield return new WaitForSeconds(grabTime); //n�ʰ� ���Ǹ� �� ��� ����
        craneState = CraneState.Up;
        StopAllCoroutines();
        StartCoroutine(CraneUpStop());
    }
    IEnumerator CraneLay()
    {
        yield return new WaitForSeconds(grabTime); //n�ʰ� ����
        craneState = CraneState.Idle;
        StopAllCoroutines();
    }


}
