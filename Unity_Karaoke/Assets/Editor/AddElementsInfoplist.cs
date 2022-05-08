#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;
public class AddElementsInfoplist
{
    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath)
    {
        // Info.plist に Privacy - Tacking Usage Description(NSUserTrackingUsageDescription)を追加する（ステップ２）
        string infoPlistPath = buildPath + "/Info.plist";
        PlistDocument infoPlist = new PlistDocument();
        infoPlist.ReadFromFile(infoPlistPath);
        PlistElementDict root = infoPlist.root;
        root.SetString("NSUserTrackingUsageDescription", "許可するとお客様に最適化された広告が表示されます");
        infoPlist.WriteToFile(infoPlistPath);

　　　　　// PBXProjectクラスというのを用いてAppTrackingTransparency.frameworkを追加していきます（ステップ３）
        string pbxProjectPath = PBXProject.GetPBXProjectPath(buildPath);
        PBXProject pbxProject = new PBXProject();
        pbxProject.ReadFromFile(pbxProjectPath);
        string targetGuid = pbxProject.GetUnityFrameworkTargetGuid();
        pbxProject.AddFrameworkToProject(targetGuid, "AppTrackingTransparency.framework", true);
        pbxProject.AddFrameworkToProject(targetGuid, "AdSupport.framework", true);
        pbxProject.WriteToFile(pbxProjectPath);
    }
}
#endif
