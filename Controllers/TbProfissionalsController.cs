using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto1_Web2_IF_johnnata.Models;

namespace Projeto1_Web2_IF_johnnata.Controllers
{
    public class TbProfissionalsController : Controller
    {
        private readonly db_ifContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public TbProfissionalsController(db_ifContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: TbProfissionals
        [Authorize(Roles = "Medico,Nutricionista,GerenteMedico,GerenteNutricionista,GerenteGeral")]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);

            IQueryable<TbProfissional> query = _context.TbProfissional
                .Include(t => t.IdCidadeNavigation)
                .Include(t => t.IdContratoNavigation)
                    .ThenInclude(c => c.IdPlanoNavigation)
                .Include(t => t.IdTipoAcessoNavigation);

            // Gerentes veem profissionais conforme suas permissões
            if (roles.Contains("GerenteMedico"))
            {
                // GerenteMedico vê apenas médicos (IdTipoProfissional = 1)
                query = query.Where(t => t.IdTipoProfissional == 1);
                ViewData["IsManager"] = true;
                ViewData["ManagerType"] = "GerenteMedico";
            }
            else if (roles.Contains("GerenteNutricionista"))
            {
                // GerenteNutricionista vê apenas nutricionistas (IdTipoProfissional = 2)
                query = query.Where(t => t.IdTipoProfissional == 2);
                ViewData["IsManager"] = true;
                ViewData["ManagerType"] = "GerenteNutricionista";
            }
            else if (roles.Contains("GerenteGeral"))
            {
                // GerenteGeral vê todos os profissionais
                ViewData["IsManager"] = true;
                ViewData["ManagerType"] = "GerenteGeral";
            }
            else
            {
                // Profissionais só podem ver seus próprios dados
                query = query.Where(t => t.IdUser == userId);
                ViewData["IsManager"] = false;
            }

            var profissional = await query.ToListAsync();
            return View(profissional);
        }

        // GET: TbProfissionals/Details/5
        [Authorize(Roles = "Medico,Nutricionista,GerenteMedico,GerenteNutricionista,GerenteGeral")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var tbProfissional = await _context.TbProfissional
                .Include(t => t.IdCidadeNavigation)
                .Include(t => t.IdContratoNavigation)
                    .ThenInclude(c => c.IdPlanoNavigation)
                .Include(t => t.IdTipoAcessoNavigation)
                .FirstOrDefaultAsync(m => m.IdProfissional == id);

            if (tbProfissional == null)
            {
                return NotFound();
            }

            // Verificar permissões
            bool isManager = roles.Contains("GerenteMedico") || roles.Contains("GerenteNutricionista") || roles.Contains("GerenteGeral");

            if (isManager)
            {
                // Gerentes podem ver profissionais conforme suas permissões
                if (roles.Contains("GerenteMedico") && tbProfissional.IdTipoProfissional != 1)
                {
                    return Forbid(); // GerenteMedico só pode ver médicos
                }
                else if (roles.Contains("GerenteNutricionista") && tbProfissional.IdTipoProfissional != 2)
                {
                    return Forbid(); // GerenteNutricionista só pode ver nutricionistas
                }
                // GerenteGeral pode ver todos
            }
            else
            {
                // Profissionais só podem ver seus próprios dados
                if (tbProfissional.IdUser != userId)
                {
                    return Forbid();
                }
            }

            ViewData["IsManager"] = isManager;
            return View(tbProfissional);
        }

        // GET: TbProfissionals/Register (Público - para auto-cadastro)
        [AllowAnonymous]
        public IActionResult Register()
        {
            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome");
            ViewData["IdCidade"] = new SelectList(Enumerable.Empty<TbCidade>(), "IdCidade", "Nome");

            // Não carregar contratos aqui - serão carregados dinamicamente via AJAX baseado no tipo de profissional

            return View();
        }

        // GET: API para buscar cidades por estado
        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetCidadesByEstado(int idEstado)
        {
            var cidades = _context.TbCidade
                .Where(c => c.IdEstado == idEstado)
                .OrderBy(c => c.Nome)
                .Select(c => new { value = c.IdCidade, text = c.Nome })
                .ToList();

            return Json(cidades);
        }

