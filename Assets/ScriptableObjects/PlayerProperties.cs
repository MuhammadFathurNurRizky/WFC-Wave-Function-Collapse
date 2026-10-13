using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName = "Scriptable Objects/PlayerProperties")]
public class PlayerProperties : ScriptableObject
{
    [Range(0f, 30f)]
    public int playerHealth;

    [Range(0f, 12f)]
    public int playerDamage;
}

// Stage 1 = healthMax = 10, damage = 2
// Stage 2 = healthMax = 15, damage = 4
// Stage 3 = healthMax = 20, damage = 6
// Stage 4 = healthMax = 25, damage = 9
// Stage 5 = healthMax = 30, damage = 12
