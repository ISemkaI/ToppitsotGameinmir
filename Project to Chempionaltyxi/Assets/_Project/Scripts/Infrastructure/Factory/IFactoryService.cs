using UnityEngine;

public interface IFactoryService : IService
{
    GameObject Create(Vector3 position, Transform parent = null);
}
    
