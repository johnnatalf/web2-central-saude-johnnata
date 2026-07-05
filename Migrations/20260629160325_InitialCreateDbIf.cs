using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto1_Web2_IF_Johnnata.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDbIf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.CreateTable(
                 name: "AspNetRoles",
                 columns: table => new
                 {
                     Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                     Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                     NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                     ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                 });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetRolesAspNetUsers",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRolesAspNetUsers", x => new { x.RoleId, x.UserId });
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });*/

            migrationBuilder.CreateTable(
                name: "tbAlimento",
                columns: table => new
                {
                    IdAlimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoQuantidade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Carboidrato = table.Column<double>(type: "float", nullable: false),
                    VitaminaA = table.Column<double>(type: "float", nullable: false),
                    VitaminaB = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbAlimen__2406570577A5EC2C", x => x.IdAlimento);
                });

            migrationBuilder.CreateTable(
                name: "tbCategoriaMedicamento",
                columns: table => new
                {
                    IdCategoriaMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InformacaoComplementar = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbCatego__14A80672AD9984E8", x => x.IdCategoriaMedicamento);
                });

            migrationBuilder.CreateTable(
                name: "tbEscalaBristol",
                columns: table => new
                {
                    IdEscalaBristol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Sangue = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbEscala__A6FB417FE5BEBAC8", x => x.IdEscalaBristol);
                });

            migrationBuilder.CreateTable(
                name: "tbExame",
                columns: table => new
                {
                    IdExame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbExame__0C2F360F255CCA14", x => x.IdExame);
                });

            migrationBuilder.CreateTable(
                name: "tbGrupoPatologico",
                columns: table => new
                {
                    IdGrupoPatologico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbGrupoP__A7D4244D8473F997", x => x.IdGrupoPatologico);
                });

            migrationBuilder.CreateTable(
                name: "tbGruposReceitasDespesas",
                columns: table => new
                {
                    IdReceitaDespesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbGrupos__6D0EB5405BF2A8A2", x => x.IdReceitaDespesa);
                });

            migrationBuilder.CreateTable(
                name: "tbPais",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Sigla = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbPais__FC850A7B0E4B8FB8", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "tbPatologia",
                columns: table => new
                {
                    IdPatologia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InformacaoComplementar = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbPatolo__6D573A32CB2159DD", x => x.IdPatologia);
                });

            migrationBuilder.CreateTable(
                name: "tbPlano",
                columns: table => new
                {
                    IdPlano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Validade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbPlano__4C970C540297154D", x => x.IdPlano);
                });

            migrationBuilder.CreateTable(
                name: "tbSubstancia",
                columns: table => new
                {
                    IdSubstancia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InformacaoComplementar = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbSubsta__13276D321A469721", x => x.IdSubstancia);
                });

            migrationBuilder.CreateTable(
                name: "tbSuplemento",
                columns: table => new
                {
                    IdSuplemento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoQuantidade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DoseMinima = table.Column<double>(type: "float", nullable: false),
                    DoseMaxima = table.Column<double>(type: "float", nullable: false),
                    Carboidrato = table.Column<double>(type: "float", nullable: false),
                    VitaminaA = table.Column<double>(type: "float", nullable: false),
                    VitaminaB = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbSuplem__EC3A6B160D0E538F", x => x.IdSuplemento);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoAcesso",
                columns: table => new
                {
                    IdTipoAcesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FlagAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbTipoAc__FFC17AE5BEE97553", x => x.IdTipoAcesso);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoProfissional",
                columns: table => new
                {
                    IdTipoProfissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbTipoPr__358F03BEAA1B9B6E", x => x.IdTipoProfissional);
                });

            /*(migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            /*migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });*/

            migrationBuilder.CreateTable(
                name: "tbMedicamento",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoriaMedicamento = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Bula = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    BulaArquivo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbMedica__AC96376E90E9D5E4", x => x.IdMedicamento);
                    table.ForeignKey(
                        name: "FK__tbMedicam__IdCat__5812160E",
                        column: x => x.IdCategoriaMedicamento,
                        principalTable: "tbCategoriaMedicamento",
                        principalColumn: "IdCategoriaMedicamento");
                });

            migrationBuilder.CreateTable(
                name: "tbLancarReceitasDespesas",
                columns: table => new
                {
                    IdLancamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceitaDespesa = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbLancar__2E531549C4400B28", x => x.IdLancamento);
                    table.ForeignKey(
                        name: "FK__tbLancarR__IdRec__1EA48E88",
                        column: x => x.IdReceitaDespesa,
                        principalTable: "tbGruposReceitasDespesas",
                        principalColumn: "IdReceitaDespesa");
                });

            migrationBuilder.CreateTable(
                name: "tbEstado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbEstado__FBB0EDC188F0ED55", x => x.IdEstado);
                    table.ForeignKey(
                        name: "FK__tbEstado__IdPais__398D8EEE",
                        column: x => x.IdPais,
                        principalTable: "tbPais",
                        principalColumn: "IdPais");
                });

            migrationBuilder.CreateTable(
                name: "tbGrupoPatologico_X_Patologia",
                columns: table => new
                {
                    IdPatologia_X_GrupoPatologico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGrupoPatologico = table.Column<int>(type: "int", nullable: false),
                    IdPatologia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbGrupoP__2BA30300C74D500A", x => x.IdPatologia_X_GrupoPatologico);
                    table.ForeignKey(
                        name: "FK__tbGrupoPa__IdGru__5070F446",
                        column: x => x.IdGrupoPatologico,
                        principalTable: "tbGrupoPatologico",
                        principalColumn: "IdGrupoPatologico");
                    table.ForeignKey(
                        name: "FK__tbGrupoPa__IdPat__5165187F",
                        column: x => x.IdPatologia,
                        principalTable: "tbPatologia",
                        principalColumn: "IdPatologia");
                });

            migrationBuilder.CreateTable(
                name: "tbContrato",
                columns: table => new
                {
                    IdContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlano = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    DataFim = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbContra__8569F05AC291EB56", x => x.IdContrato);
                    table.ForeignKey(
                        name: "FK__tbContrat__IdPla__412EB0B6",
                        column: x => x.IdPlano,
                        principalTable: "tbPlano",
                        principalColumn: "IdPlano");
                });

            migrationBuilder.CreateTable(
                name: "tbCidade",
                columns: table => new
                {
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstado = table.Column<int>(type: "int", nullable: true),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbCidade__160879A3F9A62446", x => x.IdCidade);
                    table.ForeignKey(
                        name: "FK__tbCidade__IdEsta__3C69FB99",
                        column: x => x.IdEstado,
                        principalTable: "tbEstado",
                        principalColumn: "IdEstado");
                });

            migrationBuilder.CreateTable(
                name: "tbPaciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RG = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Etnia = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdCidade = table.Column<int>(type: "int", nullable: true),
                    TelResidencial = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    TelComercial = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    TelCelular = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Profissao = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    FlgAtleta = table.Column<bool>(type: "bit", nullable: true),
                    FlgGestante = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbPacien__C93DB49B87CE1DFE", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK__tbPacient__IdCid__68487DD7",
                        column: x => x.IdCidade,
                        principalTable: "tbCidade",
                        principalColumn: "IdCidade");
                });

            migrationBuilder.CreateTable(
                name: "tbProfissional",
                columns: table => new
                {
                    IdProfissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoProfissional = table.Column<int>(type: "int", nullable: true),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    IdTipoAcesso = table.Column<int>(type: "int", nullable: true),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CRM_CRN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Especialidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    DDD1 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    DDD2 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Telefone1 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Telefone2 = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbProfis__B9503FBCD9D3008C", x => x.IdProfissional);
                    table.ForeignKey(
                        name: "FK__tbProfiss__IdCid__49C3F6B7",
                        column: x => x.IdCidade,
                        principalTable: "tbCidade",
                        principalColumn: "IdCidade");
                    table.ForeignKey(
                        name: "FK__tbProfiss__IdCon__47DBAE45",
                        column: x => x.IdContrato,
                        principalTable: "tbContrato",
                        principalColumn: "IdContrato");
                    table.ForeignKey(
                        name: "FK__tbProfiss__IdTip__48CFD27E",
                        column: x => x.IdTipoAcesso,
                        principalTable: "tbTipoAcesso",
                        principalColumn: "IdTipoAcesso");
                });

            migrationBuilder.CreateTable(
                name: "tbExame_X_Pacientes",
                columns: table => new
                {
                    IdExame_X_Paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdExame = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: true),
                    Resultado = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbExame___8F261547D75B06D7", x => x.IdExame_X_Paciente);
                    table.ForeignKey(
                        name: "FK__tbExame_X__IdExa__08B54D69",
                        column: x => x.IdExame,
                        principalTable: "tbExame",
                        principalColumn: "IdExame");
                    table.ForeignKey(
                        name: "FK__tbExame_X__IdPac__09A971A2",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "tbHistoriaPatologica",
                columns: table => new
                {
                    IdHistoriaPatologica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdPatologia = table.Column<int>(type: "int", nullable: true),
                    FlgHAS = table.Column<bool>(type: "bit", nullable: true),
                    FlgAVC = table.Column<bool>(type: "bit", nullable: true),
                    FlgDoencasPulmonares = table.Column<bool>(type: "bit", nullable: true),
                    FlgDoencasCardiacas = table.Column<bool>(type: "bit", nullable: true),
                    FlgDoencaRenal = table.Column<bool>(type: "bit", nullable: true),
                    FlgDoencaHepatica = table.Column<bool>(type: "bit", nullable: true),
                    FlgNeoplasia = table.Column<bool>(type: "bit", nullable: true),
                    FlgHipercolesterolemia = table.Column<bool>(type: "bit", nullable: true),
                    FlgHipertrigliciridemia = table.Column<bool>(type: "bit", nullable: true),
                    FlgHiperuricemia = table.Column<bool>(type: "bit", nullable: true),
                    FlgAnemias = table.Column<bool>(type: "bit", nullable: true),
                    FlgCirurgias = table.Column<bool>(type: "bit", nullable: true),
                    FlgDoencasAutoImunes = table.Column<bool>(type: "bit", nullable: true),
                    FlgDiabetes = table.Column<bool>(type: "bit", nullable: true),
                    Obs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbHistor__86BDE8CF1E996F4D", x => x.IdHistoriaPatologica);
                    table.ForeignKey(
                        name: "FK__tbHistori__IdPac__76969D2E",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK__tbHistori__IdPat__778AC167",
                        column: x => x.IdPatologia,
                        principalTable: "tbPatologia",
                        principalColumn: "IdPatologia");
                });

            migrationBuilder.CreateTable(
                name: "tbHistoricoAlimentarNutricional",
                columns: table => new
                {
                    IdHistAlimentarNutricional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    MotivacaoTratamento = table.Column<int>(type: "int", nullable: true),
                    ModismosAlimentares = table.Column<int>(type: "int", nullable: true),
                    FlgIntoleanciaAlimentar = table.Column<bool>(type: "bit", nullable: true),
                    DescIntoleranciaAlimentar = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FaseObesidadePerdaPeso = table.Column<int>(type: "int", nullable: true),
                    FlgPerdaGanhoPeso = table.Column<bool>(type: "bit", nullable: true),
                    PesoMax = table.Column<int>(type: "int", nullable: true),
                    PesoMaxIdade = table.Column<int>(type: "int", nullable: true),
                    PesoMin = table.Column<int>(type: "int", nullable: true),
                    PesoMinIdade = table.Column<int>(type: "int", nullable: true),
                    FlgDietas = table.Column<bool>(type: "bit", nullable: true),
                    DescDietas = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FlgMedicamentos = table.Column<bool>(type: "bit", nullable: true),
                    DescMedicamentos = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FlgExercicios = table.Column<bool>(type: "bit", nullable: true),
                    DescExercicios = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FlgOutros = table.Column<bool>(type: "bit", nullable: true),
                    DescOutros = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Obs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbHistor__43605910B8D41005", x => x.IdHistAlimentarNutricional);
                    table.ForeignKey(
                        name: "FK__tbHistori__IdPac__00200768",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "tbHistoricoDoencaAtual",
                columns: table => new
                {
                    IdHDA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdPatologia = table.Column<int>(type: "int", nullable: true),
                    Historico = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Cirurgia = table.Column<int>(type: "int", nullable: true),
                    Trauma = table.Column<int>(type: "int", nullable: true),
                    Infeccao = table.Column<int>(type: "int", nullable: true),
                    Neoplasia = table.Column<int>(type: "int", nullable: true),
                    Metastase = table.Column<int>(type: "int", nullable: true),
                    Queimadura = table.Column<int>(type: "int", nullable: true),
                    ObsNeoplasia = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ObsMetastase = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    ObsQueimadura = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Outros = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbHistor__0B5E79E21AD7740A", x => x.IdHDA);
                    table.ForeignKey(
                        name: "FK__tbHistori__IdPac__72C60C4A",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK__tbHistori__IdPat__73BA3083",
                        column: x => x.IdPatologia,
                        principalTable: "tbPatologia",
                        principalColumn: "IdPatologia");
                });

            migrationBuilder.CreateTable(
                name: "tbHistoricoSocialAlimentar",
                columns: table => new
                {
                    IdHistSocialAlimentar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CargaHoraria = table.Column<int>(type: "int", nullable: true),
                    NroPessoasRes = table.Column<int>(type: "int", nullable: true),
                    RendaFamiliar = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    Escolaridade = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EstadoCivil = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    NomeCompraAlimento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NomeCozinhaAlimento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CompraFeita = table.Column<int>(type: "int", nullable: true),
                    NomeRealizaRefeicao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FlgTabagismo = table.Column<bool>(type: "bit", nullable: true),
                    QtdTabagismoDia = table.Column<int>(type: "int", nullable: true),
                    FlgEtilismo = table.Column<bool>(type: "bit", nullable: true),
                    QtdEtilismoDia = table.Column<int>(type: "int", nullable: true),
                    FlgCafe = table.Column<bool>(type: "bit", nullable: true),
                    QtdCafeDia = table.Column<int>(type: "int", nullable: true),
                    FlgPaiMaeHas = table.Column<bool>(type: "bit", nullable: true),
                    FlgAvosHas = table.Column<bool>(type: "bit", nullable: true),
                    FlgIrmaosHas = table.Column<bool>(type: "bit", nullable: true),
                    FlgPaiMaeDiabetes = table.Column<bool>(type: "bit", nullable: true),
                    FlgAvosDiabetes = table.Column<bool>(type: "bit", nullable: true),
                    FlgIrmaosDiabetes = table.Column<bool>(type: "bit", nullable: true),
                    FlgPaiMaeCancer = table.Column<bool>(type: "bit", nullable: true),
                    FlgAvosCancer = table.Column<bool>(type: "bit", nullable: true),
                    FlgIrmaosCancer = table.Column<bool>(type: "bit", nullable: true),
                    FlgPaiMaeObesidade = table.Column<bool>(type: "bit", nullable: true),
                    FlgAvosObesidade = table.Column<bool>(type: "bit", nullable: true),
                    FlgIrmaosObesidade = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbHistor__7735810FEB315D96", x => x.IdHistSocialAlimentar);
                    table.ForeignKey(
                        name: "FK__tbHistori__IdPac__7D439ABD",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "tbHoraPaciente_Profissional",
                columns: table => new
                {
                    IdHoraPaciente_Profissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdProfissional = table.Column<int>(type: "int", nullable: false),
                    DataConsulta = table.Column<DateOnly>(type: "date", nullable: true),
                    HoraInicioIndividual = table.Column<TimeOnly>(type: "time(0)", precision: 0, nullable: false),
                    HoraFimIndividual = table.Column<TimeOnly>(type: "time(0)", precision: 0, nullable: false),
                    PrimeiraConculta = table.Column<bool>(type: "bit", nullable: false),
                    Compareceu = table.Column<bool>(type: "bit", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    Resumo = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbHoraPa__A67184260E014819", x => x.IdHoraPaciente_Profissional);
                    table.ForeignKey(
                        name: "FK__tbHoraPac__IdPac__6EF57B66",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK__tbHoraPac__IdPro__6FE99F9F",
                        column: x => x.IdProfissional,
                        principalTable: "tbProfissional",
                        principalColumn: "IdProfissional");
                });

            migrationBuilder.CreateTable(
                name: "tbMedico_Paciente",
                columns: table => new
                {
                    IdMedico_Paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdProfissional = table.Column<int>(type: "int", nullable: false),
                    InformacaoResumida = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbMedico__1F0BE44C0A2AD1D5", x => x.IdMedico_Paciente);
                    table.ForeignKey(
                        name: "FK__tbMedico___IdPac__6B24EA82",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK__tbMedico___IdPro__6C190EBB",
                        column: x => x.IdProfissional,
                        principalTable: "tbProfissional",
                        principalColumn: "IdProfissional");
                });

            migrationBuilder.CreateTable(
                name: "tbPergunta",
                columns: table => new
                {
                    IdPergunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfissional = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbPergun__6DC6D9A7D4EDA3D1", x => x.IdPergunta);
                    table.ForeignKey(
                        name: "FK__tbPergunt__IdPro__0C85DE4D",
                        column: x => x.IdProfissional,
                        principalTable: "tbProfissional",
                        principalColumn: "IdProfissional");
                });

            migrationBuilder.CreateTable(
                name: "tbReceitaAlimentarPadrao",
                columns: table => new
                {
                    IdReceitaAlimentarPadrao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfissional = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    InformacaoComplementar = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbReceit__63863561B967240D", x => x.IdReceitaAlimentarPadrao);
                    table.ForeignKey(
                        name: "FK__tbReceita__IdPro__5EBF139D",
                        column: x => x.IdProfissional,
                        principalTable: "tbProfissional",
                        principalColumn: "IdProfissional");
                });

            migrationBuilder.CreateTable(
                name: "tbReceitaMedicaPadrao",
                columns: table => new
                {
                    IdReceitaMedicaPadrao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfissional = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    InformacaoComplementar = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbReceit__E6DF7D77D9F2691C", x => x.IdReceitaMedicaPadrao);
                    table.ForeignKey(
                        name: "FK__tbReceita__IdPro__619B8048",
                        column: x => x.IdProfissional,
                        principalTable: "tbProfissional",
                        principalColumn: "IdProfissional");
                });

            migrationBuilder.CreateTable(
                name: "tbAntropometria",
                columns: table => new
                {
                    IdAntropometria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoraPaciente_Profissional = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Estatura = table.Column<int>(type: "int", nullable: true),
                    AlturaJoelho = table.Column<int>(type: "int", nullable: true),
                    PesoAtual = table.Column<int>(type: "int", nullable: true),
                    PesoUsual = table.Column<int>(type: "int", nullable: true),
                    TipoProtocolo = table.Column<int>(type: "int", nullable: true),
                    Tricipal = table.Column<int>(type: "int", nullable: true),
                    Subescap = table.Column<int>(type: "int", nullable: true),
                    AuxiliarMed = table.Column<int>(type: "int", nullable: true),
                    SupraIliaca = table.Column<int>(type: "int", nullable: true),
                    Abdomen = table.Column<int>(type: "int", nullable: true),
                    Peitoral = table.Column<int>(type: "int", nullable: true),
                    Coxa = table.Column<int>(type: "int", nullable: true),
                    Biceps = table.Column<int>(type: "int", nullable: true),
                    Panturrilha = table.Column<int>(type: "int", nullable: true),
                    PercGordura = table.Column<int>(type: "int", nullable: true),
                    CircunfBraco = table.Column<int>(type: "int", nullable: true),
                    CircunfAbdomen = table.Column<int>(type: "int", nullable: true),
                    CircunfCintura = table.Column<int>(type: "int", nullable: true),
                    CircunfQuadril = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbAntrop__53A9E5941381DBE2", x => x.IdAntropometria);
                    table.ForeignKey(
                        name: "FK__tbAntropo__IdHor__02FC7413",
                        column: x => x.IdHoraPaciente_Profissional,
                        principalTable: "tbHoraPaciente_Profissional",
                        principalColumn: "IdHoraPaciente_Profissional");
                    table.ForeignKey(
                        name: "FK__tbAntropo__IdPac__03F0984C",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "tbEscalaBristol_Paciente_Consulta",
                columns: table => new
                {
                    IdEscalaBristol_Paciente_Consulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEscalaBristol = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdHora_Paciente_Profissional = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbEscala__44B7B8966A35F545", x => x.IdEscalaBristol_Paciente_Consulta);
                    table.ForeignKey(
                        name: "FK__tbEscalaB__IdEsc__17F790F9",
                        column: x => x.IdEscalaBristol,
                        principalTable: "tbEscalaBristol",
                        principalColumn: "IdEscalaBristol");
                    table.ForeignKey(
                        name: "FK__tbEscalaB__IdHor__19DFD96B",
                        column: x => x.IdHora_Paciente_Profissional,
                        principalTable: "tbHoraPaciente_Profissional",
                        principalColumn: "IdHoraPaciente_Profissional");
                    table.ForeignKey(
                        name: "FK__tbEscalaB__IdPac__18EBB532",
                        column: x => x.IdPaciente,
                        principalTable: "tbPaciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "tbExameFisico",
                columns: table => new
                {
                    IdExameFisico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoraPaciente_Profissional = table.Column<int>(type: "int", nullable: true),
                    SNC = table.Column<int>(type: "int", nullable: true),
                    AtividadeFisica = table.Column<int>(type: "int", nullable: true),
                    TipoAtividadeFisica = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Frequencia = table.Column<int>(type: "int", nullable: true),
                    HoraPreferido = table.Column<int>(type: "int", nullable: true),
                    Tempo = table.Column<int>(type: "int", nullable: true),
                    FlgDenticaoCompleta = table.Column<bool>(type: "bit", nullable: true),
                    FlgDenticaoIncompleta = table.Column<bool>(type: "bit", nullable: true),
                    FlgDenticaoAusente = table.Column<bool>(type: "bit", nullable: true),
                    FlgDenticaoProtese = table.Column<bool>(type: "bit", nullable: true),
                    Mastigacao = table.Column<int>(type: "int", nullable: true),
                    Peristalse = table.Column<int>(type: "int", nullable: true),
                    Fumante = table.Column<int>(type: "int", nullable: true),
                    FrequenciaCardiaca = table.Column<int>(type: "int", nullable: true),
                    PA = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    FrequenciaRespiratoria = table.Column<int>(type: "int", nullable: true),
                    Temperatura = table.Column<int>(type: "int", nullable: true),
                    Glicemia = table.Column<int>(type: "int", nullable: true),
                    Diurese = table.Column<int>(type: "int", nullable: true),
                    TipoDiurese = table.Column<int>(type: "int", nullable: true),
                    Evacuacao = table.Column<int>(type: "int", nullable: true),
                    TipoEvacuacao = table.Column<int>(type: "int", nullable: true),
                    Ingestao = table.Column<int>(type: "int", nullable: true),
                    Excrecao = table.Column<int>(type: "int", nullable: true),
                    FlgXerostomia = table.Column<bool>(type: "bit", nullable: true),
                    FlgSialorreia = table.Column<bool>(type: "bit", nullable: true),
                    FlgUlcerasBucais = table.Column<bool>(type: "bit", nullable: true),
                    FlgNauseas = table.Column<bool>(type: "bit", nullable: true),
                    FlgVomitos = table.Column<bool>(type: "bit", nullable: true),
                    FlgDisfagia = table.Column<bool>(type: "bit", nullable: true),
                    FlgOdinofagia = table.Column<bool>(type: "bit", nullable: true),
                    FlgFistula = table.Column<bool>(type: "bit", nullable: true),
                    FlgOral = table.Column<bool>(type: "bit", nullable: true),
                    FlgOralEnteral = table.Column<bool>(type: "bit", nullable: true),
                    FlgEnteralExclusiva = table.Column<bool>(type: "bit", nullable: true),
                    FlgEnteralParental = table.Column<bool>(type: "bit", nullable: true),
                    FlgParentalExclusiva = table.Column<bool>(type: "bit", nullable: true),
                    FlgParentalOral = table.Column<bool>(type: "bit", nullable: true),
                    TipoAcesso = table.Column<int>(type: "int", nullable: true),
                    FlgGastrico = table.Column<bool>(type: "bit", nullable: true),
                    FlgTranspilorica = table.Column<bool>(type: "bit", nullable: true),
                    FlgDuodenal = table.Column<bool>(type: "bit", nullable: true),
                    FlgJejunal = table.Column<bool>(type: "bit", nullable: true),
                    FlgHiperemia = table.Column<bool>(type: "bit", nullable: true),
                    FlgSaidaSecrecao = table.Column<bool>(type: "bit", nullable: true),
                    FlgPresencaFeridas = table.Column<bool>(type: "bit", nullable: true),
                    Obs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbExameF__C8897518CD27158B", x => x.IdExameFisico);
                    table.ForeignKey(
                        name: "FK__tbExameFi__IdHor__7A672E12",
                        column: x => x.IdHoraPaciente_Profissional,
                        principalTable: "tbHoraPaciente_Profissional",
                        principalColumn: "IdHoraPaciente_Profissional");
                });

            migrationBuilder.CreateTable(
                name: "tbRastreamentoResposta",
                columns: table => new
                {
                    IdRastreamentoResposta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPergunta = table.Column<int>(type: "int", nullable: false),
                    VlrRespota = table.Column<int>(type: "int", nullable: false),
                    IdParteCorpo = table.Column<int>(type: "int", nullable: false),
                    Obs = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbRastre__ABA70EB6ADFF52D5", x => x.IdRastreamentoResposta);
                    table.ForeignKey(
                        name: "FK__tbRastrea__IdPer__0F624AF8",
                        column: x => x.IdPergunta,
                        principalTable: "tbPergunta",
                        principalColumn: "IdPergunta");
                });

            migrationBuilder.CreateTable(
                name: "tbReceitaAlimentarPadrao_X_Alimento",
                columns: table => new
                {
                    IdReceitaAlimentarPadrao_X_Alimento_X_QuantidadeAlimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceitaAlimentarPadrao = table.Column<int>(type: "int", nullable: false),
                    IdAlimento = table.Column<int>(type: "int", nullable: false),
                    IdQuantidadeAlimento = table.Column<int>(type: "int", nullable: false),
                    Periodicidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    QuantoTempo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbReceit__2843B293137E4EBF", x => x.IdReceitaAlimentarPadrao_X_Alimento_X_QuantidadeAlimento);
                    table.ForeignKey(
                        name: "FK__tbReceita__IdAli__656C112C",
                        column: x => x.IdAlimento,
                        principalTable: "tbAlimento",
                        principalColumn: "IdAlimento");
                    table.ForeignKey(
                        name: "FK__tbReceita__IdRec__6477ECF3",
                        column: x => x.IdReceitaAlimentarPadrao,
                        principalTable: "tbReceitaAlimentarPadrao",
                        principalColumn: "IdReceitaAlimentarPadrao");
                });

            migrationBuilder.CreateTable(
                name: "tbRastreamentoMetabolico",
                columns: table => new
                {
                    IdRastreamentoMetabolico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRastreamentoResposta = table.Column<int>(type: "int", nullable: false),
                    IdHoraPaciente_Profissional = table.Column<int>(type: "int", nullable: false),
                    ObsGeral = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Total = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbRastre__E5AA062354B3AF6E", x => x.IdRastreamentoMetabolico);
                    table.ForeignKey(
                        name: "FK__tbRastrea__IdHor__1332DBDC",
                        column: x => x.IdHoraPaciente_Profissional,
                        principalTable: "tbHoraPaciente_Profissional",
                        principalColumn: "IdHoraPaciente_Profissional");
                    table.ForeignKey(
                        name: "FK__tbRastrea__IdRas__123EB7A3",
                        column: x => x.IdRastreamentoResposta,
                        principalTable: "tbRastreamentoResposta",
                        principalColumn: "IdRastreamentoResposta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAntropometria_IdHoraPaciente_Profissional",
                table: "tbAntropometria",
                column: "IdHoraPaciente_Profissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbAntropometria_IdPaciente",
                table: "tbAntropometria",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbCidade_IdEstado",
                table: "tbCidade",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_tbContrato_IdPlano",
                table: "tbContrato",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_tbEscalaBristol_Paciente_Consulta_IdEscalaBristol",
                table: "tbEscalaBristol_Paciente_Consulta",
                column: "IdEscalaBristol");

            migrationBuilder.CreateIndex(
                name: "IX_tbEscalaBristol_Paciente_Consulta_IdHora_Paciente_Profissional",
                table: "tbEscalaBristol_Paciente_Consulta",
                column: "IdHora_Paciente_Profissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbEscalaBristol_Paciente_Consulta_IdPaciente",
                table: "tbEscalaBristol_Paciente_Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbEstado_IdPais",
                table: "tbEstado",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_tbExame_X_Pacientes_IdExame",
                table: "tbExame_X_Pacientes",
                column: "IdExame");

            migrationBuilder.CreateIndex(
                name: "IX_tbExame_X_Pacientes_IdPaciente",
                table: "tbExame_X_Pacientes",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbExameFisico_IdHoraPaciente_Profissional",
                table: "tbExameFisico",
                column: "IdHoraPaciente_Profissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbGrupoPatologico_X_Patologia_IdGrupoPatologico",
                table: "tbGrupoPatologico_X_Patologia",
                column: "IdGrupoPatologico");

            migrationBuilder.CreateIndex(
                name: "IX_tbGrupoPatologico_X_Patologia_IdPatologia",
                table: "tbGrupoPatologico_X_Patologia",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_tbHistoriaPatologica_IdPaciente",
                table: "tbHistoriaPatologica",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbHistoriaPatologica_IdPatologia",
                table: "tbHistoriaPatologica",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_tbHistoricoAlimentarNutricional_IdPaciente",
                table: "tbHistoricoAlimentarNutricional",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbHistoricoDoencaAtual_IdPaciente",
                table: "tbHistoricoDoencaAtual",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbHistoricoDoencaAtual_IdPatologia",
                table: "tbHistoricoDoencaAtual",
                column: "IdPatologia");

            migrationBuilder.CreateIndex(
                name: "IX_tbHistoricoSocialAlimentar_IdPaciente",
                table: "tbHistoricoSocialAlimentar",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbHoraPaciente_Profissional_IdPaciente",
                table: "tbHoraPaciente_Profissional",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbHoraPaciente_Profissional_IdProfissional",
                table: "tbHoraPaciente_Profissional",
                column: "IdProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbLancarReceitasDespesas_IdReceitaDespesa",
                table: "tbLancarReceitasDespesas",
                column: "IdReceitaDespesa");

            migrationBuilder.CreateIndex(
                name: "IX_tbMedicamento_IdCategoriaMedicamento",
                table: "tbMedicamento",
                column: "IdCategoriaMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_tbMedico_Paciente_IdPaciente",
                table: "tbMedico_Paciente",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_tbMedico_Paciente_IdProfissional",
                table: "tbMedico_Paciente",
                column: "IdProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbPaciente_IdCidade",
                table: "tbPaciente",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_tbPergunta_IdProfissional",
                table: "tbPergunta",
                column: "IdProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbProfissional_IdCidade",
                table: "tbProfissional",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_tbProfissional_IdContrato",
                table: "tbProfissional",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_tbProfissional_IdTipoAcesso",
                table: "tbProfissional",
                column: "IdTipoAcesso");

            migrationBuilder.CreateIndex(
                name: "IX_tbRastreamentoMetabolico_IdHoraPaciente_Profissional",
                table: "tbRastreamentoMetabolico",
                column: "IdHoraPaciente_Profissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbRastreamentoMetabolico_IdRastreamentoResposta",
                table: "tbRastreamentoMetabolico",
                column: "IdRastreamentoResposta");

            migrationBuilder.CreateIndex(
                name: "IX_tbRastreamentoResposta_IdPergunta",
                table: "tbRastreamentoResposta",
                column: "IdPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_tbReceitaAlimentarPadrao_IdProfissional",
                table: "tbReceitaAlimentarPadrao",
                column: "IdProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_tbReceitaAlimentarPadrao_X_Alimento_IdAlimento",
                table: "tbReceitaAlimentarPadrao_X_Alimento",
                column: "IdAlimento");

            migrationBuilder.CreateIndex(
                name: "IX_tbReceitaAlimentarPadrao_X_Alimento_IdReceitaAlimentarPadrao",
                table: "tbReceitaAlimentarPadrao_X_Alimento",
                column: "IdReceitaAlimentarPadrao");

            migrationBuilder.CreateIndex(
                name: "IX_tbReceitaMedicaPadrao_IdProfissional",
                table: "tbReceitaMedicaPadrao",
                column: "IdProfissional");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAntropometria");

            migrationBuilder.DropTable(
                name: "tbEscalaBristol_Paciente_Consulta");

            migrationBuilder.DropTable(
                name: "tbExame_X_Pacientes");

            migrationBuilder.DropTable(
                name: "tbExameFisico");

            migrationBuilder.DropTable(
                name: "tbGrupoPatologico_X_Patologia");

            migrationBuilder.DropTable(
                name: "tbHistoriaPatologica");

            migrationBuilder.DropTable(
                name: "tbHistoricoAlimentarNutricional");

            migrationBuilder.DropTable(
                name: "tbHistoricoDoencaAtual");

            migrationBuilder.DropTable(
                name: "tbHistoricoSocialAlimentar");

            migrationBuilder.DropTable(
                name: "tbLancarReceitasDespesas");

            migrationBuilder.DropTable(
                name: "tbMedicamento");

            migrationBuilder.DropTable(
                name: "tbMedico_Paciente");

            migrationBuilder.DropTable(
                name: "tbRastreamentoMetabolico");

            migrationBuilder.DropTable(
                name: "tbReceitaAlimentarPadrao_X_Alimento");

            migrationBuilder.DropTable(
                name: "tbReceitaMedicaPadrao");

            migrationBuilder.DropTable(
                name: "tbSubstancia");

            migrationBuilder.DropTable(
                name: "tbSuplemento");

            migrationBuilder.DropTable(
                name: "tbTipoProfissional");

            /*migrationBuilder.DropTable(
                name: "AspNetRoles");*/

            /*migrationBuilder.DropTable(
                name: "AspNetUsers");*/

            migrationBuilder.DropTable(
                name: "tbEscalaBristol");

            migrationBuilder.DropTable(
                name: "tbExame");

            migrationBuilder.DropTable(
                name: "tbGrupoPatologico");

            migrationBuilder.DropTable(
                name: "tbPatologia");

            migrationBuilder.DropTable(
                name: "tbGruposReceitasDespesas");

            migrationBuilder.DropTable(
                name: "tbCategoriaMedicamento");

            migrationBuilder.DropTable(
                name: "tbHoraPaciente_Profissional");

            migrationBuilder.DropTable(
                name: "tbRastreamentoResposta");

            migrationBuilder.DropTable(
                name: "tbAlimento");

            migrationBuilder.DropTable(
                name: "tbReceitaAlimentarPadrao");

            migrationBuilder.DropTable(
                name: "tbPaciente");

            migrationBuilder.DropTable(
                name: "tbPergunta");

            migrationBuilder.DropTable(
                name: "tbProfissional");

            migrationBuilder.DropTable(
                name: "tbCidade");

            migrationBuilder.DropTable(
                name: "tbContrato");

            migrationBuilder.DropTable(
                name: "tbTipoAcesso");

            migrationBuilder.DropTable(
                name: "tbEstado");

            migrationBuilder.DropTable(
                name: "tbPlano");

            migrationBuilder.DropTable(
                name: "tbPais");
        }
    }
}