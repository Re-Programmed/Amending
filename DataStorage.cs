using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EmotionDatabase;

public class DataStorage : MonoBehaviour
{
    public static DataStorage INSTANCE;

    public BattleScenario battleScenario;

    public static SaveData savedata;

    public static void BackToMainScene()
    {
        SceneManager.LoadScene(0);

        SaveData.Load(savedata, GameObject.FindGameObjectWithTag("Player"));
    }

    private void Start()
    {
        savedata = new SaveData(Vector2.zero, new List<int>());
        SaveData.Load(savedata, GameObject.FindGameObjectWithTag("Player"));
    }

    public void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartBattle(BattleScenario bs)
    {
        savedata = new SaveData(GameObject.FindGameObjectWithTag("Player").transform.position, savedata.interactions);
        SaveData.Save(savedata);
        battleScenario = bs;
        SceneManager.LoadSceneAsync(1);
    }
}

[System.Serializable]
public class BattleScenario
{
    public string BattleTopic;
    public GameObject[] AvailableCards;
    public List<Cards.Card> EnemyCards;

    public int id;

    public CurrentSprite EnemySprite;
}

public class SaveData
{
    Vector2 playerPosition;

    public List<int> interactions = new List<int>();

    public static void Save(SaveData data)
    {
        PlayerPrefs.SetString(Base64Encode("player_pos_x"), Base64Encode(data.playerPosition.x.ToString()));

        string sinter = "0";

        foreach(int i in data.interactions)
        {
            sinter = sinter + "," + i;
        }

        PlayerPrefs.SetString(Base64Encode("player_interactions"), Base64Encode(sinter));
    }

    public static void Load(SaveData data, GameObject player)
    {
        player.transform.position = new Vector3(float.Parse(Base64Decode(PlayerPrefs.GetString(Base64Encode("player_pos_x"), Base64Encode("0")))), player.transform.position.y, player.transform.position.z);
        data.playerPosition = player.transform.position;

        data.interactions = new List<int>();

        string datainteractions = Base64Decode(PlayerPrefs.GetString(Base64Encode("player_interactions"), ""));

        foreach(string s in datainteractions.Split(','))
        {
            if (s == "") { continue; }
            int i = int.Parse(s);

            data.interactions.Add(i);
        }
    }

    public SaveData(Vector2 playerPosition, List<int> interactions)
    {
        this.playerPosition = playerPosition;
        this.interactions = interactions;
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}