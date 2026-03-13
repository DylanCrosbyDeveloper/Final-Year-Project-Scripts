//using System;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using NUnit.Framework.Interfaces;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

//namespace ItemsTutorial.Systems
//{
//    [CreateAssetMenu(fileName = "CrosshairDatabase", menuName = "Inventory/Items Database")]
//    public class ItemsDatabase : ScriptableObject
//    {
//        [SerializeField]
//        List<CHItemData> items = new List<CHItemData>();
        
//        public IReadOnlyList<CHItemData> Items => items;

//        private static ItemsDatabase instance;
//        void Update()
//        {
//            Debug.Log("WORKING");
//        }

//        public static ItemsDatabase Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    string typeName = nameof(ItemsDatabase);
                   
//                    instance = Resources.Load<ItemsDatabase>(typeName);
//                    if (instance == null)
//                    {

//#if UNITY_EDITOR
                       
//                        instance = CreateInstance<ItemsDatabase>();
                     
//                        string resourcesFolder = "Assets/Resources";
//                        if (!AssetDatabase.IsValidFolder(resourcesFolder))
//                        {
//                            AssetDatabase.CreateFolder("Assets", "Resources");
//                        }

                        
//                        string assetPath = $"{resourcesFolder}/{typeName}.asset";
//                        AssetDatabase.CreateAsset(instance, assetPath);
//                        AssetDatabase.SaveAssets();
//                        AssetDatabase.Refresh();
//#else
//                    Debug.LogError("ItemsData asset not found in Resources and cannot be created at runtime.");
//#endif
//                    }
//                }
//                return instance;
//            }
//        }

//        public CHItemData GetItem(string id)
//        {
//            return items.FirstOrDefault(item => item.ID == id);
//        }

//        private void OnValidate()
//        {
//            bool changed = false;

//            HashSet<string> idSet = new();
//            foreach (CHItemData item in items)
//            {
//                if (String.IsNullOrEmpty(item.ID) || idSet.Contains(item.ID))
//                {
//                    item.GenerateNewID();
//                    changed = true;
//                }

//                idSet.Add(item.ID);
//            }

//#if UNITY_EDITOR
//            if (changed)
//            {
//                EditorUtility.SetDirty(this);
//            }
//#endif
//        }
//    }

   

//}