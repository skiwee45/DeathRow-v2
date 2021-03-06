﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int maxHealth = 2;
	public int currentHealth;
	public GameObject dieEffect;
	private LevelManager levelManager;


	// Start is called before the first frame update
	void Start()
	{
		currentHealth = 2;
		levelManager = FindObjectOfType<LevelManager>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth <= 0)
		{
			GameObject effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
			//make level manager count 1 kill
			levelManager.killEnemy();
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		Debug.Log("damage taken");
	}
}
