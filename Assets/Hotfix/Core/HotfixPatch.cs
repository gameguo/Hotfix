using System;
using UnityEngine;

namespace Hotfix
{
    public class HotfixPatch
    {
        public static bool HasPatch(string luaFile, string luaFunc)
        {
            //Debug.Log(luaFile + " " + luaFunc);
            // TODO 此处写你的lua函数存在判断, 建议你把判断结果缓存起来
            //return false;
            return true;
        }

        public static object CallPatch(string luaFile, string luaFunc, params object[] args)
        {
            Debug.Log(string.Format("Patch: {0}:{1}", luaFile, luaFunc));
            // TODO 此处写你的lua函数调用, 并传入参数.
            //        return Lua.DoFile(luaFile).Call(luaFunc, args);
            return null;
        }
    }
    /// <summary> 标记 类/方法 为可修复 </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HotfixAttribute : Attribute { }
    /// <summary> 忽略修复方法 </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class HotfixIgnoreAttribute : Attribute { }
}