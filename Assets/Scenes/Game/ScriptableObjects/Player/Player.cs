using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : ScriptableObject
{

    //GameHandler
    [Header("Game Handler")]

    [Header("Money")]
    public int moneyInt;

    [Header("Money Generator")]
    public float generatorTime;
    public int moneyPerTime;
    public float timer = 0.0f;

    [Header("Sounds Effects Volumes")]
    public float backgroundMusicVolumeValue = 0f;

    //OptionsHandler


    //MailHandler

}
