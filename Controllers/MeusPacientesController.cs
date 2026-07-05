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
    [Authorize(Roles = "Medico,Nutricionista")]
    public class MeusPacientesController : Controller
    {
        private readonly db_ifContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MeusPacientesController(db_ifContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MeusPacientes
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            // Buscar o profissional logado
            var profissional = await _context.TbProfissional
                .FirstOrDefaultAsync(p => p.IdUser == userId);

            if (profissional == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            // Buscar apenas os pacientes cadastrados por este profissional
            var pacientes = await _context.TbMedicoPaciente
                .Where(mp => mp.IdProfissional == profissional.IdProfissional)
                .Include(mp => mp.IdPacienteNavigation)
                    .ThenInclude(p => p.IdCidadeNavigation)
                .Select(mp => mp.IdPacienteNavigation)
                .ToListAsync();

            return View(pacientes);
        }

        // GET: MeusPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            // Buscar o profissional logado
            var profissional = await _context.TbProfissional
                .FirstOrDefaultAsync(p => p.IdUser == userId);

            if (profissional == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            // Verificar se este paciente pertence ao profissional logado
            var medicoPaciente = await _context.TbMedicoPaciente
                .FirstOrDefaultAsync(mp => mp.IdPaciente == id && mp.IdProfissional == profissional.IdProfissional);

            if (medicoPaciente == null)
            {
                return Forbid(); // Paciente não pertence a este profissional
            }

            var tbPaciente = await _context.TbPaciente
                .Include(t => t.IdCidadeNavigation)
                    .ThenInclude(c => c.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);

            if (tbPaciente == null)
            {
                return NotFound();
            }

            // Buscar informação resumida da relação médico-paciente
            ViewData["InformacaoResumida"] = medicoPaciente.InformacaoResumida;

            return View(tbPaciente);
        }

        // GET: MeusPacientes/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome");
            ViewData["IdCidade"] = new SelectList(Enumerable.Empty<TbCidade>(), "IdCidade", "Nome");
            return View();
        }

        // POST: MeusPacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nome,Rg,Cpf,DataNascimento,NomeResponsavel,Sexo,Etnia,Endereco,Bairro,IdCidade,TelResidencial,TelComercial,TelCelular,Profissao,FlgAtleta,FlgGestante")] TbPaciente tbPaciente, string InformacaoResumida)
        {
            if (ModelState.IsValid)

            {
                var userId = _userManager.GetUserId(User);

                // Buscar o profissional logado
                var profissional = await _context.TbProfissional
                    .FirstOrDefaultAsync(p => p.IdUser == userId);

                if (profissional == null)
                {
                    return NotFound("Profissional não encontrado.");
                }

                // Verificar se o CPF já existe
                var cpfExistente = await _context.TbPaciente.AnyAsync(p => p.Cpf == tbPaciente.Cpf);
                if (cpfExistente)
                {
                    ModelState.AddModelError("Cpf", "Já existe um paciente cadastrado com este CPF.");
                    
                    var cidade = await _context.TbCidade.FindAsync(tbPaciente.IdCidade);
                    ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", cidade?.IdEstado);
                    ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == (cidade != null ? cidade.IdEstado : 0)).OrderBy(c => c.Nome), "IdCidade", "Nome", tbPaciente.IdCidade);
                    return View(tbPaciente);
                }

                // Adicionar o paciente
                _context.Add(tbPaciente);
                await _context.SaveChangesAsync();

                // Criar o relacionamento na tabela tbMedico_Paciente
                var medicoPaciente = new TbMedicoPaciente
                {
                    IdPaciente = tbPaciente.IdPaciente,
                    IdProfissional = profissional.IdProfissional,
                    InformacaoResumida = InformacaoResumida
                };

                _context.Add(medicoPaciente);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Paciente cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            var cidadeError = await _context.TbCidade.FindAsync(tbPaciente.IdCidade);
            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", cidadeError?.IdEstado);
            ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == (cidadeError != null ? cidadeError.IdEstado : 0)).OrderBy(c => c.Nome), "IdCidade", "Nome", tbPaciente.IdCidade);
            return View(tbPaciente);
        }

        // GET: MeusPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            // Buscar o profissional logado
            var profissional = await _context.TbProfissional
                .FirstOrDefaultAsync(p => p.IdUser == userId);

            if (profissional == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            // Verificar se este paciente pertence ao profissional logado
            var medicoPaciente = await _context.TbMedicoPaciente
                .FirstOrDefaultAsync(mp => mp.IdPaciente == id && mp.IdProfissional == profissional.IdProfissional);

            if (medicoPaciente == null)
            {
                return Forbid(); // Paciente não pertence a este profissional
            }

            var tbPaciente = await _context.TbPaciente.FindAsync(id);
            if (tbPaciente == null)
            {
                return NotFound();
            }

            // Obter o IdEstado da cidade selecionada
            var cidade = await _context.TbCidade.FindAsync(tbPaciente.IdCidade);
            var idEstado = cidade?.IdEstado;

            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", idEstado);
            ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == idEstado).OrderBy(c => c.Nome), "IdCidade", "Nome", tbPaciente.IdCidade);
            ViewData["InformacaoResumida"] = medicoPaciente.InformacaoResumida;

            return View(tbPaciente);
        }

        // POST: MeusPacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,Nome,Rg,Cpf,DataNascimento,NomeResponsavel,Sexo,Etnia,Endereco,Bairro,IdCidade,TelResidencial,TelComercial,TelCelular,Profissao,FlgAtleta,FlgGestante")] TbPaciente tbPaciente, string InformacaoResumida)
        {
            if (id != tbPaciente.IdPaciente)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            // Buscar o profissional logado
            var profissional = await _context.TbProfissional
                .FirstOrDefaultAsync(p => p.IdUser == userId);

            if (profissional == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            // Verificar se este paciente pertence ao profissional logado
            var medicoPaciente = await _context.TbMedicoPaciente
                .FirstOrDefaultAsync(mp => mp.IdPaciente == id && mp.IdProfissional == profissional.IdProfissional);

            if (medicoPaciente == null)
            {
                return Forbid(); // Paciente não pertence a este profissional
            }

            if (ModelState.IsValid)

            {
                try
                {
                    _context.Update(tbPaciente);

                    // Atualizar a informação resumida
                    medicoPaciente.InformacaoResumida = InformacaoResumida;
                    _context.Update(medicoPaciente);

                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Paciente atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPacienteExists(tbPaciente.IdPaciente))
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

            var cidade = await _context.TbCidade.FindAsync(tbPaciente.IdCidade);
            var idEstado = cidade?.IdEstado;

            ViewData["IdEstado"] = new SelectList(_context.TbEstado.OrderBy(e => e.Nome), "IdEstado", "Nome", idEstado);
            ViewData["IdCidade"] = new SelectList(_context.TbCidade.Where(c => c.IdEstado == idEstado).OrderBy(c => c.Nome), "IdCidade", "Nome", tbPaciente.IdCidade);
            ViewData["InformacaoResumida"] = InformacaoResumida;

            return View(tbPaciente);
        }

        // GET: MeusPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);

            // Buscar o profissional logado
            var profissional = await _context.TbProfissional
                .FirstOrDefaultAsync(p => p.IdUser == userId);

            if (profissional == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            // Verificar se este paciente pertence ao profissional logado
            var medicoPaciente = await _context.TbMedicoPaciente
                .FirstOrDefaultAsync(mp => mp.IdPaciente == id && mp.IdProfissional == profissional.IdProfissional);

            if (medicoPaciente == null)
            {
                return Forbid(); // Paciente não pertence a este profissional
            }

            var tbPaciente = await _context.TbPaciente
                .Include(t => t.IdCidadeNavigation)
                    .ThenInclude(c => c.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.IdPaciente == id);

            if (tbPaciente == null)
            {
                return NotFound();
            }

            return View(tbPaciente);
        }

        // POST: MeusPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);

            // Buscar o profissional logado
            var profissional = await _context.TbProfissional
                .FirstOrDefaultAsync(p => p.IdUser == userId);

            if (profissional == null)
            {
                return NotFound("Profissional não encontrado.");
            }

            // Verificar se este paciente pertence ao profissional logado
            var medicoPaciente = await _context.TbMedicoPaciente
                .FirstOrDefaultAsync(mp => mp.IdPaciente == id && mp.IdProfissional == profissional.IdProfissional);

            if (medicoPaciente == null)
            {
                return Forbid(); // Paciente não pertence a este profissional
            }

            var tbPaciente = await _context.TbPaciente.FindAsync(id);
            if (tbPaciente != null)
            {
                // Remover o relacionamento médico-paciente primeiro
                _context.TbMedicoPaciente.Remove(medicoPaciente);

                // Verificar se há outros relacionamentos com este paciente
                var outrosRelacionamentos = await _context.TbMedicoPaciente
                    .AnyAsync(mp => mp.IdPaciente == id);

                // Se não houver outros relacionamentos, pode remover o paciente
                if (!outrosRelacionamentos)
                {
                    _context.TbPaciente.Remove(tbPaciente);
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Paciente removido com sucesso!";
            }

            return RedirectToAction(nameof(Index));
        }

        // API para buscar cidades por estado
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

        private bool TbPacienteExists(int id)
        {
            return _context.TbPaciente.Any(e => e.IdPaciente == id);
        }
    }
}
