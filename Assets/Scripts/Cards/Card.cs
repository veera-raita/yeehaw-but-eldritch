using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GBE
{
    [CreateAssetMenu(menuName = "Card System/Card", fileName = "New Card")]
    public class Card : ScriptableObject
    {
        public CardAction[] action;

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

        public virtual Card GetDuplicate()
        {
            return Instantiate(this);
        }

        public void Use(Battler t_target)
        {
            foreach (CardAction t_action in action)
            {
                t_action.PerformAction(t_target);
            }
        }
    }
}