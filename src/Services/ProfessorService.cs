using System;
using System.Collections.Generic;
using PlataformaCurso.Models;

public class ProfessorService : MateriaService
{
    public ProfessorService(MateriaService materiaService)
    {
        materiaService.MateriaCriada += MateriaCriadaEventHandler;
    }
    private List<Professor> ListaDeProfessores = new List<Professor>();


    public void IniciarCadastro()
    {
        Console.WriteLine("Digite o nome do professor");
        var nome = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido. Cadastro cancelado.");
            return;
        }

        var novoProfessor = CriarNovoProfessor(nome);

        Console.WriteLine("Digite as áreas de atuação separadas por vírgula (SÓ APERTE ENTER QUANDO ACABAR)");
        var conhecimentos = Console.ReadLine();

        novoProfessor.Conhecimentos = ObterListaDeConhecimentos(conhecimentos);
        ListaDeProfessores.Add(novoProfessor);

        Console.WriteLine("Professor cadastrado com sucesso!");
        Console.WriteLine("");//vazio para espaço


        var materiaService = new MateriaService();
        materiaService.MateriaCriada += MateriaCriadaEventHandler;
    }

    private Professor CriarNovoProfessor(string nome)
    {
        return new Professor(nome);
    }

    private List<string> ObterListaDeConhecimentos(string conhecimentos)
    {
        return conhecimentos?.Split(",").ToList() ?? new List<string>();
    }

    public List<Professor> ObterTodos()
    {
        return ListaDeProfessores;
    }

    public void MateriaCriadaEventHandler(object sender, string materiaNome)
    {
        Console.WriteLine($"Nova matéria de {materiaNome} criada em ProfessorService");
    }
}
