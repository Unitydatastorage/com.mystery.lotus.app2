using Entities;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelsDatabase", fileName = "Level Database")]
    public class LevelsDatabase : ScriptableObject
    {
        [field: SerializeField] public LongTerm[] GameFields { get; private set; }
    }
}