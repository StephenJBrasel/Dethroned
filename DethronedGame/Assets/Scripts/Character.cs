using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
	[Header("Health")]
	[SerializeField] private float maxHealth = 10f;
	[SerializeField] private float minHealth = 0f;

	public UnityEvent DeathEvent;

	private float health;

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="Character"/> class.
	/// </summary>
	/// <param name="hp">The <see cref="Character"/>'s initial hp.</param>
	Character(float hp)
	{
		maxHealth = hp;
		Init();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Character"/> class.
	/// </summary>
	/// <param name="minHP">The minimum hp.</param>
	/// <param name="maxHP">The maximum hp.</param>
	Character(float minHP, float maxHP)
	{
		maxHealth = maxHP;
		minHealth = minHP;
		Init();
	}
	#endregion

	// Start is called before the first frame update
	void Start()
	{
		Init();
	}

	private void Init()
	{
		health = maxHealth;
		if (DeathEvent == null) DeathEvent = new UnityEvent();
	}

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// Adjusts the Characters health by the specified +/- value.
	/// </summary>
	/// <param name="value">The +/- value to change the character's health by.</param>
	public void Health(float value)
	{
		if(health + value <= minHealth)
		{
			health = minHealth;
			DeathEvent.Invoke();
			return;
		}
		if (health + value < maxHealth)
		{
			health += value;
		}
	}
}
