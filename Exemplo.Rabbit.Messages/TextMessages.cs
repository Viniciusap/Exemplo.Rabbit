using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;

namespace Exemplo.Rabbit.Messages
{
    [Queue("Teste")]
    public class TextMessages
    {
        public TextMessages(int id, string mensagem, long telefone)
        {
            Id = id;
            Mensagem = mensagem;
            this.telefone = telefone;
        }

        public int Id { get; set; }
        public string Mensagem { get; set; }
        public long telefone { get; set; }

    }
}
