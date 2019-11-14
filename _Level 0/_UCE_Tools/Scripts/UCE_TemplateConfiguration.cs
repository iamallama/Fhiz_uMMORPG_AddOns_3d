// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System;
using UnityEngine;
using System.Linq;

// TemplateConfiguration

[CreateAssetMenu(menuName = "UCE Other/UCE Configuration", fileName = "New UCE Configuration", order = 999)]
public partial class UCE_TemplateConfiguration : ScriptableObject
{

    [Header("Build")]
    public bool isServer = true;
    public bool isClient = true;

    [Header("Scriptable Object Folders")]
    public UCE_ScripableObjectEntry[] scriptableObjects;

    protected const string IS_SERVER = "_SERVER";
    protected const string IS_CLIENT = "_CLIENT";

    static UCE_TemplateConfiguration _instance;

    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    public void OnValidate()
    {
#if UNITY_EDITOR
        if (isServer && !isClient)
        {
            UCE_EditorTools.RemoveScriptingDefine(IS_CLIENT);
            UCE_EditorTools.AddScriptingDefine(IS_SERVER);
        }
        else if (isClient && !isServer)
        {
            UCE_EditorTools.RemoveScriptingDefine(IS_SERVER);
            UCE_EditorTools.AddScriptingDefine(IS_CLIENT);
        }
        else
        {
            UCE_EditorTools.AddScriptingDefine(IS_CLIENT);
            UCE_EditorTools.AddScriptingDefine(IS_SERVER);
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    public static UCE_TemplateConfiguration singleton
    {
        get 
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<UCE_TemplateConfiguration>().FirstOrDefault();
            return _instance;
        }
    }

    // -----------------------------------------------------------------------------------
    // GetEntry
    // -----------------------------------------------------------------------------------
    public UCE_ScripableObjectEntry GetEntry(Type type)
    {
        foreach (UCE_ScripableObjectEntry entry in scriptableObjects)
        {
            if (entry.scriptableObject.GetType() == type)
                return entry;
        }

        return null;
    }

    // -----------------------------------------------------------------------------------
    // GetTemplatePath
    // -----------------------------------------------------------------------------------
    public string GetTemplatePath(Type type)
    {
        foreach (UCE_ScripableObjectEntry entry in scriptableObjects)
        {
            if (entry.scriptableObject.GetType() == type)
                return entry.folderName;
        }

        return "";
    }

    // -----------------------------------------------------------------------------------
    // GetBundlePath
    // -----------------------------------------------------------------------------------
    public string GetBundlePath(Type type)
    {
        foreach (UCE_ScripableObjectEntry entry in scriptableObjects)
        {
            if (entry.scriptableObject.GetType() == type)
                return entry.bundleName;
        }

        return "";
    }

    // -----------------------------------------------------------------------------------
    // GetLoadFromBundle
    // -----------------------------------------------------------------------------------
    public bool GetLoadFromBundle(Type type)
    {
        foreach (UCE_ScripableObjectEntry entry in scriptableObjects)
        {
            if (entry.scriptableObject.GetType() == type)
                return entry.loadFromAssetBundle;
        }

        return false;
    }

    // -----------------------------------------------------------------------------------
}
