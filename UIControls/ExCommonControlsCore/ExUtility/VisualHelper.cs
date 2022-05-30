using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace ExCommonControlsCore.ExUtility
{
    public class VisualHelper
    {
        /// <summary>
        /// 查找第一个T类型的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject currentObj = VisualTreeHelper.GetChild(obj, i);
                if (currentObj != null && currentObj is T)
                {
                    return (T)currentObj;
                }
                else
                {
                    if (currentObj != null)
                    {
                        T childofchild = FindVisualChild<T>(currentObj);
                        if (childofchild != null) return childofchild;
                    }

                }
            }
            return default(T);
        }

        /// <summary>
        /// 查找T类型的子元素集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject currentObj = VisualTreeHelper.GetChild(obj, i);
                    if (currentObj != null && currentObj is T)
                    {
                        yield return (T)currentObj;
                    }
                    if (currentObj != null)
                    {
                        foreach (T childOfChild in FindVisualChildren<T>(currentObj))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }




        public static T FindParent<T>(DependencyObject i_dp) where T : DependencyObject
        {
            DependencyObject dobj = (DependencyObject)VisualTreeHelper.GetParent(i_dp);
            if (dobj != null)
            {
                if (dobj is T)
                {
                    return (T)dobj;
                }
                else
                {
                    dobj = FindParent<T>(dobj);
                    if (dobj != null && dobj is T)
                    {
                        return (T)dobj;
                    }
                }
            }
            return null;
        }

        public static T FindParent<T>(DependencyObject i_dp, string elementName) where T : DependencyObject
        {
            DependencyObject dobj = (DependencyObject)VisualTreeHelper.GetParent(i_dp);
            if (dobj != null)
            {
                if (dobj is T && ((System.Windows.FrameworkElement)(dobj)).Name.Equals(elementName))
                {
                    return (T)dobj;
                }
                else
                {
                    dobj = FindParent<T>(dobj);
                    if (dobj != null && dobj is T)
                    {
                        return (T)dobj;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 查找指定名称的元素
        /// </summary>
        /// <typeparam name="childItem">元素类型</typeparam>
        /// <param name="obj"></param>
        /// <param name="elementName">元素名称，及xaml中的Name</param>
        /// <returns></returns>
        public static childItem FindVisualElement<childItem>(DependencyObject obj, string elementName) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem && ((System.Windows.FrameworkElement)(child)).Name.Equals(elementName))
                    return (childItem)child;
                else
                {
                    if (child != null)
                    {
                        IEnumerator j = FindVisualChildren<childItem>(child).GetEnumerator();
                        while (j.MoveNext())
                        {
                            childItem childOfChild = (childItem)j.Current;
                            var c = childOfChild as FrameworkElement;
                            if (c != null)
                            {
                                if (childOfChild != null && !c.Name.Equals(elementName))
                                {
                                    FindVisualElement<childItem>(childOfChild, elementName);
                                }
                                else
                                {
                                    return childOfChild;
                                }
                            }


                        }
                    }

                }
            }
            return null;
        }

        /// <summary>
        /// 命中测试。根据当前选中元素，查找视觉树父节点与子节点，看是否存在指定类型的元素
        /// </summary>
        /// <typeparam name="T">想命中的元素类型</typeparam>
        /// <param name="dp">当前选中元素</param>
        /// <returns>true：命中成功</returns>
        public static bool HitTest<T>(DependencyObject dp) where T : DependencyObject
        {
            return FindParent<T>(dp) != null || FindVisualChild<T>(dp) != null;
        }

    }
}
