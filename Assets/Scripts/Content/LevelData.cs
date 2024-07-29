using Entities;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelData", fileName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public LongTerm LongTermPrefab { get; private set; }
    }
}