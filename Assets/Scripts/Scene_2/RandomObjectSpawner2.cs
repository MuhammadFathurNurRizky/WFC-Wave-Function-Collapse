using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Monsters;


public class RandomObjectSpawner2 : MonoBehaviour
{
    [Header("Monster Section 1")]
    [SerializeField] GameObject myObjects1;
    [SerializeField] GameObject myObjects2;

    [Header("Monster Section 2")]
    [SerializeField] GameObject myObjects1_Section2;
    [SerializeField] GameObject myObjects2_Section2;
    [SerializeField] GameObject myObjects3_Section2;

    [Header("Monster Section 3")]
    [SerializeField] GameObject myObjects1_Section3;
    [SerializeField] GameObject myObjects2_Section3;
    [SerializeField] GameObject myObjects3_Section3;
    [SerializeField] GameObject myObjects4_Section3;

    [Header("Monster Section 4")]
    [SerializeField] GameObject myObjects1_Section4;
    [SerializeField] GameObject myObjects2_Section4;
    [SerializeField] GameObject myObjects3_Section4;
    [SerializeField] GameObject myObjects4_Section4;

    [Header("Monster Section 5")]
    [SerializeField] GameObject myObjects1_Section5;
    [SerializeField] GameObject myObjects2_Section5;
    [SerializeField] GameObject myObjects3_Section5;
    [SerializeField] GameObject myObjects4_Section5;
    [SerializeField] GameObject myObjects5_Section5;

