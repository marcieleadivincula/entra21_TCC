using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class EnderecoBLL
    {
        EnderecoDAL dal = new EnderecoDAL();

        //Incluir um registro
        public string Insert(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(endereco.Cep))
            {
                erros.AppendLine("O Cep deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(endereco.Cep))
            {
                if (endereco.Cep.Length > 10)
                {
                    erros.AppendLine("O CEP não pode conter mais que 10 caracteres.");
                }
            }

            if (endereco.NumeroCasa == 0 || endereco.NumeroCasa < 0)
            {
                erros.AppendLine("O número do endereço deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(endereco);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Endereco> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(endereco.Cep))
            {
                erros.AppendLine("O Cep deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(endereco.Cep))
            {
                if (endereco.Cep.Length > 10)
                {
                    erros.AppendLine("O CEP não pode conter mais que 10 caracteres.");
                }
            }

            if (endereco.NumeroCasa == 0 || endereco.NumeroCasa < 0)
            {
                erros.AppendLine("O número do endereço deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(endereco);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (endereco.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(endereco);
            return respostaDB;
        }

        //Obter um registro
        public Endereco GetById(Endereco endereco)
        {
            StringBuilder erros = new StringBuilder();

            if (endereco.Id == 0 || endereco.Id < 0)
            {
                erros.AppendLine("O ID do endereco deve ser informado.");
            }

            return dal.GetById(endereco.Id);
        }

        //Obter último registro
        public Endereco getLastRegister()
        {
            return dal.GetLastRegister();
        }

        //Obter registros de determinado logradouro
        public List<Endereco> GetByLogradouro(Logradouro logradouro)
        {
            return dal.GetByLogradouro(logradouro);
        }

        public Endereco EnderecoConstruido(string pais,string estado, string cidade,string bairro,string logradouro,int numeroCasa,string cep)
        {
            LogradouroDAL logradouroDAL = new LogradouroDAL();
            PaisDAL paisDAL = new PaisDAL();
            EstadoDAL estadoDAL = new EstadoDAL();
            BairroDAL bairroDAL = new BairroDAL();
            CidadeDAL cidadeDAL = new CidadeDAL();

            Pais paiss = new Pais(0, pais);

            string a = paisDAL.Insert(paiss);
            if (a.Contains("já"))
            {
                List<Pais> lista = new List<Pais>();
                lista = paisDAL.GetAll();

                foreach (var item in lista)
                {
                    if (item.Nome == pais)
                    {
                        paiss.Id = item.Id;
                        break;
                    }
                }

            }
            else
            {
                paiss = paisDAL.GetLastRegister();

            }

            Estado estadoo = new Estado(0, estado, paiss);



            string b = estadoDAL.Insert(estadoo);
            if (b.Contains("já"))
            {
                List<Estado> lista = new List<Estado>();
                lista = estadoDAL.GetAll();

                foreach (var item in lista)
                {
                    if (item.Nome == estado)
                    {
                        estadoo.Id = item.Id;
                        break;
                    }
                }

            }
            else
            {

                estadoo = estadoDAL.GetLastRegister();

            }


            Cidade cidadee = new Cidade(0, cidade, estadoo);

            string c = cidadeDAL.Insert(cidadee);
            if (c.Contains("já"))
            {
                List<Cidade> lista = new List<Cidade>();
                lista = cidadeDAL.GetAll();

                foreach (var item in lista)
                {
                    if (item.Nome == cidade)
                    {
                        estadoo.Id = item.Id;
                        break;
                    }
                }

            }
            else
            {

                cidadee = cidadeDAL.GetLastRegister();


            }

            Bairro bairoo = new Bairro(0, bairro, cidadee);

            string d = bairroDAL.Insert(bairoo);
            if (d.Contains("já"))
            {
                List<Bairro> lista = new List<Bairro>();
                lista = bairroDAL.GetAll();

                foreach (var item in lista)
                {
                    if (item.Nome == cidade)
                    {
                        estadoo.Id = item.Id;
                        break;
                    }
                }

            }
            else
            {

                bairoo = bairroDAL.GetLastRegister();


            }


            Logradouro logradouroo = new Logradouro(0, logradouro, bairoo);

            string e = logradouroDAL.Insert(logradouroo);
            if (d.Contains("já"))
            {
                List<Logradouro> lista = new List<Logradouro>();
                lista = logradouroDAL.GetAll();

                foreach (var item in lista)
                {
                    if (item.Nome == logradouro)
                    {
                        logradouroo.Id = item.Id;
                        break;
                    }
                }

            }
            else
            {

                logradouroo = logradouroDAL.GetLastRegister();

            }

            Endereco endereco1 = new Endereco(0, logradouroo, numeroCasa, cep);

            EnderecoDAL endereco = new EnderecoDAL();
            endereco.Insert(endereco1);

            endereco1 = endereco.GetLastRegister();


            return endereco1;
        }
    }
}
