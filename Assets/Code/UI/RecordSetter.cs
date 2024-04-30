using UnityEngine;
using UnityEngine.UI;


public class RecordSetter : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetInt("score").ToString();
    }
}