        // GET: API para buscar contratos/planos por tipo de profissional
        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetContratosByTipoProfissional(string tipoProfissional)
        {
            var contratos = _context.TbContrato
                .Include(c => c.IdPlanoNavigation)
                .AsEnumerable() // Traz para memória para fazer filtro de string
                .Where(c =>
                {
                    if (tipoProfissional == "Medico")
                    {
                        return c.IdPlanoNavigation.Nome.Contains("Médico") || c.IdPlanoNavigation.Nome.Contains("Medico");
                    }
                    else if (tipoProfissional == "Nutricionista")
                    {
                        return c.IdPlanoNavigation.Nome.Contains("Nutricionista");
                    }
                    return false;
                })
                .Select(c => new
                {
                    value = c.IdContrato,
                    text = c.IdPlanoNavigation.Nome + " (Contrato #" + c.IdContrato + ")" +
                           (c.DataInicio.HasValue ? " - " + c.DataInicio.Value.ToString("dd/MM/yyyy") : "") +
                           (c.DataFim.HasValue ? " até " + c.DataFim.Value.ToString("dd/MM/yyyy") : "")
                })
                .ToList();

            return Json(contratos);
        }

        // POST: TbProfissionals/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterProfissionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificar se CPF já existe
                var cpfExistente = await _context.TbProfissional.AnyAsync(p => p.Cpf == model.Cpf);
                if (cpfExistente)
                {
                    ModelState.AddModelError("Cpf", "Este CPF já está cadastrado.");

                    ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome");
                    ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == model.IdEstado).OrderBy(c => c.Nome), "IdCidade", "Nome", model.IdCidade);

                    var contratos = _context.TbContrato
                        .Include(c => c.IdPlanoNavigation)
                        .Select(c => new
                        {
                            c.IdContrato,
                            NomeExibicao = c.IdPlanoNavigation.Nome + " (Contrato #" + c.IdContrato + ")" +
                                           (c.DataInicio.HasValue ? " - " + c.DataInicio.Value.ToString("dd/MM/yyyy") : "") +
                                           (c.DataFim.HasValue ? " até " + c.DataFim.Value.ToString("dd/MM/yyyy") : "")
                        })
                        .ToList();
                    ViewData["IdContrato"] = new SelectList(contratos, "IdContrato", "NomeExibicao", model.IdContrato);

                    return View(model);
                }

                // Criar usuário no Identity
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true // Confirmar email automaticamente
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Adicionar role baseado na escolha
                    await _userManager.AddToRoleAsync(user, model.TipoProfissional);

                    // Determinar IdTipoProfissional: 1 para Médico, 2 para Nutricionista
                    int idTipoProfissional = model.TipoProfissional == "Medico" ? 1 : 2;

                    // Criar registro do profissional
                    var profissional = new TbProfissional
                    {
                        IdUser = user.Id,
                        IdTipoProfissional = idTipoProfissional,
                        Nome = model.Nome,
                        Cpf = model.Cpf,
                        CrmCrn = model.CrmCrn,
                        Especialidade = model.Especialidade,
                        Logradouro = model.Logradouro,
                        Numero = model.Numero,
                        Bairro = model.Bairro,
                        Cep = model.Cep,
                        Cidade = null, // Removido - usar IdCidade
                        Estado = null, // Removido - usar IdEstado via IdCidade
                        Ddd1 = model.Ddd1,
                        Ddd2 = model.Ddd2,
                        Telefone1 = model.Telefone1,
                        Telefone2 = model.Telefone2,
                        IdCidade = model.IdCidade,
                        IdContrato = model.IdContrato,
                        IdTipoAcesso = 1 // Valor padrão
                    };

                    _context.Add(profissional);
                    await _context.SaveChangesAsync();

                    // Fazer login automático
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", model.IdEstado);
            ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == model.IdEstado).OrderBy(c => c.Nome), "IdCidade", "Nome", model.IdCidade);

            var contratosRetorno = _context.TbContrato
                .Include(c => c.IdPlanoNavigation)
                .Select(c => new
                {
                    c.IdContrato,
                    NomeExibicao = c.IdPlanoNavigation.Nome + " (Contrato #" + c.IdContrato + ")" +
                                   (c.DataInicio.HasValue ? " - " + c.DataInicio.Value.ToString("dd/MM/yyyy") : "") +
                                   (c.DataFim.HasValue ? " até " + c.DataFim.Value.ToString("dd/MM/yyyy") : "")
                })
                .ToList();
            ViewData["IdContrato"] = new SelectList(contratosRetorno, "IdContrato", "NomeExibicao", model.IdContrato);

            return View(model);
        }

        // GET: TbProfissionals/Create
        public IActionResult Create()
        {
            ViewData["IdCidade"] = new SelectList(_context.TbCidade, "IdCidade", "IdCidade");
            ViewData["IdContrato"] = new SelectList(_context.TbContrato, "IdContrato", "IdContrato");
            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcesso, "IdTipoAcesso", "Nome");
            return View();
        }

        // POST: TbProfissionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,IdUser,Nome,Cpf,CrmCrn,Especialidade,Logradouro,Numero,Bairro,Cep,Cidade,Estado,Ddd1,Ddd2,Telefone1,Telefone2,Salario")] TbProfissional tbProfissional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbProfissional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCidade"] = new SelectList(_context.TbCidade, "IdCidade", "IdCidade", tbProfissional.IdCidade);
            ViewData["IdContrato"] = new SelectList(_context.TbContrato, "IdContrato", "IdContrato", tbProfissional.IdContrato);
            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // GET: TbProfissionals/Edit/5
        [Authorize(Roles = "Medico,Nutricionista,GerenteMedico,GerenteNutricionista,GerenteGeral")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var tbProfissional = await _context.TbProfissional.FindAsync(id);

            if (tbProfissional == null)
            {
                return NotFound();
            }

            // Verificar permissões
            bool isManager = roles.Contains("GerenteMedico") || roles.Contains("GerenteNutricionista") || roles.Contains("GerenteGeral");

            if (isManager)
            {
                // Gerentes podem editar profissionais conforme suas permissões
                if (roles.Contains("GerenteMedico") && tbProfissional.IdTipoProfissional != 1)
                {
                    return Forbid(); // GerenteMedico só pode editar médicos
                }
                else if (roles.Contains("GerenteNutricionista") && tbProfissional.IdTipoProfissional != 2)
                {
                    return Forbid(); // GerenteNutricionista só pode editar nutricionistas
                }
                // GerenteGeral pode editar todos
                ViewData["IsManager"] = true;
                ViewData["CanEditCpf"] = true; // Gerentes podem editar CPF
            }
            else
            {
                // Profissionais só podem editar seus próprios dados
                if (tbProfissional.IdUser != userId)
                {
                    return Forbid();
                }
                ViewData["IsManager"] = false;
                ViewData["CanEditCpf"] = false; // Profissionais não podem editar CPF
            }

            // Obter o IdEstado da cidade selecionada
            var cidade = await _context.TbCidade.FindAsync(tbProfissional.IdCidade);
            var idEstado = cidade?.IdEstado;

            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", idEstado);
            ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == idEstado).OrderBy(c => c.Nome), "IdCidade", "Nome", tbProfissional.IdCidade);

            var contratos = _context.TbContrato
                .Include(c => c.IdPlanoNavigation)
                .Select(c => new
                {
                    c.IdContrato,
                    NomeExibicao = c.IdPlanoNavigation.Nome + " (Contrato #" + c.IdContrato + ")" +
                                   (c.DataInicio.HasValue ? " - " + c.DataInicio.Value.ToString("dd/MM/yyyy") : "") +
                                   (c.DataFim.HasValue ? " até " + c.DataFim.Value.ToString("dd/MM/yyyy") : "")
                })
                .ToList();
            ViewData["IdContrato"] = new SelectList(contratos, "IdContrato", "NomeExibicao", tbProfissional.IdContrato);

            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);
            return View(tbProfissional);
        }

        // POST: TbProfissionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medico,Nutricionista,GerenteMedico,GerenteNutricionista,GerenteGeral")]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfissional,IdTipoProfissional,IdContrato,IdTipoAcesso,IdCidade,IdUser,Nome,Cpf,CrmCrn,Especialidade,Logradouro,Numero,Bairro,Cep,Cidade,Estado,Ddd1,Ddd2,Telefone1,Telefone2,Salario")] TbProfissional tbProfissional)
        {
            if (id != tbProfissional.IdProfissional)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var profissionalOriginal = await _context.TbProfissional.AsNoTracking().FirstOrDefaultAsync(p => p.IdProfissional == id);

            if (profissionalOriginal == null)
            {
                return NotFound();
            }

            // Verificar permissões
            bool isManager = roles.Contains("GerenteMedico") || roles.Contains("GerenteNutricionista") || roles.Contains("GerenteGeral");

            if (isManager)
            {
                // Gerentes podem editar profissionais conforme suas permissões
                if (roles.Contains("GerenteMedico") && profissionalOriginal.IdTipoProfissional != 1)
                {
                    return Forbid();
                }
                else if (roles.Contains("GerenteNutricionista") && profissionalOriginal.IdTipoProfissional != 2)
                {
                    return Forbid();
                }
                // GerenteGeral pode editar todos
                // Gerentes PODEM editar CPF - não aplicamos restrição
            }
            else
            {
                // Profissionais só podem editar seus próprios dados
                if (profissionalOriginal.IdUser != userId)
                {
                    return Forbid();
                }
                // Garantir que o CPF não seja alterado para profissionais
                tbProfissional.Cpf = profissionalOriginal.Cpf;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProfissional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProfissionalExists(tbProfissional.IdProfissional))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Obter o IdEstado da cidade selecionada
            var cidadeEdit = await _context.TbCidade.FindAsync(tbProfissional.IdCidade);
            var idEstadoEdit = cidadeEdit?.IdEstado;

            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", idEstadoEdit);
            ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == idEstadoEdit).OrderBy(c => c.Nome), "IdCidade", "Nome", tbProfissional.IdCidade);

            var contratosEdit = _context.TbContrato
                .Include(c => c.IdPlanoNavigation)
                .Select(c => new
                {
                    c.IdContrato,
                    NomeExibicao = c.IdPlanoNavigation.Nome + " (Contrato #" + c.IdContrato + ")" +
                                   (c.DataInicio.HasValue ? " - " + c.DataInicio.Value.ToString("dd/MM/yyyy") : "") +
                                   (c.DataFim.HasValue ? " até " + c.DataFim.Value.ToString("dd/MM/yyyy") : "")
                })
                .ToList();
            ViewData["IdContrato"] = new SelectList(contratosEdit, "IdContrato", "NomeExibicao", tbProfissional.IdContrato);

            ViewData["IdTipoAcesso"] = new SelectList(_context.TbTipoAcesso, "IdTipoAcesso", "Nome", tbProfissional.IdTipoAcesso);

            ViewData["IsManager"] = isManager;
            ViewData["CanEditCpf"] = isManager;

            return View(tbProfissional);
        }

        // GET: TbProfissionals/Delete/5
        [Authorize(Roles = "GerenteMedico,GerenteNutricionista,GerenteGeral")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var tbProfissional = await _context.TbProfissional
                .Include(t => t.IdCidadeNavigation)
                .Include(t => t.IdContratoNavigation)
                    .ThenInclude(c => c.IdPlanoNavigation)
                .Include(t => t.IdTipoAcessoNavigation)
                .FirstOrDefaultAsync(m => m.IdProfissional == id);

            if (tbProfissional == null)
            {
                return NotFound();
            }

            // Verificar permissões do gerente
            if (roles.Contains("GerenteMedico") && tbProfissional.IdTipoProfissional != 1)
            {
                return Forbid();
            }
            else if (roles.Contains("GerenteNutricionista") && tbProfissional.IdTipoProfissional != 2)
            {
                return Forbid();
            }

            // Verificar se o profissional possui pacientes cadastrados
            var temPacientes = await _context.TbMedicoPaciente
                .AnyAsync(mp => mp.IdProfissional == id);

            if (temPacientes)
            {
                ViewData["CanDelete"] = false;
                ViewData["DeleteMessage"] = "Este profissional não pode ser excluído pois possui pacientes cadastrados.";
            }
            else
            {
                ViewData["CanDelete"] = true;
            }

            return View(tbProfissional);
        }

        // POST: TbProfissionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "GerenteMedico,GerenteNutricionista,GerenteGeral")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Forbid();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var tbProfissional = await _context.TbProfissional.FindAsync(id);

            if (tbProfissional == null)
            {
                return NotFound();
            }

            // Verificar permissões do gerente
            if (roles.Contains("GerenteMedico") && tbProfissional.IdTipoProfissional != 1)
            {
                return Forbid();
            }
            else if (roles.Contains("GerenteNutricionista") && tbProfissional.IdTipoProfissional != 2)
            {
                return Forbid();
            }

            // Verificar se o profissional possui pacientes cadastrados
            var temPacientes = await _context.TbMedicoPaciente
                .AnyAsync(mp => mp.IdProfissional == id);

            if (temPacientes)
            {
                TempData["ErrorMessage"] = "Este profissional não pode ser excluído pois possui pacientes cadastrados.";
                return RedirectToAction(nameof(Index));
            }

            _context.TbProfissional.Remove(tbProfissional);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Profissional excluído com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        private bool TbProfissionalExists(int id)
        {
            return _context.TbProfissional.Any(e => e.IdProfissional == id);
        }
    }
}
