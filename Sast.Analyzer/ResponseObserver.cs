using AustinHarris.JsonRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sast.Analyzer
{
    public class ResponseObserver : IObserver<JsonResponse<int>>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(JsonResponse<int> value)
        {
            Console.WriteLine(value);
        }
    }
}