    [Header("Text Properties & Infos")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text damageText;
    [SerializeField] TMP_Text totalPower;
    [SerializeField] TMP_Text sectionText;

    [Header("TriggerEnter")]
    [SerializeField] GameObject levelTrigger;
    [SerializeField] GameObject levelTrigger2;
    [SerializeField] GameObject levelTrigger3;
    [SerializeField] GameObject levelTrigger4;
    [SerializeField] GameObject levelTrigger5;
    Monster monster1;
    Monster monster2;
    Monster monster3;
    Monster monster4;
    Monster monster5;
    int randomMonster;
    int randomMonsterWave2;
    int randomMonsterWave3;
    int randomMonsterWave4;
    int randomMonsterWave5;
    int randomNumberBetweenOneAndTwo;
    int totalWavePower1;
    int totalWavePower2;
    int totalWavePower3;
    int totalWavePower4;
    int totalWavePower5;
    int totalMonsterPower1;
    int totalMonsterPower2;
    int totalMonsterPower3;
    int totalMonsterPower4;
    int totalMonsterPower5;
    private int wave;
//  hasil dari random.range misal 5 di loop-kan dan dimasukkan langsung ke array daripada game objek satu
//  persatu menggunakan for loop. Hasilnya object1_section1 terisi sampai dengan array [5, 1]. Jika ingin
//  mengakses object1_section1 pada bagian ke 3 maka menjadi [3, 1]. Setelah itu tinggal membuat
//  algoritma untuk conditional daripada spawn semua jenis monster satu-persatu. yaitu jika monster
//  1_section1 mati maka spawn-kan monster1_section1 yang ke 2 dan jika tidak jangan lakukan apapun.
    private GameObject[,] monsterWave1 = new GameObject[10, 5]; // [rows, column]
                                                                // { {1, 2, ...}, {1, 2, ...}, rows }
    private GameObject[,] monsterWave2 = new GameObject[10, 5]; // [rows, column]
                                                                // { {1, 2, ...}, {1, 2, ...}, rows }
    private GameObject[,] monsterWave3 = new GameObject[10, 5]; // [rows, column]
                                                                // { {1, 2, ...}, {1, 2, ...}, rows }
    private GameObject[,] monsterWave4 = new GameObject[10, 5]; // [rows, column]
                                                                // { {1, 2, ...}, {1, 2, ...}, rows }
    private GameObject[,] monsterWave5 = new GameObject[10, 5]; // [rows, column]
                                                                // { {1, 2, ...}, {1, 2, ...}, rows }

    void Start()
    {
        wave = 1;
        randomMonster = Random.Range(1, 10);
        randomMonsterWave2 = Random.Range(1, 10);
        randomMonsterWave3 = Random.Range(1, 10);
        randomMonsterWave4 = Random.Range(1, 10);
        randomMonsterWave5 = Random.Range(1, 10);
        randomNumberBetweenOneAndTwo = Random.Range(1, 2);
        Debug.Log($"Start - RandomMonster : {randomMonster}");
        Debug.Log($"Start - RandomMonsterWave 2 : {randomMonsterWave2}");
        Debug.Log($"Start - RandomMonsterWave 3 : {randomMonsterWave3}");
        Debug.Log($"Start - RandomMonsterWave 4 : {randomMonsterWave4}");
        Debug.Log($"Start - RandomMonsterWave 5 : {randomMonsterWave5}");
        monster1 = new Monster(5, 3);
        monster2 = new Monster(10, 6);
        monster3 = new Monster(15, 9);
        monster4 = new Monster(20, 12);
        monster5 = new Monster(25, 15);
        totalWavePower1 = 50;
        totalWavePower2 = 100;
        totalWavePower3 = 150;
        totalWavePower4 = 200;
        totalWavePower5 = 250;
        totalMonsterPower1 = monster1.TotalMonsterPower();
        totalMonsterPower2 = monster2.TotalMonsterPower();
        totalMonsterPower3 = monster3.TotalMonsterPower();
        totalMonsterPower4 = monster4.TotalMonsterPower();
        totalMonsterPower5 = monster5.TotalMonsterPower();
    }

    void Monster2(int jumlah, int totalWavePower, int totalMonsterPower, GameObject monsterObject, float spawnPositionX, float spawnPositionY, float spawnPositionZ)
    {
        // Debug.Log($"jumlah : {jumlah}"); // jumlah adalah nilai random dari Monster 1
        // Debug.Log($"totalWavePower : {totalWavePower}");
        // Debug.Log($"totalMonsterPower_1 : {totalMonsterPower}");
        float sisa = totalWavePower - jumlah * totalMonsterPower; // 50 - 4 * 8 = 18
        float result = sisa % totalMonsterPower2; // 18 % 16 = 2
        float divition = sisa / totalMonsterPower2;
        Debug.Log($"Sisa Untuk Monster 2 : {sisa}");
        Debug.Log($"Result Monster 2 : {result}");
        if (result == 0 && divition >= 2)
        {
            for (int a = 0; a < randomNumberBetweenOneAndTwo; a++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 2 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Pertama");
        }
        else if (result >= 1 && divition > 1 && divition < 2)
        {
            // 1
            Debug.Log("Monster 2 : 1");
            Debug.Log($"Memilih Pilihan Kedua");
            Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
            Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
        }
        else if (divition < 1)
        {
            // 0
            Debug.Log("Monster 2 : 0");
            Debug.Log($"Memilih Pilihan Ketiga");
        }
        else if (result >=1 && divition > 2)
        {
            for (int b = 0; b < randomNumberBetweenOneAndTwo; b++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 2 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Keempat");
        }
        else
        {
            Debug.Log("Selesai Tidak ada Pilihan Lagi");
        }
    }

    void Monster3(int jumlah, int totalWavePower, int totalMonsterPower_1, int totalMonsterPower_2, GameObject monsterObject, float spawnPositionX, float spawnPositionY, float spawnPositionZ)
    {
        // Debug.Log($"jumlah : {jumlah}");
        // Debug.Log($"totalWavePower : {totalWavePower}");
        // Debug.Log($"totalMonsterPower_1 : {totalMonsterPower_1}");
        // Debug.Log($"totalMonsterPower_2 : {totalMonsterPower_2}");
        float sisa = totalWavePower - jumlah * totalMonsterPower_1 - totalMonsterPower_2 * randomNumberBetweenOneAndTwo; 
        // sisa = 100 - 8 * 1 - 1 * 16 = 72
        float result = sisa % totalMonsterPower3; // 20 % 24 = 20
        float divition = sisa / totalMonsterPower3;
        Debug.Log($"Sisa Untuk Monster 3 : {sisa}");
        Debug.Log($"Result Monster 3 : {result}");
        if (result == 0 && divition >= 2)
        {
            for (int c = 0; c < randomNumberBetweenOneAndTwo; c++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 3 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Pertama");
        }
        else if (result >= 1 && divition >= 1 && divition <= 2)
        {
            // 1
            Debug.Log("Monster 3 : 1");
            Debug.Log($"Memilih Pilihan Kedua");
            Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
            Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
        }
        else if (result < 1)
        {
            // 0
            Debug.Log("Monster 3 : 0");
            Debug.Log($"Memilih Pilihan Ketiga");
        }
        else if (result >=1 && divition >= 2)
        {
            for (int d = 0; d < randomNumberBetweenOneAndTwo; d++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 3 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Keempat");
        }
        else
        {
            Debug.Log("Selesai Tidak ada Pilihan Lagi");
        }
    }
    void Monster4(int jumlah, int totalWavePower, int totalMonsterPower_1, int totalMonsterPower_2, int totalMonsterPower_3, GameObject monsterObject, float spawnPositionX, float spawnPositionY, float spawnPositionZ)
    {
        // Debug.Log($"jumlah : {jumlah}");
        // Debug.Log($"totalWavePower : {totalWavePower}");
        // Debug.Log($"totalMonsterPower_1 : {totalMonsterPower_1}");
        // Debug.Log($"totalMonsterPower_2 : {totalMonsterPower_2}");
        float sisa = totalWavePower - jumlah * totalMonsterPower_1 - totalMonsterPower_2 * randomNumberBetweenOneAndTwo - totalMonsterPower_3 * randomNumberBetweenOneAndTwo; 
        // sisa = 150 - 8 * 1 - 1 * 16 - 1 * 24 = 
        float result = sisa % totalMonsterPower4; //  % 32 = 
        float divition = sisa / totalMonsterPower4;
        Debug.Log($"Sisa Untuk Monster 4 : {sisa}");
        Debug.Log($"Result Monster 4 : {result}");
        if (result == 0 && divition >= 2)
        {
            for (int c = 0; c < randomNumberBetweenOneAndTwo; c++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 4 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Pertama");
        }
        else if (result >= 1 && divition >= 1 && divition <= 2)
        {
            // 1
            Debug.Log("Monster 4 : 1");
            Debug.Log($"Memilih Pilihan Kedua");
            Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
            Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
        }
        else if (result < 1)
        {
            // 0
            Debug.Log("Monster 4 : 0");
            Debug.Log($"Memilih Pilihan Ketiga");
        }
        else if (result >=1 && divition >= 2)
        {
            for (int d = 0; d < randomNumberBetweenOneAndTwo; d++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 4 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Keempat");
        }
        else
        {
            Debug.Log("Selesai Tidak ada Pilihan Lagi");
        }
    }
    void Monster5(int jumlah, int totalWavePower, int totalMonsterPower_1, int totalMonsterPower_2, int totalMonsterPower_3, int toalMonsterPower_4, GameObject monsterObject, float spawnPositionX, float spawnPositionY, float spawnPositionZ)
    {
        // Debug.Log($"jumlah : {jumlah}");
        // Debug.Log($"totalWavePower : {totalWavePower}");
        // Debug.Log($"totalMonsterPower_1 : {totalMonsterPower_1}");
        // Debug.Log($"totalMonsterPower_2 : {totalMonsterPower_2}");
        float sisa = totalWavePower - jumlah * totalMonsterPower_1 - totalMonsterPower_2 * randomNumberBetweenOneAndTwo - totalMonsterPower_3 * randomNumberBetweenOneAndTwo - toalMonsterPower_4 * randomNumberBetweenOneAndTwo; 
        // sisa = 200 - 8 * 1 - 1 * 16 - 1 * 24 - 1 * 32 = 
        float result = sisa % totalMonsterPower5; //  % 40 = 
        float divition = sisa / totalMonsterPower5;
        Debug.Log($"Sisa Untuk Monster 5 : {sisa}");
        Debug.Log($"Result Monster 5 : {result}");
        if (result == 0 && divition >= 2)
        {
            for (int c = 0; c < randomNumberBetweenOneAndTwo; c++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 5 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Pertama");
        }
        else if (result >= 1 && divition >= 1 && divition <= 2)
        {
            // 1
            Debug.Log("Monster 5 : 1");
            Debug.Log($"Memilih Pilihan Kedua");
            Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
            Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
        }
        else if (result < 1)
        {
            // 0
            Debug.Log("Monster 5 : 0");
            Debug.Log($"Memilih Pilihan Ketiga");
        }
        else if (result >=1 && divition >= 2)
        {
            for (int d = 0; d < randomNumberBetweenOneAndTwo; d++)
            {
                Vector3 randomSpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
                Instantiate(monsterObject, randomSpawnPosition, Quaternion.identity);
            }
            Debug.Log($"Monster 5 : {randomNumberBetweenOneAndTwo}");
            Debug.Log($"Memilih Pilihan Keempat");
        }
        else
        {
            Debug.Log("Selesai Tidak ada Pilihan Lagi");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LevelTrigger"))
        {
            Destroy(levelTrigger);
            sectionText.text = $"Section : {wave}";
            totalPower.text = $"Total Power : {totalWavePower1}";
            int randomMonsterChange = Random.Range(1, 5);
            if (randomMonster * totalMonsterPower1 > totalWavePower1)
            {
                for (int j = 0; j < randomMonsterChange; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(520, 530), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster Change : {randomMonsterChange}");
                Monster2(randomMonsterChange, totalWavePower1, totalMonsterPower1, myObjects2, Random.Range(520, 530), 0.3f, Random.Range(150, 170));
            }
            else
            {
                for (int j = 0; j < randomMonster; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(520, 530), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster : {randomMonster}");
                Monster2(randomMonsterChange, totalWavePower1, totalMonsterPower1, myObjects2, Random.Range(520, 530), 0.3f, Random.Range(150, 170));
            }
        }
        
        if (other.gameObject.CompareTag("LevelTrigger2"))
        {
            Destroy(levelTrigger2);
            sectionText.text = $"Section : {wave}";
            totalPower.text = $"Total Power : {totalWavePower2}";
            int randomMonsterChange = Random.Range(1, 5);
            if (randomMonsterWave2 * totalMonsterPower1 > totalWavePower2)
            {
                for (int j = 0; j < randomMonsterChange; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(550, 560), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section2, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster Change - wave 2 : {randomMonsterChange}");
                Monster2(randomMonsterChange, totalWavePower2, totalMonsterPower1, myObjects2_Section2, Random.Range(550, 560), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower2, totalMonsterPower1, totalMonsterPower2, myObjects3_Section2, Random.Range(550, 560), 0.3f, Random.Range(150, 170));
            }
            else
            {
                for (int j = 0; j < randomMonsterWave2; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(550, 560), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section2, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster - wave 2 : {randomMonsterWave2}");
                Monster2(randomMonsterChange, totalWavePower2, totalMonsterPower1, myObjects2_Section2, Random.Range(550, 560), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower2, totalMonsterPower1, totalMonsterPower2, myObjects3_Section2, Random.Range(550, 560), 0.3f, Random.Range(150, 170));
            }
        }
        
        if (other.gameObject.CompareTag("LevelTrigger3"))
        {
            Destroy(levelTrigger3);
            sectionText.text = $"Section : {wave}";
            totalPower.text = $"Total Power : {totalWavePower3}";
            int randomMonsterChange = Random.Range(1, 5);
            if (randomMonsterWave3 * totalMonsterPower1 > totalWavePower3)
            {
                for (int j = 0; j < randomMonsterChange; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(600, 610), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section3, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster Change - wave 3 : {randomMonsterChange}");
                Monster2(randomMonsterChange, totalWavePower3, totalMonsterPower1, myObjects2_Section3, Random.Range(600, 610), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower3, totalMonsterPower1, totalMonsterPower2, myObjects3_Section3, Random.Range(600, 610), 0.3f, Random.Range(150, 170));
                Monster4(randomMonsterChange, totalWavePower3, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, myObjects4_Section3, Random.Range(600, 610), 0.3f, Random.Range(150, 170));
            }
            else
            {
                for (int j = 0; j < randomMonsterWave3; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(600, 610), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section3, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster - wave 3 : {randomMonsterWave3}");
                Monster2(randomMonsterChange, totalWavePower3, totalMonsterPower1, myObjects2_Section3, Random.Range(600, 610), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower3, totalMonsterPower1, totalMonsterPower2, myObjects3_Section3, Random.Range(600, 610), 0.3f, Random.Range(150, 170));
                Monster4(randomMonsterChange, totalWavePower3, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, myObjects4_Section3, Random.Range(600, 610), 0.3f, Random.Range(150, 170));
            }
        }
        
        if (other.gameObject.CompareTag("LevelTrigger4"))
        {
            Destroy(levelTrigger4);
            sectionText.text = $"Section : {wave}";
            totalPower.text = $"Total Power : {totalWavePower4}";
            int randomMonsterChange = Random.Range(1, 5);
            if (randomMonsterWave4 * totalMonsterPower1 > totalWavePower4)
            {
                for (int j = 0; j < randomMonsterChange; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(630, 640), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section4, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster Change - wave 2 : {randomMonsterChange}");
                Monster2(randomMonsterChange, totalWavePower4, totalMonsterPower1, myObjects2_Section4, Random.Range(630, 640), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower4, totalMonsterPower1, totalMonsterPower2, myObjects3_Section4, Random.Range(630, 640), 0.3f, Random.Range(150, 170));
                Monster4(randomMonsterChange, totalWavePower4, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, myObjects4_Section4, Random.Range(630, 640), 0.3f, Random.Range(150, 170));
            }
            else
            {
                for (int j = 0; j < randomMonsterWave4; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(630, 640), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section4, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster - wave 2 : {randomMonsterWave4}");
                Monster2(randomMonsterChange, totalWavePower4, totalMonsterPower1, myObjects2_Section4, Random.Range(630, 640), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower4, totalMonsterPower1, totalMonsterPower2, myObjects3_Section4, Random.Range(630, 640), 0.3f, Random.Range(150, 170));
                Monster4(randomMonsterChange, totalWavePower4, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, myObjects4_Section4, Random.Range(630, 640), 0.3f, Random.Range(150, 170));
            }
        }
        
        if (other.gameObject.CompareTag("LevelTrigger5"))
        {
            Destroy(levelTrigger5);
            sectionText.text = $"Section : {wave}";
            totalPower.text = $"Total Power : {totalWavePower5}";
            int randomMonsterChange = Random.Range(1, 5);
            if (randomMonsterWave5 * totalMonsterPower1 > totalWavePower5)
            {
                for (int j = 0; j < randomMonsterChange; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section5, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster Change - wave 2 : {randomMonsterChange}");
                Monster2(randomMonsterChange, totalWavePower5, totalMonsterPower1, myObjects2_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower5, totalMonsterPower1, totalMonsterPower2, myObjects3_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                Monster4(randomMonsterChange, totalWavePower5, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, myObjects4_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                Monster5(randomMonsterWave5, totalWavePower5, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, totalMonsterPower4, myObjects5_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
            }
            else
            {
                for (int j = 0; j < randomMonsterWave5; j++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                    Instantiate(myObjects1_Section5, randomSpawnPosition, Quaternion.identity);
                }
                wave += 1;
                Debug.Log($"Monster 1 Random Monster - wave 2 : {randomMonsterWave5}");
                Monster2(randomMonsterChange, totalWavePower5, totalMonsterPower1, myObjects2_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                Monster3(randomMonsterChange, totalWavePower5, totalMonsterPower1, totalMonsterPower2, myObjects3_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                Monster4(randomMonsterChange, totalWavePower5, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, myObjects4_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
                Monster5(randomMonsterWave5, totalWavePower5, totalMonsterPower1, totalMonsterPower2, totalMonsterPower3, totalMonsterPower4, myObjects5_Section5, Random.Range(670, 680), 0.3f, Random.Range(150, 170));
            }
        }
    }
}
