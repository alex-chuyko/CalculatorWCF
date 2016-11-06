using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICalculator" в коде и файле конфигурации.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int CalculateExpression(string expression);

        [OperationContract]
        void Set(double a);

        [OperationContract]
        void Add(double a);

        [OperationContract]
        void Substract(double a);

        [OperationContract]
        void Multiply(double a);

        [OperationContract]
        void Divide(double a);

        [OperationContract]
        double Result();
    }
}
