﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public int data_money;
    public int data_cloth;
    public int date;

}

public class GameStaticData : MonoBehaviour
{
    //데이터 베이스 저장 x 변수들
    public float clock_hand_rot = 0;
    public float mainscene_time = 0;
    public int click_count = 0;
    public bool is_click = false;

    public static GameData data;
    public Text dateStart;
    public List<Sprite> startButton;
    public GameObject start_button;

    void Awake()
    {
        PlayerPrefs.SetInt("Story_Start", PlayerPrefs.GetInt("Story_Start", 0));
        DontDestroyOnLoad(GameObject.Find("GameData"));

        if (PlayerPrefs.GetInt("Story_Start") != 0 && File.Exists(Application.persistentDataPath + "/GameData.json"))
        {
            Debug.LogWarning("게임파일있음");
            Debug.Log("파일 주소: " + Application.persistentDataPath + "/GameData.json");
            LoadGameData();
        }
        else
        {
            Debug.LogWarning("게임파일없음");
            File.Create(Application.persistentDataPath + "/GameData.json").Close();
            data = JsonUtility.FromJson<GameData>("{\"data_money\": 100000,\"data_cloth\": 0,\"date\" :  0}");
            File.WriteAllText(Application.persistentDataPath + "/GameData.json", JsonUtility.ToJson(data));
            
            Invoke("LoadGameData", 0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        if (data.date > 0)
        {
            start_button.GetComponent<Image>().sprite = startButton[1];
            dateStart.text = data.date.ToString();
            dateStart.transform.gameObject.SetActive(true);
        }
        else
        {
            start_button.GetComponent<Image>().sprite = startButton[0];
            dateStart.transform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape) && !this.is_click)
        {
            this.StartCoroutine(this.CrQuitTimer());
            this.is_click = true;

            this.click_count++;
            Debug.Log(this.click_count);

            if(this.click_count >= 2)
            {
                this.click_count = 0;
                this.is_click = false;
                Application.Quit();
            }
        }

    }

    IEnumerator CrQuitTimer()
    {
        yield return new WaitForSeconds(0.1f);
        this.is_click = false;

        yield return new WaitForSeconds(0.3f);
        this.is_click = false;
        this.click_count = 0;

    }

    public void LoadGameData()
    {
        string str = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        data = JsonUtility.FromJson<GameData>(str);

        Debug.Log("불러온 데이터" + str);
    }


    // 게임 저장하기
    public void SaveGameData()
    {
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", JsonUtility.ToJson(data));

        Invoke("LoadGameData", 0.5f);
    }

    public void DateUp()
    {
        data.date++;
        SaveGameData();

    }

    public void DataClear()
    {
        data.date = 0;
        SaveGameData();
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
