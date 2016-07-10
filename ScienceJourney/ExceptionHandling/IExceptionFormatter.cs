using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScienceJourney.ExceptionHandling
{
    //yakalanan exception handle edilirkin çıktı soyutlamak adına bir interface yazılır. Çıkan exception formatından
    // soyutlamakiçin yeni sınıf yazılmak istendiğinde bu interfaceden türetilir
    public interface IExceptionFormatter
    {
        string FormatException(MethodBase methodBase, string errorDesc, System.Exception ex, ExceptionTypes exType);

        string FormatExceptionThrowCatch(MethodBase methodBase, string errorDesc, System.Exception ex, ExceptionTypes exType);
    }
}
