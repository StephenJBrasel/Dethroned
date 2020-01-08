using UnityEngine;

[System.Serializable]
public class Wave {

	public GameObject enemy;
	public int count;
	public float rate;

	void Awake()
	{
		enemy = GameObject.FindWithTag("Enemy");
	}
}
