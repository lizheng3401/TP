using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildPipeLine
{
	[MenuItem("Build/PC")]
	public static void BuildPC()
	{
		var outdir = Path.Combine(Path.Combine(System.Environment.CurrentDirectory, "Build"), "PC");
		var outputPath = Path.Combine(outdir, Application.productName + ".exe");
		Debug.Log("outputdir: " + outdir);
		Debug.Log("outputPath: " + outputPath);
		//文件夹处理
		if (!Directory.Exists(outdir)) Directory.CreateDirectory(outdir);
		if (File.Exists(outputPath)) File.Delete(outputPath);

		if(EditorUserBuildSettings.activeBuildTarget != BuildTarget.StandaloneWindows)
		{
			EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows);
		}
		//开始项目一键打包

		string[] scenes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
		foreach (var scene in scenes)
		{
			Debug.Log(scene);
		}
		UnityEditor.BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.StandaloneWindows, BuildOptions.None);
		if (File.Exists(outputPath))
		{
			Debug.Log("Build Success :" + outputPath);
		}
		else
		{
			Debug.LogException(new Exception("Build Fail! Please Check the log! "));
		}
	}
}
