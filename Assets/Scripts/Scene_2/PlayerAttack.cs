using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animation anim;
    private int playerHealth1;
    private int playerDamage1;
    private int monsterHealth1;
    private int monsterDamage1;
    public GameObject monsterCharacter;

    void Start()
    {
        anim = GetComponent<Animation>();
        monsterCharacter = GetComponent<GameObject>();


        Properties player1 = new Properties();
        playerHealth1 = player1.PlayerHealth(10);
        playerDamage1 = player1.PlayerDamage(2);

        Properties monster1 = new Properties();
        monsterHealth1 = monster1.MonsterHealth(5);
        monsterDamage1 = monster1.MonsterDamage(3);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Monster"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Kiri");
                GiveDamage();
            }
        }
    }

    public void GiveDamage()
    {
        Debug.Log(monsterCharacter);
        monsterHealth1 = monsterHealth1 - playerDamage1;
        Debug.Log($"Monster Health: " + monsterHealth1);
        if (monsterHealth1 <= 0)
        {
            Destroy(monsterCharacter);
        }
    }

    public void BlockDamage()
    {
        playerDamage1 = 0;
    }

    public class Properties
    {
        public PlayerProperties player = ScriptableObject.CreateInstance<PlayerProperties>();
        public MonsterProperties monster = ScriptableObject.CreateInstance<MonsterProperties>();

        public int PlayerHealth(int playerHealth)
        {
            return player.playerHealth = playerHealth;
        }

        public int PlayerDamage(int playerDamage)
        {
            return player.playerDamage = playerDamage;
        }

        public int MonsterHealth(int monsterHealth)
        {
            return monster.monsterHealth = monsterHealth;
        }

        public int MonsterDamage(int monsterDamage)
        {
            return monster.monsterDamage = monsterDamage;
        }
    }
}
