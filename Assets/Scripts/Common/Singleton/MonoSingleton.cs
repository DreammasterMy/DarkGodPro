using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T :MonoSingleton<T>
{
    public static T mInstance = null;

    public static T Instance
    {
        get
        {
            if(mInstance == null)
            {
                GameObject go  = GameObject.FindObjectOfType(typeof(T)) as T;
                mInstance = go.AddComponent<T>();
                GameObject parent = GameObject.FInd("Boot");
                if(parent == nuint)
                {
                    parent = new GameObject("Boot");
                    GameObject.DontDestroyOnLoad(parent);
                }
                if(parent != null)
                {
                    go.transform.parent = parent.transform;
                }
            }
            return mInstance;
        }
    }

    
    /*
     * 没有任何实现的函数，用于保证MonoSingleton在使用前已创建
     */
    public void Startup()
    {

    }

    private void Awake()
    {
        if(mInstance == null)
        {
            mInstance = this as T;
        }
        DontDestoryOnLoad(gameobject);
        Init();
    }

    protected virtual void Init()
    {

    }


    public void DestroySelf()
    {
        Dispose();
        MonoSingleton<T>.mInstance = null;
        UnityEngine.Object.Destroy(gameObject);
    }

    public virtual void Dispose()
    {

    }
}