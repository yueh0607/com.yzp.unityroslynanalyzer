using System.IO;
using System.Linq;
using UnityEditor;

public class ExportPackage
{
    [MenuItem("BuildPackage", menuItem ="Tools/Export Package")]
    public static void ExportSelectedPackage()
    {
        string workspacePath = "Assets/Workspace";
        string[] assetPaths = Directory.GetDirectories(workspacePath, "*", SearchOption.AllDirectories)
                                        .Select(dir => dir.Replace("\\", "/")) // 转换路径格式
                                        .Concat(Directory.GetFiles(workspacePath, "*.*", SearchOption.AllDirectories)
                                                         .Select(file => file.Replace("\\", "/")))
                                        .ToArray();

  
        string packagePath = "Assets/Releases/CodeAnalysis.unitypackage"; // 自定义包名
        Directory.CreateDirectory( Path.GetDirectoryName(packagePath));
        AssetDatabase.ExportPackage(assetPaths, packagePath, ExportPackageOptions.IncludeDependencies);
        AssetDatabase.ImportAsset(packagePath);
    }
}
