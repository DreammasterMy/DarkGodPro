using System;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// 说明：xLua管理类
/// 注意：
/// 1、整个Lua虚拟机执行的脚本分成3个模块：热修复、公共模块、逻辑模块
/// 2、公共模块：提供Lua语言级别的工具类支持，和游戏逻辑无关，最先被启动
/// 3、热修复模块：脚本全部放Lua/XLua目录下，随着游戏的启动而启动
/// 4、逻辑模块：资源热更完毕后启动
/// 5、资源热更以后，理论上所有被加载的Lua脚本都要重新执行加载，如果热更某个模块被删除，则可能导致Lua加载异常，这里的方案是释放掉旧的虚拟器另起一个
/// </summary>

public class XLuaManager : MonoSingleton<XLuaManager>
{
    public const string luaAssetbundleAssetName = "Lua";
    public const string luaScriptsFolder = "LuaScripts";
    const string commonMainScriptName = "Common.Main";
    const string gameMainScriptName = "GameMain";
    const string hotfixMainScriptName = "XLua.HotfixMain";
    LuaEnv luaEnv = null;
    LuaUpdate luaUpdate = null;


    protected override void Init()
    {
        base.Init();
        //AssetBundle todo

        
    }


    public bool HasGameStart
    {
        get;
        protected set;
    }

    void InitLuaEnv()
    {
        luaEnv = new LuaEnv();
        HasGameStart = false;
        if (luaEnv != null)
        {
            //luaEnv.AddLoader(CustomLoader);
            //luaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPb);
        }
        else
        { 
        
        }
    }

//    public static byte[] CustomLoader(ref string filepath)
//    {
//        string scriptPath = string.Empty;
//        filepath = filepath.Replace(".", "/") + ".lua";
//#if UNITY_EDITOR
//        if (AssetBundleConfig.IsEditorMode)
//        {
//            scriptPath = Path.Combine(Application.dataPath, luaScriptsFolder);
//            scriptPath = Path.Combine(scriptPath, filepath);
//            //Logger.Log("Load lua script : " + scriptPath);
//            return GameUtility.SafeReadAllBytes(scriptPath);
//        }
//#endif
//    }
}