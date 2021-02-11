using System;
using DataAccessLayer;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();

        //Incluir um registro
        public string Insert(Usuario usuario)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(usuario.Login))
            {
                erros.AppendLine("O Login deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(usuario.Login))
            {
                if (usuario.Login.Length > 60)
                {
                    erros.AppendLine("O Login não pode conter mais que 60 caracteres.");
                }
            }
         
            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                erros.AppendLine("A Senha deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(usuario.Senha))
            {
                if (usuario.Senha.Length > 250)
                {
                    erros.AppendLine("A Senha Não pode conter mais que 250 caracteres.");
                }
            }
   
            if (usuario.Colaborador.Id == 0 || usuario.Colaborador.Id < 0)
            {
                erros.AppendLine("A ID do colaborador deve ser informado.");
            }


            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Insert(usuario);
            return respostaDB;
        }

        //Obter todos os registros
        public List<Usuario> GetAll()
        {
            return dal.GetAll();
        }

        //Atualizar um registro existente
        public string Update(Usuario usuario)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrWhiteSpace(usuario.Login))
            {
                erros.AppendLine("O Login deve ser informado.");
            }

            if (!string.IsNullOrWhiteSpace(usuario.Login))
            {
                if (usuario.Login.Length > 60)
                {
                    erros.AppendLine("O Login não pode conter mais que 60 caracteres.");
                }
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                erros.AppendLine("A Senha deve ser informada.");
            }

            if (!string.IsNullOrWhiteSpace(usuario.Senha))
            {
                if (usuario.Senha.Length > 250)
                {
                    erros.AppendLine("A Senha Não pode conter mais que 250 caracteres.");
                }
            }

            if (usuario.Colaborador.Id == 0 || usuario.Colaborador.Id < 0)
            {
                erros.AppendLine("A ID do colaborador deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }
            string respostaDB = dal.Update(usuario);
            return respostaDB;
        }

        //Excluir um registro
        public string Delete(Usuario usuario)
        {
            StringBuilder erros = new StringBuilder();

            if (usuario.Id == 0)
            {
                erros.AppendLine("O ID deve ser informado.");
            }

            if (erros.Length != 0)
            {
                return erros.ToString();
            }

            string respostaDB = dal.Delete(usuario);
            return respostaDB;
        }

        //REVER
        public bool Autenticar(string login, string password)
        {
            Usuario user = dal.Autenticar(login, password);

            if (user == null)
            {
                return false;
            }

            Parametros.UsuarioLogado = user;
            return true;
        }

        public Usuario GetByEmail(string email)
        {
            Usuario temp = new Usuario();

            temp = dal.GetInfosByEmail(email);

            return temp;
        }
      
        //Obter um registro
        public Usuario GetById(Usuario usuario)
        {
            StringBuilder erros = new StringBuilder();

            if (usuario.Id == 0 || usuario.Id < 0)
            {
                erros.AppendLine("O ID do usuario deve ser informado.");
            }

            return dal.GetById(usuario.Id);
        }

        //Obter último registro
        public Usuario GetLastRegister()
        {
            return dal.GetLastRegister();
        }
    }
}
