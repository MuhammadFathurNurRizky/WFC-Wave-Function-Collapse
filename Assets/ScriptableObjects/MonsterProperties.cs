using UnityEngine;

[CreateAssetMenu(fileName = "MonsterProperties", menuName = "Scriptable Objects/MonsterProperties")]
public class MonsterProperties : ScriptableObject
{
    [Range(0f, 25f)]
    public int monsterHealth;

    [Range(0f, 15f)]
    public int monsterDamage;
}

// Monster 1 = healthMax = 5, damage = 3
// Monster 2 = healthMax = 10, damage = 6
// Monster 3 = healthMax = 15, damage = 9
// Monster 4 = healthMax = 20, damage = 12
// Monster 5 = healthMax = 25, damage = 15
