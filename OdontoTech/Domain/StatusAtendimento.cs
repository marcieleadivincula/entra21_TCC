using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StatusAtendimento
    {
        public int Id { get; set; }
        public string StatusDescricao { get; set; }

        public StatusAtendimento(int id, string statusDescricao)
        {
            Id = id;
            StatusDescricao = statusDescricao;
        }

        public StatusAtendimento(int id)
        {
            Id = id;
        }

        public StatusAtendimento()
        {

        }
    }
}
