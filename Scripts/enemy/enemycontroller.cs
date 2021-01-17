using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour {

    public HealthBar healthbar;

    damage dmg;
    NavMeshAgent agent;
    public float attackingDistance = 4f;
    public float idleDistance = 10f;
    GameObject target;
    public bool spottedTarget;
    //float attackCooldown = 2;
    public Animator anim;
    public float maxDistance;
    public float chasingSpeed = 7f;
    public float dormantSpeed = 3f;

    
    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update() 
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= attackingDistance) 
        {
            
            anim.SetBool ("run", false);
            stopEnemy();
            anim.SetBool ("attack", true );
            anim.SetBool ("d_walk", false);
            healthbar.damageTaken (0.5f);
            spottedTarget = true;
            Debug.Log ("attacking");
            //if (Time.time = lastAttackTime > attackCooldown) {
                //lastAttackTime = Time.time;
                //damage script
            //target.GetComponent<>
            //healthbar script
            //healthbar.setHealth (healthbar.value - 0.01f);

        }
        else if (dist > idleDistance && spottedTarget == false) 
        {
            anim.SetBool ("d_walk", true);
            anim.SetBool ("attack", false );
            anim.SetBool ("run", false);
            dormantWalk();
            agent.speed = dormantSpeed;
            //Debug.Log ("idle");
            //stopEnemy();
        }
            
        
        else 
        {   
            anim.SetBool ("d_walk", false);
            anim.SetBool ("attack", false );
            anim.SetBool ("run", true);
            agent.speed = chasingSpeed;
            GoToTarget();
            //Debug.Log ("chasing");
        }
    }

    private void GoToTarget()
    {
       
            agent.isStopped = false;
            //Debug.Log ("going");
            agent.SetDestination(target.transform.position);
        
    } 
    
    private void stopEnemy()
    {
        //anim.SetBool ("run", false);
        //anim.SetBool ("d_walk", false);
        agent.isStopped = true;
        //Debug.Log ("stopped");
    }

    /*public static Vector3 GetRandomPoint(float maxDistance) {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 origin = new Vector3 (736.0703f,7.41f,183.1f);
        Vector3 randomDirection = origin Random.insideUnitSphere * maxDistance;
        //randomDirection += origin;

        NavMeshHit navHit; // NavMesh Sampling Info Container

        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        NavMesh.SamplePosition(randomDirection, out navHit, maxDistance, -1);

        return navHit.position;
    }*/

    public Vector3 RandomNavmeshLocation(float radius) {
         Vector3 randomDirection = Random.insideUnitSphere * radius;
         randomDirection += transform.position;
         NavMeshHit hit;
         Vector3 finalPosition = Vector3.zero;
         if (NavMesh.SamplePosition(randomDirection, out hit, radius, -1)) {
             finalPosition = hit.position;
         }
         return finalPosition;
     }

    private void dormantWalk(){
       
        agent.SetDestination(RandomNavmeshLocation(10f));
        //Debug.Log("roaming");
        /*NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        //Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length-3);
        
        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t+1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t+2]], Random.value);

        agent.SetDestination (point);*/
    }
}
