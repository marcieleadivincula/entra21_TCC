using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TipoEmbalagem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public TipoEmbalagem(int id, string descricao)
        {
            Id= id;
            Descricao = descricao;
        }
        public TipoEmbalagem()
        {

        }
    }
}
