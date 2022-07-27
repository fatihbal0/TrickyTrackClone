using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos, mouseReleasePos;//mouse positions
    Rigidbody rigidbody;
    private bool isShoot;
    [SerializeField]
    private float forceMultiplier = 2;
    [SerializeField]
    private GameObject Player, ballPrefab, StartGamePanel;
    public bool isGameStart;

    void Start()
    {
        Application.targetFrameRate = 60;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    void Update()
    {
        if(isGameStart)
        {
            if(Input.GetMouseButtonDown(0))
            {
                mousePressDownPos = Input.mousePosition;
            }

            if(Input.GetMouseButton(0))
            {
                Vector3 baslangıc = new Vector3(0f, 100f,100f);
                Vector3 ForceInit = ( Input.mousePosition+baslangıc-mousePressDownPos);
                Vector3 forceV = (new Vector3(ForceInit.x, ForceInit.y, ForceInit.y*4)) * forceMultiplier;

                if(!isShoot)
                DrawTrajectory.Instance.UpdateTrajectory(forceV, rigidbody, transform.position);
            }

            if(Input.GetMouseButtonUp(0))
            {
            DrawTrajectory.Instance.HideLine();
            mouseReleasePos = Input.mousePosition;
            Shoot(mouseReleasePos - mousePressDownPos);
            }

        }
    }

    
    public void StartGame()
    {
        StartGamePanel.SetActive(false);
        rigidbody.isKinematic = true;
        Time.timeScale = 1f;
        //isGameStart = true;
        StartCoroutine(Waitsec());
    }
    

    void Shoot(Vector3 Force)
    {
        if(isShoot)
        return;
        transform.parent = null;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(new Vector3(Force.x, Force.y+100f, (Force.y+100f)*4) * forceMultiplier);
        isShoot = true;
        StartCoroutine(SpawnNewBall());
        Destroy(this.gameObject, 3.0f);
    }

    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(1.0f);
        if(!FinishLine.Instance.isGameOver)
        {
        GameObject ball = Instantiate(ballPrefab, Player.transform.position + new Vector3( 0, 1.8f, 0.1f), Quaternion.identity);
        ball.name = "mavi_top";
        ball.transform.parent = Player.transform;
        }
    }

    IEnumerator Waitsec()
    {
        yield return new WaitForSeconds(0.3f);
        isGameStart = true;
    }




}
