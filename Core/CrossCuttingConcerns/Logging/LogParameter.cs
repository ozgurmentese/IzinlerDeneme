using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    /// <summary>
    /// Kim nerede neyi hangi parametrelerle çağırdı bilgisi
    /// methodun paremetresi tipi ve değerini tutuyor
    /// </summary>
    public class LogParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
}
