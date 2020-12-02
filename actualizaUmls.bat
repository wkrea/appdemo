
DEL /S /Q ".\BackEnd\*.puml"
for /R . %%I in (*.cs) do @"../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe" "%%I"

@REM ###################################################################################################
@REM Esta era la version manual
@REM ###################################################################################################
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Api/Controllers/PostItemController.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Api/Controllers/UserController.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Compartido/EntidadBase.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Dominio/Errors/ErrorBase.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Dominio/Comentario.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Dominio/PostItem.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Dominio/TextoItem.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Dominio/Usuario.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/DTO/DtoMapper.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/DTO/Command/ComentarioDTO.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/DTO/Command/PostItemDTO.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Interfaces/IComentarioRepositorio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Interfaces/IPostItemRepositorio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Interfaces/IUsuarioRepositorio.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/Validadores/PostValidador.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/Validadores/ComentarioValidador.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/Validadores/IValidadorServicio.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/IPostItemServicio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/IUsuarioServicio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/PostItemServicio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Core/Servicios/UsuariosServicio.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Infra/Contexto/AppDBContext.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Infra/Contexto/AppDBSeedData.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Infra/Repositorios/ComentarioRepositorio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Infra/Repositorios/PostItemRepositorio.cs
@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Infra/Repositorios/UsuarioRepositorio.cs

@REM START /wait ../PlantUml-C#/PlantUml-gen/PlantUmlClassDiagramGenerator.exe ./BackEnd/App.Test/Servicios/PostItemServicioTests.cs