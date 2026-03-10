using UnityEngine;

public class BaseItem : ScriptableObject
{
    [SerializeField] private string m_id;
    [SerializeField] private string m_name;
    [SerializeField] private string m_description;
    [SerializeField] private Sprite m_icon;
    
    public string ID => m_id;
    public string Name => m_name;
    public string Description => m_description;
    public Sprite Icon => m_icon;
}
