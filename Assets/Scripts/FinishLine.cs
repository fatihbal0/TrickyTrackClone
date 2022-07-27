using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    Animator playerAnim, enemyAnim;
    Movement playerMov, enemyMov;
    [SerializeField]
    GameObject Player, Enemy, StartGamePanel;
    Rigidbody PlayerBall, EnemyBall;
    [HideInInspector]
    public bool isGameOver;
    public bool isGameStart;
    public static FinishLine Instance;
    void Awake()
    {
        Instance = this;
        playerAnim = Player.GetComponent<Animator>();
        enemyAnim = Enemy.GetComponent<Animator>();
        playerMov = Player.GetComponent<Movement>();
        enemyMov = Enemy.GetComponent<Movement>();
        Time.timeScale = 0f;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        StartGamePanel.SetActive(false);
        isGameStart = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isGameOver = true;
            playerMov.movementSpeed = 0f;
            enemyMov.movementSpeed = 0f;
            playerAnim.Play("victory");
            enemyAnim.Play("defeated");
            PlayerBall = Player.transform.GetChild(2).GetComponent<Rigidbody>();
            EnemyBall = Enemy.transform.GetChild(2).GetComponent<Rigidbody>();
            PlayerBall.isKinematic = false;
            EnemyBall.isKinematic = false;
            Vector3 velocity = new Vector3(Random.Range(1,3),Random.Range(1,3),Random.Range(1,3));
            PlayerBall.velocity = velocity;
            EnemyBall.velocity = velocity;

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            playerMov.movementSpeed = 0f;
            enemyMov.movementSpeed = 0f;
            playerAnim.Play("defeated");
            enemyAnim.Play("victory");
            PlayerBall = Player.transform.GetChild(2).GetComponent<Rigidbody>();
            EnemyBall = Enemy.transform.GetChild(2).GetComponent<Rigidbody>();
            PlayerBall.isKinematic = false;
            EnemyBall.isKinematic = false;
            Vector3 velocity = new Vector3(Random.Range(1,3),Random.Range(1,3),Random.Range(1,3));
            PlayerBall.velocity = velocity;
            EnemyBall.velocity = velocity;
        }
    }
}
