using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GBE
{
    public class CardBase : ScriptableObject
    {
        [SerializeField] private string id;
        public string ID { get { return id; } }

        public string cardName;
        public Sprite cardIcon;

        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            string t_path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(t_path);
        }
        #endif

        public virtual CardBase GetDuplicate()
        {
            return Instantiate(this);
        }
    }
}