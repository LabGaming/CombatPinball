using UnityEngine;
using System.Collections;

public class WaypointMovement : MonoBehaviour
{

	public Transform[] waypoints;
	public float waypointRadius = 1.5f;
	public float damping = 0.1f;
	public bool loop = false;
	public float speed = 2.0f;
	public bool faceHeading = true;

	private Vector3 currentHeading,targetHeading;
	private int targetwaypoint;
	private Transform xform;
	private bool useRigidbody;
	private Rigidbody rigidmember;


	// Initialization
	protected void Start ()
	{
		// The Transform of our object
		xform = transform;

		// The starting direction of the object
		currentHeading = xform.forward;

		// Checks if there is at least one waypoint
		// If not, the object is disabled
		if(waypoints.Length<=0)
		{
			Debug.Log("No waypoints on "+name);
			enabled = false;
		}
		// Sets the first waypoint as next target
		targetwaypoint = 0;

		// If the object has a RigidBody, we will use it
		if(GetComponent<Rigidbody>()!=null)
		{
			useRigidbody = true;
			rigidmember = GetComponent<Rigidbody>();
		}
		else
		{
			useRigidbody = false;
		}
	}


	// Re-calculates the direction
	protected void FixedUpdate ()
	{
		// Calculates the direction to the next waypoint
		targetHeading = waypoints[targetwaypoint].position - xform.position;

		// This makes a steering interpolation. Interpolates between target direction and current direction so that the steering wheel turns smoothly.
		currentHeading = Vector3.Lerp(currentHeading,targetHeading,damping*Time.deltaTime);
	}

	// Moves the Transform along current heading
	protected void Update()
	{
		// If the object works with a RigidBody, we just change its velocity and let it act accordingly...
		if(useRigidbody)
			rigidmember.velocity = currentHeading * speed;
		// else, we move it manually.
		else
			xform.position +=currentHeading * Time.deltaTime * speed;
		// If faceHeading is enabled, the object will always look forward.
		if(faceHeading)
			xform.LookAt(xform.position+currentHeading);
		// If the object has entered the current waypoint's radius, it changes its course to the next waypoint
		if(Vector3.Distance(xform.position,waypoints[targetwaypoint].position)<=waypointRadius)
		{
			// Target changes to the next waypoint
			targetwaypoint++;
			// If the object has traveled all the waypoints in the list and loop is enabled, the target changes to the first waypoint in the list.
			if(targetwaypoint>=waypoints.Length)
			{
				targetwaypoint = 0;
				if(!loop)
					enabled = false;
			}
		}
	}


	// Gizmos
	// Draws red line from waypoint to waypoint
	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		if(waypoints==null)
			return;
		for(int i=0;i< waypoints.Length;i++)
		{
			Vector3 pos = waypoints[i].position;
			if(i>0)
			{
				Vector3 prev = waypoints[i-1].position;
				Gizmos.DrawLine(prev,pos);
			}
		}
	}

}
