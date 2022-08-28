using UnityEngine;

[DisallowMultipleComponent]
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public bool dontDestroyOnLoad;

    private static T _instance;
    private static object _syncRoot = new object();

    public static T Instance
    {
        get
        {
            Initialize();
            return _instance;
        }
    }

    public static bool IsInitialized => _instance != null;

    public static void Initialize()
    {
        if (IsInitialized)
        {
            return;
        }

        lock (_syncRoot)
        {
            _instance = FindObjectOfType<T>();

            if (!IsInitialized)
            {
                var go = new GameObject(typeof(T).FullName);
                _instance = go.AddComponent<T>();
            }
        }
    }

    protected virtual void Awake()
    {
        if (IsInitialized)
        {
            Debug.LogError(GetType().Name + " Singleton class is already created.");
            Destroy(gameObject);
            return;
        }

        Initialize();

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}