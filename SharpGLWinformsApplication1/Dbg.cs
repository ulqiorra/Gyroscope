using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SharpGLWinformsApp
{
    public class Dbg
    {
        // получить коллстек функций для текущего потока в виде строки
        public static String GetStackString()
        {
            StringBuilder hStrBld = new StringBuilder();
            StackItem[] stack = GetStack();
            foreach (StackItem item in stack)
                hStrBld.Append(item.ToString() + Environment.NewLine);
            return hStrBld.ToString();
        }

        // получить коллстек функций для текущего потока
        public static StackItem[] GetStack()
        {
            return GetStack(Thread.CurrentThread);
        }

        // получить коллстек функций для указанного потока
        public static StackItem[] GetStack(Thread targetThread)
        {
            List<StackItem> stackList = new List<StackItem>();
            StackTrace st = new StackTrace(targetThread, true);
            for (Int32 i = 0; i < st.FrameCount; ++i)
            {
                StackItem item = GetStackItem(st.GetFrame(i));
                if (item != null)
                    stackList.Add(item);
            }
            return stackList.ToArray();
        }

        // сформировать данные о фрейме стека
        private static StackItem GetStackItem(StackFrame sf)
        {
                if( sf == null )
                        return null;
                MethodBase method = sf.GetMethod();
                if( method == null || method.ReflectedType == null )
                        return null;
                
                // получить информацию о данном фрейме стека
                StackItem item  = new StackItem();
                item.Module     = method.Module.Assembly.FullName;
                item.ClassName  = method.ReflectedType.Name;
                item.MethodName = method.Name;
                item.FileName   = sf.GetFileName();
                item.Line       = sf.GetFileLineNumber();

                // получить параметры данного метода
                StringBuilder parameters = new StringBuilder();
                ParameterInfo[] paramsInfo = method.GetParameters();
                for( Int32 i = 0; i < paramsInfo.Length; i++ )
                {
                        ParameterInfo currParam = paramsInfo[ i ];
                        parameters.Append( currParam.ParameterType.Name );
                        parameters.Append( " " );
                        parameters.Append( currParam.Name );
                        if( i != paramsInfo.Length - 1 )
                                parameters.Append( ", " );
                }

                item.Params = parameters.ToString();

                return item;
        }
    }
}
