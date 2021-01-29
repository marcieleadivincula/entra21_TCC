using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using Domain;



namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                /*
                PaisDAL paisdal = new PaisDAL();
                EstadoDAL estadodal = new EstadoDAL();
                CidadeDAL cidadedal = new CidadeDAL();
                BairroDAL bairrodal = new BairroDAL();
                LogradouroDAL logradourodal = new LogradouroDAL();
                EnderecoDAL enderecodal = new EnderecoDAL();
                //FoneTipoDAL foneTipodal = new FoneTipoDAL();
                FuncaoDAL funcaodal = new FuncaoDAL();
                ClinicaDAL clinicadal = new ClinicaDAL();
                ColaboradorDAL colaboradordal = new ColaboradorDAL();
                PacienteDAL pacientedal = new PacienteDAL();
                //ContatoDAL contatodal = new ContatoDAL();
                AtendimentoDAL atendimentodal = new AtendimentoDAL();
                ProcedimentoDAL procedimentodal = new ProcedimentoDAL();
                TipoProcedimentoDAL tipoProcedimentodal = new TipoProcedimentoDAL();

                //Pais pais = new Pais(0);
                //Estado estado = new Estado(0);
                //Cidade cidade = new Cidade(0);
                //Bairro bairro = new Bairro(0);
                //Logradouro logradouro = new Logradouro(0);
                //Endereco endereco = new Endereco(0);
                //FoneTipo foneTipo = new FoneTipo(0);
                //Funcao funcao = new Funcao(0);
                //Clinica clinica = new Clinica(0);
                Colaborador colaborador = new Colaborador();
                Paciente paciente = new Paciente();
                //Contato colaboradorContato = new Contato(0);
                //Contato clienteContato = new Contato(0);
                Atendimento atendimento = new Atendimento();
                //Procedimento procedimento = new Procedimento(0);
                //TipoProcedimento tipoProcedimento = new TipoProcedimento(0);

                try
                {
                    //paisdal.insert(new Pais(0, "Pais Teste"));
                    //pais = paisdal.getLastRegister();

                    //estadodal.insert(new Estado(0, "Estado Teste", pais));
                    //estado = estadodal.getLastRegister();

                    //cidadedal.insert(new Cidade(0, "Cidade Teste", estado));
                    //cidade = cidadedal.getLastRegister();

                    //bairrodal.insert(new Bairro(0, "Bairro Teste", cidade));
                    //bairro = bairrodal.getLastRegister();

                    //logradourodal.insert(new Logradouro(0, "Logradouro Teste", bairro));
                    //logradouro = logradourodal.getLastRegister();

                    //enderecodal.insert(new Endereco(0, logradouro, 2, "123123"));
                    //endereco = enderecodal.getLastRegister();

                    //foneTipodal.insert(new FoneTipo(0, "Tipo Fone Teste"));
                    //foneTipo = foneTipodal.getLastRegister();

                    //funcaodal.insert(new Funcao(0, "Funcao Teste", 5000, 100));
                    //funcao = funcaodal.getLastRegister();

                    //clinicadal.insert(new Clinica(0, "Clinica Teste", LocalDate.now(), endereco));
                    //clinica = clinicadal.getLastRegister();

                    //colaboradordal.insert(new Colaborador(0, "Diuari", "1231231", "SC", LocalDate.now(), endereco, funcao, clinica, true, true));
                    //colaborador = colaboradordal.getLastRegister();

                    //pacientedal.insert(new Paciente(0, "Paciente", "Teste", "1231231", "1231231", LocalDate.now(), "OBS Teste", endereco));
                    //paciente = pacientedal.getLastRegister();

                    //tipoProcedimentodal.insert(new TipoProcedimento(0, "Tipo Procedimento Teste", 100));
                    //tipoProcedimento = tipoProcedimentodal.getLastRegister();

                    //procedimentodal.insert(new Procedimento(0, "Procedimento Teste", tipoProcedimento, "Descricao Procedimento Teste"));
                    //procedimento = procedimentodal.getLastRegister();

                    atendimentodal.insert(new Atendimento(0, paciente, colaborador));
                    atendimento = atendimentodal.getLastRegister();

                    //contatodal.insert(new Contato(0, "33362222", foneTipo, "ContatoColaborador@teste.com", colaborador));
                    //colaboradorContato = contatodal.getLastRegister();
                    //contatodal.insert(new Contato(0, "33361111", foneTipo, "ContatoPaciente@teste.com", paciente));
                    //clienteContato = contatodal.getLastRegister();
                }
                finally
                {
                    //contatodal.delete(colaboradorContato);
                    //contatodal.delete(clienteContato);
                    //atendimentodal.delete(atendimento);
                    //procedimentodal.delete(procedimento);
                    //tipoProcedimentodal.delete(tipoProcedimento);
                    //pacientedal.delete(paciente);
                    //colaboradordal.delete(colaborador);
                    //clinicadal.delete(clinica);
                    //funcaodal.delete(funcao);
                    //foneTipodal.delete(foneTipo);
                    //enderecodal.delete(endereco);
                    //logradourodal.delete(logradouro);
                    //bairrodal.delete(bairro);
                    //cidadedal.delete(cidade);
                    //estadodal.delete(estado);
                    //paisdal.delete(pais);
                    */
                }

            AtendimentoDAL dal = new AtendimentoDAL();

            Atendimento atendimentoTest = new Atendimento();

            List<Atendimento> atendimentos = new List<Atendimento>();

            
            atendimentos = dal.SelecionaTodos();

            foreach (var item in atendimentos)
            {
                Console.WriteLine();
                Console.WriteLine(item.Id);
                Console.WriteLine();
            }
           

            //atendimentoTest = dal.GetAtendimentoById(0);

            Console.WriteLine(atendimentoTest.Id);



            
        }
    }
}
