using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApp
{
    public class StackItem
    {
        public String Module;         // модуль, в котором находится данная функция
        public String ClassName;      // имя класса, в котором находится данная функция
        public String MethodName;     // имя данной функции, из которой будет вызвана следующая функция
        public String Params;         // сюда положим текстовый список параметров данной функции

        public String FileName;       // файл, в котором находится данная функция
        public Int32 Line;           // строка, в которой вызвана следующая функция


        public override string ToString()
        {
            return String.Format("{0}.{1}({2}) {3}", ClassName, MethodName, Params,
                    (FileName != null ? FileName + " (" + Line.ToString() + ")" : ""));
        }
    }
}
