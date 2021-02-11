using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicalLayer
{
    public class FoneTipoBLL
    {
        FoneTipoDAL dal = new FoneTipoDAL();

        //Incluir um registro
        public string Insert(FoneTipo foneTipo)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(foneTipo.Tipo))
            {
                erros.AppendLine("O tipo de telefone deve ser informada.");
            }

            if (foneTipo.Tipo.Length > 60)
            {
                erros.AppendLine("O tipo de telefone não pode conter mais que 60 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Insert(foneTipo);
            return respostaDB;
        }

        //Obter todos os registros
        public List<FoneTipo> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(FoneTipo foneTipo)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(foneTipo.Tipo))
            {
                erros.AppendLine("O tipo de telefone deve ser informada.");
            }

            if (foneTipo.Tipo.Length > 60)
            {
                erros.AppendLine("O tipo de telefone não pode conter mais que 60 caracteres.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Update(foneTipo);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(FoneTipo foneTipo)
        {
            string respostaDB = dal.Delete(foneTipo);
            return respostaDB;
        }

        //Obter um registro
        public FoneTipo GetById(FoneTipo foneTipo)
        {
            StringBuilder erros = new StringBuilder();

            if (foneTipo.Id == 0 || foneTipo.Id < 0)
            {
                erros.AppendLine("O ID do tipo de telefone deve ser informado.");
            }

            return dal.GetById(foneTipo.Id);
        }

        //Obter último registro
        public FoneTipo GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
