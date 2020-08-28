using UnityEngine;
using Hotfix;

[Hotfix]
public class PatchTest : MonoBehaviour
{

    [HotfixIgnore]
    private void Start()
    {

        PatchTest1();
        PatchTest2();
        PatchTest3(1, 2, 3);
        PatchTest4();
    }
    public void PatchTest1()
    {
        Debug.Log("C# - PatchTest1");
    }
    private void PatchTest2()
    {
        Debug.Log("C# - PatchTest2");
    }
    private void PatchTest3(int a, float b, double c)
    {
        Debug.Log("C# - PatchTest3: " + a + " " + b + " " + c);
    }
    [HotfixIgnore]
    private void PatchTest4()
    {
        Debug.Log("C# - PatchTest4");
    }
}