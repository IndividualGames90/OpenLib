using UnityEngine;

namespace IndividualGames.OpenLib.Pattern
{
    /// <summary>
    /// Essence of all factories.
    /// </summary>
    public interface IFactory
    {
        void Create(int key);
    }

    /// <summary>
    /// Essence of all Unity factories.
    /// </summary>
    public interface IGameObjectFactory : IFactory
    {
        public new GameObject Create(int key);
    }
}