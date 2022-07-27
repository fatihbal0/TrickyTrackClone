using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody rigidbody;
    private bool isShoot, isBall;
    float forceMultiplier = 2;
    [SerializeField]
    private GameObject Enemy, ballPrefab, hedef;
    [SerializeField]
    private List<GameObject> Enemyobstacles;
    [SerializeField]
    private List<GameObject> Playerobstacles;
    private Renderer ren;
    private Material[] mat;
    float shootTimer, shootRate = 3f, randomShootFactor = 3f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }

    private void Update()
    {
         if(shootTimer > shootRate)
        {
            ObstacleInRange();
        }
        shootTimer += Time.deltaTime;
    }


    private void ObstacleInRange()
    {
        bool stopIteration = false;
        //enemy obstacles
        foreach (GameObject obstacle in Enemyobstacles)
        {
            float dist = obstacle.transform.position.z - transform.position.z;
            if(dist > 20)
            continue;
            
            ren = obstacle.transform.parent.GetComponent<Renderer>();
            mat = ren.materials;
            if(mat[1].color == Color.red)
            {
                Vector3 velocity = CalculateVelocity(obstacle.transform.position, transform.position, 1.0f);
                Shoot(velocity);                
                //Enemyobstacles.Remove(obstacle);
                stopIteration = true;
            }
            if (stopIteration)
            {
                shootTimer = 0f;
                return;
            }
        }

        //player obstacles
        foreach (GameObject obstacle in Playerobstacles)
        {
            float dist = Vector3.Distance(obstacle.transform.position, transform.position);
            if(dist > 20)
            continue;
            
            ren = obstacle.transform.parent.GetComponent<Renderer>();
            mat = ren.materials;
            if(mat[1].color == Color.green)
            {
                Vector3 obstaclePos = obstacle.transform.position;
                Vector3 randomObstaclePosition = new Vector3(Random.Range(obstaclePos.x - randomShootFactor, obstaclePos.x + randomShootFactor),
                                                             Random.Range(obstaclePos.y - randomShootFactor, obstaclePos.y + randomShootFactor),
                                                             Random.Range(obstaclePos.z - randomShootFactor, obstaclePos.z + randomShootFactor));
                Vector3 velocity = CalculateVelocity(randomObstaclePosition, transform.position, 1.0f);
                Shoot(velocity);
                Playerobstacles.Remove(obstacle);
                stopIteration = true;
            }
            if (stopIteration)
            {
                shootTimer = 0f;
                return;
            }
        }


    }


    void Shoot(Vector3 velocity)
    {
        if(isShoot)
        return;
        rigidbody.isKinematic = false;
        transform.parent = null;
        rigidbody.velocity = velocity;
        //rigidbody.AddForce(new Vector3(Force.x, Force.y+100f, (Force.y+100f)*4) * forceMultiplier);
        isShoot = true;
        StartCoroutine(SpawnNewBall());
        Destroy(this.gameObject, 3.0f);
    }

    IEnumerator SpawnNewBall()
    {
        yield return new WaitForSeconds(1.0f);
        if(!FinishLine.Instance.isGameOver)
        {
        GameObject ball = Instantiate(ballPrefab, Enemy.transform.position + new Vector3( 0, 1.8f, 0.1f), Quaternion.identity);
        ball.name = "turuncu_top";
        ball.transform.parent = Enemy.transform;
        }
    }

    public static Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
   
}
