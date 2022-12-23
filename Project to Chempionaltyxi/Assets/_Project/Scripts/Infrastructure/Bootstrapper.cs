using System;
using UnityEngine;

// Точка входа в игру: инициализация
// Указан первым в исполнении Script Execution Order.
public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject _enemyProjectilePrefab;
    [SerializeField] private GameObject _playerProjectilePrefab;

    // Инициализируем сервис-локатор через статику (там конструктор в свойстве)
    private readonly AllServices _allServices = AllServices.Instance; 

    private void Awake()
    {
        CheckOtherBootstrapperExistence();
        RegisterServices();
        DontDestroyOnLoad(gameObject);
    }

    private void CheckOtherBootstrapperExistence()
    {
        if (GameObject.FindObjectOfType<Bootstrapper>() != null)
            Destroy(gameObject);
    }

    private void RegisterServices()
    {
        // Макрос компиляции кода в зависимости от того, работаем мы в юнити или с ВР
        // БИЛДЫ ПОКА ЧТО РАБОТАТЬ НЕ БУДУТ!
#if UNITY_EDITOR
        _allServices.RegisterService<IInputService>(new InputServiceStandalone());
#else
        _allServices.RegisterService<IInputService>(new InputServiceVR());
#endif

        _allServices.RegisterService<IFactoryEnemyProjectile>(new ProjectileEnemyFactoryService(_enemyProjectilePrefab));
        _allServices.RegisterService<IFactoryProjectile>(new ProjectilePlayerFactoryService(_enemyProjectilePrefab));

    }
}