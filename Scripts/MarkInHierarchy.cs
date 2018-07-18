using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[InitializeOnLoad]
public class EasytouchHierachyCallBack
{
	// Use this for initialization
   // 层级窗口项回调
    private static readonly EditorApplication.HierarchyWindowItemCallback hiearchyItemCallback;

    private static Texture2D hierarchyIcon;
    private static Texture2D HierarchyIcon {
        get {
            if (EasytouchHierachyCallBack.hierarchyIcon==null){
                EasytouchHierachyCallBack.hierarchyIcon = (Texture2D)Resources.Load( "EasyTouch_Icon");
            }
            return EasytouchHierachyCallBack.hierarchyIcon;
        }
    }   

    private static Texture2D hierarchyEventIcon;
    private static Texture2D HierarchyEventIcon {
        get {
            if (EasytouchHierachyCallBack.hierarchyEventIcon==null){
                EasytouchHierachyCallBack.hierarchyEventIcon = (Texture2D)Resources.Load( "HandPointer");
            }
            return EasytouchHierachyCallBack.hierarchyEventIcon;
        }
    }

    /// <summary>
    /// 静态构造
    /// </summary>
    static EasytouchHierachyCallBack()
    {
        EasytouchHierachyCallBack.hiearchyItemCallback = new EditorApplication.HierarchyWindowItemCallback(EasytouchHierachyCallBack.DrawHierarchyIcon);
        EditorApplication.hierarchyWindowItemOnGUI = (EditorApplication.HierarchyWindowItemCallback)Delegate.Combine(
            EditorApplication.hierarchyWindowItemOnGUI, 
            EasytouchHierachyCallBack.hiearchyItemCallback);

        //EditorApplication.update += Update;
    }

    // 绘制icon方法
    private static void DrawHierarchyIcon(int instanceID, Rect selectionRect)
    {
        //GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        // 设置icon的位置与尺寸（Hierarchy窗口的左上角是起点）
        Rect rect = new Rect(selectionRect.x + selectionRect.width - 16f, selectionRect.y, 16f, 16f);
        // 画icon
        GUI.DrawTexture(rect, EasytouchHierachyCallBack.hierarchyEventIcon);
    }

    private static void Update()
    {
        Debug.Log("1");
    }
}
