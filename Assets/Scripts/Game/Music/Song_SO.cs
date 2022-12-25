using UnityEngine;

[CreateAssetMenu(fileName = "SongInfo", menuName = "Rhythm Gag/Song Data")]
public class Song_SO : ScriptableObject
{
    public AudioClip song;
    public int bpm;
}
