using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GBE
{
    public class CardBase : ScriptableObject
    {
        public enum CardType
        {
            Attack,
            Defense,
            Disruption,
            Support
        }

        [SerializeField] private string id;
        public string ID { get { return id; } }
        public string CardName;
        public CardType cardType;
        [TextArea(3, 6)] public string cardDescription;

        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            string t_path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(t_path);
        }
        #endif

        public virtual CardBase GetDuplicate()
        {
            return this;
        }
    }
}