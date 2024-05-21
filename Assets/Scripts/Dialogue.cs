using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string NPC_name;

    [SerializeField]
    [TextArea(3,10)]
    private string[] sentences;

    public string GetNpcName()
    {
        return NPC_name;
    }

    public string[] GetSentences()
    {
        return sentences;
    }


}
