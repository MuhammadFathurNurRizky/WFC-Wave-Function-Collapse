//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;


//public class RandomObjectSpawner_2 : MonoBehaviour
//{
//    [SerializeField] GameObject[] myObjects;
//    [SerializeField] int wave;
//    [SerializeField] int power;
//    [SerializeField] int level;
//    [SerializeField] TMP_Text powerText;
//    [SerializeField] TMP_Text levelText;
//    // Start is called before frame start
//    void Start()
//    {
//        power = 2;
//        level = 1;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        powerText.text = $"Power : {power}";
//        levelText.text = $"Level : {level}";
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            for (int i = 0; power < 20; i++)
//            {
//                if (power == 2 && level == 1)
//                {
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[0], randomSpawnPosition, Quaternion.identity);
//                    power += 1;
//                    Debug.Log(power);
//                    level += 1;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 3 && level == 2)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 1);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 5 && level == 3)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 2);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 7 && level == 4)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 3);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 9 && level == 5)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 4);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 11 && level == 6)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 5);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 13 && level == 7)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 5);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 15 && level == 8)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 5);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 17 && level == 8)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 5);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                    break;
//                }
//                else if (power == 19 && level == 9)
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 5);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                }
//                else
//                {
//                    int randomInitialization = UnityEngine.Random.Range(0, 5);
//                    Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 5, UnityEngine.Random.Range(-10, 11));
//                    Instantiate(myObjects[randomInitialization], randomSpawnPosition, Quaternion.identity);
//                    power += 2;
//                    Debug.Log(power);
//                    level++;
//                    Debug.Log(level);
//                }
//            }
//        }
//    }
//}
