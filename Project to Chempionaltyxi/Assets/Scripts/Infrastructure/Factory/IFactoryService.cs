using UnityEngine;

public interface IFactoryService : IService
{
    GameObject Create(Vector3 position, Quaternion rotation, Transform parent = null);
}
    
