using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GBE
{
    public class CardBase : ScriptableObject
    {
        // Use an id-based system to avoid referencing the wrong
        // instance of the object.
        [SerializeField] private string id;
        public string ID { get { return id; } }

        public string cardName;
        public Sprite cardIcon;

        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            // This generates the random id for the card instance.
            string t_path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(t_path);
        }
        #endif

        // Call this function when generating a new instance of a card.
        public virtual CardBase GetDuplicate()
        {
            return Instantiate(this);
        }
    }
}