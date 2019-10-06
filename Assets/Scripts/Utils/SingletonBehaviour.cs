using System;

using UnityEngine;

public class SingletonBehaviour<TObject> : MonoBehaviour
    where TObject : SingletonBehaviour<TObject>
{
    public static TObject Instance {
        get {
            if (m_Instance != null)
                return m_Instance;

            var instance = GameObject.FindObjectOfType<TObject>();

            if (instance == null) {
                throw new NullReferenceException($"Trying to access {typeof(TObject).FullName}.Instance but no object present in the scene.");
            } else {
                DontDestroyOnLoad(instance);
                m_Instance = instance;
                return m_Instance;
            }
        }
        set {

        }
    }
    private static TObject m_Instance;

    protected void Awake()
    {
        if (m_Instance == null) {
            m_Instance = (TObject)this;

            DontDestroyOnLoad(this);
        }
    }

    void OnDestroy()
    {
        m_Instance = null;
    }
}
