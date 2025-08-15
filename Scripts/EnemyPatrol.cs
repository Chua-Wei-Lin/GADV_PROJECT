using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 100f;
    public float waypointThreshold = 0.1f;

    private int currentWaypointIndex = 0;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Ensure starting at the first waypoint
        if (waypoints.Length > 0)
            transform.position = waypoints[0].position;
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;

        // Move toward current waypoint
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetWaypoint.position,
            speed * Time.deltaTime
        );

        // Update animator bools
        UpdateDirectionBools(direction);

        // Check if reached the waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < waypointThreshold)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void UpdateDirectionBools(Vector2 dir)
    {
        bool movingUp = dir.y > 0.1f;
        bool movingDown = dir.y < -0.1f;
        bool movingRight = dir.x > 0.1f;
        bool movingLeft = dir.x < -0.1f;

        anim.SetBool("Up", movingUp);
        anim.SetBool("Down", movingDown);
        anim.SetBool("Left", movingLeft);
        anim.SetBool("Right", movingRight);
    }

    // Call this from EnemyDeath.Respawn()
    public void ResetPatrol()
    {
        // Resets waypoint sequence as enemy can start fresh after respawning
        currentWaypointIndex = 0;

        if (waypoints.Length > 0)
            transform.position = waypoints[0].position;
    }
}