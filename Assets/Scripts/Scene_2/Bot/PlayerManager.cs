using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int playerHealth1;
    private int playerDamage1;
    private int monsterHealth1;
    private int monsterDamage1;

    [SerializeField] GameObject monster;
    private Animator animMonster;
    private Animation animPlayer;
    private CharacterController colliders;

    [Header("Text Properties & Infos")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text damageText;
    [SerializeField] Canvas healthBar;
    RectTransform rectTransform;

    private void Start()
    {
        monster = GetComponent<GameObject>();
        //animMonster = monster.GetComponent<Animator>();
        animPlayer = GetComponent<Animation>();
        colliders = GetComponent<CharacterController>();
        rectTransform = healthBar.GetComponent<RectTransform>();
    }

    private void Update()
    {
        healthText.text = $"Health : {playerHealth1}";

        if (playerHealth1 < 10 && playerHealth1 % 7 == 0)
        {
            rectTransform.offsetMax = new Vector2(-250, 0);
        }
        else if (playerHealth1 < 10 && playerHealth1 / 4 == 0)
        {
            rectTransform.offsetMax = new Vector2(-450, 0);
        }
    }

    private void Awake()
    {
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
            //if (animMonster.GetBool("attacking"))
            //{
            //    TakeHit();
            //}
            TakeHit();
        }
        else if (hit.gameObject.CompareTag("HealthPointSave"))
        {
            Properties player = new Properties();
            playerHealth1 = player.PlayerHealth(10);
            Debug.Log(playerHealth1);
        }
    }

    public bool TakeHit()
    {
        playerHealth1 = playerHealth1 - monsterDamage1;
        Debug.Log(playerHealth1);
        bool isDead = playerHealth1 <= 0;
        if (isDead)
        {
            _Die();
        }
        return isDead;
    }

    public bool BlockDamage()
    {
        bool blockingDamage = Input.GetMouseButton(1);
        if (blockingDamage)
        {
            monsterDamage1 = 0;
        }
        else
        {
            monsterDamage1 = 3;
        }
        return blockingDamage;
    }

    private void _Die()
    {
        Destroy(gameObject);
    }
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