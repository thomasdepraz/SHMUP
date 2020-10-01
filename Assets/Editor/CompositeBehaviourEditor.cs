﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositBehaviour))]
public class CompositeBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CompositBehaviour cb = (CompositBehaviour)target;
        
        if (cb.behaviors == null || cb.behaviors.Length == 0)
        {
            EditorGUILayout.HelpBox("No Behaviors in array.", MessageType.Warning);
        }

        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.EndHorizontal();

            EditorGUI.BeginChangeCheck();

            for (int i = 0; i < cb.behaviors.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                cb.behaviors[i] = (FlockBehaviour)EditorGUILayout.ObjectField(cb.behaviors[i], typeof(FlockBehaviour), false, GUILayout.MinWidth(60f));
                cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(cb);
            }

        }

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Behavior"))
        {
            AddBehavior(cb);
            EditorUtility.SetDirty(cb);
        }

        EditorGUILayout.EndHorizontal();



        if (cb.behaviors != null && cb.behaviors.Length > 0)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Remove Behavior"))
            {
                RemoveBehavior(cb);
                EditorUtility.SetDirty(cb);
            }
            EditorGUILayout.EndHorizontal();
        }
    }



    private void AddBehavior(CompositBehaviour cb)
    {
        int oldCount = (cb.behaviors != null) ? cb.behaviors.Length : 0;
        FlockBehaviour[] newBehaviors = new FlockBehaviour[oldCount + 1];
        float[] newWeights = new float[oldCount + 1];
       
        for (int i = 0; i < oldCount; i++)
        {
            newBehaviors[i] = cb.behaviors[i];
            newWeights[i] = cb.weights[i];
        }

        newWeights[oldCount] = 1f;
        cb.behaviors = newBehaviors;
        cb.weights = newWeights;
    }

    private void RemoveBehavior(CompositBehaviour cb)
    {
        int oldCount = cb.behaviors.Length;
       
        if (oldCount == 1)
        {
            cb.behaviors = null;
            cb.weights = null;
            return;
        }

        else
        {
            FlockBehaviour[] newBehaviors = new FlockBehaviour[oldCount - 1];
            float[] newWeights = new float[oldCount - 1];

            for (int i = 0; i < oldCount - 1; i++)
            {
                
                newBehaviors[i] = cb.behaviors[i];    
                newWeights[i] = cb.weights[i];
            }
            cb.behaviors = newBehaviors;
            cb.weights = newWeights;

        }

    }

}
