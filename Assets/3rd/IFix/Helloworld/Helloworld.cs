/*
 * Tencent is pleased to support the open source community by making InjectFix available.
 * Copyright (C) 2019 THL A29 Limited, a Tencent company.  All rights reserved.
 * InjectFix is licensed under the MIT License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
 * This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
 */

using UnityEngine;
using IFix.Core;
using System.IO;
using System.Diagnostics;

namespace IFix.Test
{
    // 跑不同仔细看文档Doc/example.md
    public class Helloworld : MonoBehaviour
    {
        public TextAsset patch;
        void Start()
        {
            VirtualMachine.Info = (s) => UnityEngine.Debug.Log(s);
            if (patch == null)
            {
                patch = Resources.Load<TextAsset>("Assembly-CSharp.patch");
            }
            if (patch != null)
            {
                UnityEngine.Debug.Log("loading Assembly-CSharp.patch ...");
                var sw = Stopwatch.StartNew();
                PatchManager.Load(new MemoryStream(patch.bytes));
                UnityEngine.Debug.Log("patch Assembly-CSharp.patch, using " + sw.ElapsedMilliseconds + " ms");
            }
            test();
        }

        [IFix.Patch]
        void test()
        {
            var calc = new IFix.Test.Calculator();
            //test calc.Add
            UnityEngine.Debug.Log("10 + 9 = " + calc.Add(10, 9));
            //test calc.Sub
            UnityEngine.Debug.Log("10 - 2 = " + calc.Sub(10, 2));

            //test for InjectFix/Fix(Android) InjectFix/Fix(IOS) Menu for unity 2018.3 or newer
#if UNITY_2018_3_OR_NEWER
#if UNITY_IOS
        UnityEngine.Debug.Log("UNITY_IOS");
#endif
#if UNITY_EDITOR
            UnityEngine.Debug.Log("UNITY_EDITOR");
#endif
#if UNITY_ANDROID
        UnityEngine.Debug.Log("UNITY_ANDROID");
#endif
#endif
        }
    }
}
