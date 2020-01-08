using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreen : MonoBehaviour
{
	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = WayGreen.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
		transform.LookAt(2 * transform.position - target.position, Vector3.up);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= WayGreen.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = WayGreen.points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		gameObject.SetActive(false);
	}
}
