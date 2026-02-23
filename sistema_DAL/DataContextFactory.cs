using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_DAL
{
    public class DataContextFactory
    {
        private static sistemaDataContext dataContext;
        public static sistemaDataContext DataContext
        {
            get
            {
                if (dataContext == null)//Verficar exite conexão
                    dataContext = new sistemaDataContext();//Criar nova conexão
                return dataContext; //retorna a conexão
            }
        }
    }
}
