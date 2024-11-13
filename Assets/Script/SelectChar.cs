using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;
    void Start()
    {
    }
    private void OnMouseUpAsButton()
    {
        DataMgr.instance.selectedCharacter = character;
    }
}
