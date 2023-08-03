﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows;

namespace MouseSensitivityCalibrator.Helpers;


public static class VisualHelper
{
    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null) yield return (T)Enumerable.Empty<T>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
            if (ithChild == null) continue;
            if (ithChild is T t) yield return t;
            foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
        }
    }
}
