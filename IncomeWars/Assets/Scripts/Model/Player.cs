﻿using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;

/// <summary>
/// Model class for player state
/// </summary>
[Serializable]
public class Player
{
	public int index;
	public Color color;
	public string name;
	public int income;
	public int money;
}
