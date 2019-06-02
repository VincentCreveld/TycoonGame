using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
	public NavMeshAgent playerAgent;
	public LayerMask rayMask;

	// Change to local WASD movement (eventual controller support?)
	public void Update()
	{
		if(Input.GetMouseButton(0) && Input.touchCount < 2)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, rayMask))
			{
				if(hit.transform.tag == "Terrain")
					MoveAgent(hit.point);
			}
		}
	}

	private void MoveAgent(Vector3 movePos)
	{
		// animation calls here.
		playerAgent.SetDestination(movePos);
	}
}
