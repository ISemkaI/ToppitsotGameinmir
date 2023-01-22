using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Точка входа в игру: инициализация
// Указан первым в исполнении Script Execution Order.
public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject _enemyProjectilePrefab;
    [SerializeField] private GameObject _playerProjectilePrefab;

    [SerializeField] private GameManager _gameManager;

    //[SerializeField] private StandaloneInput _inputActionsStandalone; 
    
    // Инициализируем сервис-локатор через статику (там конструктор в свойстве)
    private readonly AllServices _allServices = AllServices.Instance; 

    private void Awake()
    {
        CheckOtherBootstrapperExistence();
        RegisterServices();
        InitializeGameManager();

        DontDestroyOnLoad(gameObject);
    }

    private void InitializeGameManager() 
        => _gameManager.Initialize();

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

        // Устанавливает управление в Standalone
        //_allServices.GetService<IInputService>().InputActionsBase = _inputActionsStandalone;
#else
        _allServices.RegisterService<IInputService>(new InputServiceVR());
#endif

        _allServices.RegisterService<IFactoryEnemyProjectile>(new ProjectileEnemyFactoryService(_enemyProjectilePrefab));
        _allServices.RegisterService<IFactoryPlayerProjectile>(new ProjectilePlayerFactoryService(_playerProjectilePrefab));

    }
}