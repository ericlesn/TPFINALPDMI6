using System;
using System.Collections.Generic;
using System.Text;

namespace TpFinal
{
    using SQLite;
    namespace XamarinSQLite
    {
        public class Person
        {
            [PrimaryKey, AutoIncrement]
            public int PersonID { get; set; }
            public string NomeProduto { get; set; }
            public string Peso { get; set; }
            public string NomeProdutor { get; set; }
            public string Email { get; set; }
            public string NCM { get; set; }
        }
    }
}
