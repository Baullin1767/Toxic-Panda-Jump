using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RecordLoad : MonoBehaviour
{
    private void OnEnable()
    {
        recordtext = GetComponent<Text>();
        YandexGame.GetDataEvent += GetLoad;
    }
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;
    Text recordtext;
    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }
    // Ваш метод для загрузки, который будет запускаться в старте
    public void GetLoad()
    {
        recordtext.text = YandexGame.savesData.score.ToString();
    }
}
