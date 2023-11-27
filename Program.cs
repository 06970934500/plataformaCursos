Console.WriteLine("Bem Vindo a Plataforma Online de Cursos");

 MateriaService materiaService = new MateriaService();


var professorService = new ProfessorService(materiaService);
var coordenadorService = new CoordenadorService(materiaService);
var materiaService1 = new MateriaService();
var extensaoService = new ExtensaoService();


Console.WriteLine("Cadastro Professor (2 professores)");
professorService.IniciarCadastro();
professorService.IniciarCadastro();

Console.WriteLine("Cadastro Coordenador (2 coordenadores)");
coordenadorService.IniciarCadastro();
coordenadorService.IniciarCadastro();


Console.WriteLine("Cadastro Materia (2 materias)");
materiaService.CriarMateria(professorService.ObterTodos());
materiaService.CriarMateria(professorService.ObterTodos());

Console.WriteLine("Cadastro Extensao (2 extensoes)");
extensaoService.CriarExtensao(professorService.ObterTodos());
extensaoService.CriarExtensao(professorService.ObterTodos());
