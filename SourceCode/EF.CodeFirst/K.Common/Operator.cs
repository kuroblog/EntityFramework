
namespace K.Common
{
    using System;
    using System.Collections.Generic;

    public class Operator
    {
        public static void HandleProcess(Action action)
        {
            if (action == null)
                return;

            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                var errors = new List<Tuple<int, string, string>>();
                var tmp = ex;
                var index = 0;
                do
                {
                    errors.Add(Tuple.Create(++index, ex.GetType().Name, ex.Message.Replace(Environment.NewLine, string.Empty)));
                    ex = tmp.InnerException == null ? null : ex.InnerException;
                } while (ex != null);

                if (errors.Count > 0)
                {
                    Console.WriteLine($"执行完成，发生以下错误：{Environment.NewLine}");
                    errors.ForEach(p => Console.WriteLine($"{p.Item1.ToString().PadLeft(2, '0')}）异常类型:{p.Item2};异常信息:{p.Item3}{Environment.NewLine}"));
                }
            }
        }
    }
}
