using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNashENGINE.Share.Datos
{
    public class RequestData<T>
    {
        public bool IsSuccess {  get; set; }

        public string? StatusMessage {  get; set; }

        public T? Data { get; set; }
    }
}
