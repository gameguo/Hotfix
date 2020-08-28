using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class HotfixEditor
{
    [MenuItem("Hotfix/Hotfix Inject In Editor")]
    public static void HotfixInject()
    {
        HotfixInject("./Library/ScriptAssemblies");
    }
    public static void HotfixInject(string assemblyDir)
    {
        if (Application.isPlaying)
        {
            return;
        }

        if (EditorApplication.isCompiling)
        {
            UnityEngine.Debug.LogError("You can't inject before the compilation is done");
            return;
        }
#if UNITY_EDITOR_OSX
        var mono_path = Path.Combine(Path.GetDirectoryName(typeof(UnityEngine.Debug).Module.FullyQualifiedName),
            "../MonoBleedingEdge/bin/mono");
        if (!File.Exists(mono_path))
        {
            mono_path = Path.Combine(Path.GetDirectoryName(typeof(UnityEngine.Debug).Module.FullyQualifiedName),
                "../../MonoBleedingEdge/bin/mono");
        }
        if (!File.Exists(mono_path))
        {
            UnityEngine.Debug.LogError("can not find mono!");
        }
#elif UNITY_EDITOR_WIN
        var mono_path = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),
            "Data/MonoBleedingEdge/bin/mono.exe");
#endif

        var assembly_csharp_path = Path.Combine(assemblyDir, "Assembly-CSharp.dll");
    }
}