// Copyright (c) Rotorz Limited. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root.

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Rotorz.Games.UnityEditorExtensions
{
    /// <summary>
    /// Singleton utility functions for custom Unity editor extensions.
    /// </summary>
    public static class EditorSingletonUtility
    {
        private static readonly Dictionary<Type, IEditorSingleton> s_Instances = new Dictionary<Type, IEditorSingleton>();


        /// <summary>
        /// Gets the one-and-only instance for a custom <see cref="IEditorSingleton"/>
        /// implementation.
        /// </summary>
        /// <typeparam name="T">Implementation type.</typeparam>
        /// <returns>
        /// The one-and-only shared instance of the specified implementation type.
        /// </returns>
        public static T GetAssetInstance<T>()
            where T : EditorSingletonScriptableObject
        {
            IEditorSingleton instance;
            if (!s_Instances.TryGetValue(typeof(T), out instance)) {
                string assetGuid = AssetDatabase.FindAssets("t:" + typeof(T).FullName).FirstOrDefault();
                if (!string.IsNullOrEmpty(assetGuid)) {
                    string assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    instance = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                    s_Instances[typeof(T)] = instance;
                }
            }

            if (!instance.HasInitialized) {
                instance.Initialize();
            }

            return (T)instance;
        }
    }
}
