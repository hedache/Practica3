using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Colegio.Web.Data;
using Colegio.Web.Models;

namespace Colegio.Web.Controllers
{
    public class MunicipiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MunicipiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Municipios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Municipios
                .Include(c => c.Barrios)
                .ToListAsync());
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var municipio = await _context.Municipios
            //    .FirstOrDefaultAsync(m => m.Id == id);
            Municipio municipio= await _context.Municipios
             .Include(c => c.Barrios)
             .ThenInclude(d => d.Alumnos)
             .FirstOrDefaultAsync(m => m.Id == id);

            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            return View();
        }   

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(municipio);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                try
                {

                    _context.Add(municipio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException) { if (dbUpdateException.InnerException.Message.Contains("duplicate")) { ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre."); } else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); } }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
            }
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Municipio municipio)
        {
            if (id != municipio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!MunicipioExists(municipio.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                catch (DbUpdateException dbUpdateException) { if (dbUpdateException.InnerException.Message.Contains("duplicate")) { ModelState.AddModelError(string.Empty, "There are a record with the same name."); } else { ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message); } }
                catch (Exception exception) { ModelState.AddModelError(string.Empty, exception.Message); }
                return RedirectToAction(nameof(Index));
            }
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Municipio municipio = await _context.Municipios
                .Include(c => c.Barrios)
 .ThenInclude(d => d.Alumnos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipio == null)
            {
                return NotFound();
            }

            //return View(municipio);
            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool MunicipioExists(int id)
        //{
        //    return _context.Municipios.Any(e => e.Id == id);
        //}


        public async Task<IActionResult> AddBarrio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Municipio municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }
            Barrio model = new Barrio { IdMunicipio = municipio.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBarrio(Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                Municipio municipio = await _context.Municipios
                .Include(c => c.Barrios)
                .FirstOrDefaultAsync(c => c.Id == barrio.IdMunicipio);
                if (barrio == null)
                {
                    return NotFound();
                }
                try
                {
                    barrio.Id = 0;
                    municipio.Barrios.Add(barrio);
                    _context.Update(municipio);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Details), new
                    {
                        Id = municipio.Id
                    });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if
                   (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(barrio);
        }


        public async Task<IActionResult> EditBarrio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Barrio barrio = await _context.Barrios.FindAsync(id);
            if (barrio == null)
            {
                return NotFound();
            }
            Municipio municipio = await _context.Municipios.FirstOrDefaultAsync(c =>
           c.Barrios.FirstOrDefault(d => d.Id == barrio.Id) != null);
            barrio.IdMunicipio = municipio.Id;
            return View(barrio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBarrio(Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barrio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new
                    {
                        Id = barrio.IdMunicipio
                    });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(barrio);
        }

        public async Task<IActionResult> DeleteBarrio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Barrio barrio = await _context.Barrios
            .Include(d => d.Alumnos)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (barrio == null)
            {
                return NotFound();
            }
            Municipio municipio = await _context.Municipios.FirstOrDefaultAsync(c =>
           c.Barrios.FirstOrDefault(d => d.Id == barrio.Id) != null);
            _context.Barrios.Remove(barrio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = municipio.Id });
        }

        public async Task<IActionResult> DetailsBarrio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Barrio barrio = await _context.Barrios
            .Include(d => d.Alumnos)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (barrio == null)
            {
                return NotFound();
            }
            Municipio municipio = await _context.Municipios.FirstOrDefaultAsync(c =>
           c.Barrios.FirstOrDefault(d => d.Id == barrio.Id) != null);
            barrio.IdMunicipio = municipio.Id;
            return View(barrio);
        }

        public async Task<IActionResult> AddAlumno(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Barrio barrio = await _context.Barrios.FindAsync(id);
            if (barrio == null)
            {
                return NotFound();
            }
            Alumno model = new Alumno { IdBarrio = barrio.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAlumno(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                Barrio barrio = await _context.Barrios
                .Include(d => d.Alumnos)
                .FirstOrDefaultAsync(c => c.Id == alumno.IdBarrio);
                if (barrio == null)
                {
                    return NotFound();
                }
                try

                {
                    alumno.Id = 0;
                    barrio.Alumnos.Add(alumno);
                    _context.Update(barrio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(DetailsBarrio), new { Id = barrio.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(alumno);
        }


        public async Task<IActionResult> EditAlumno(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Alumno alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            Barrio barrio = await _context.Barrios.FirstOrDefaultAsync(d =>
           d.Alumnos.FirstOrDefault(c => c.Id == alumno.Id) != null);
            alumno.IdBarrio = barrio.Id;
            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAlumno(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(DetailsBarrio), new { Id = alumno.IdBarrio});
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(alumno);
        }

        public async Task<IActionResult> DeleteAlumno(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Alumno alumno = await _context.Alumnos
            .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }
            Barrio barrio = await _context.Barrios.FirstOrDefaultAsync(d
           => d.Alumnos.FirstOrDefault(c => c.Id == alumno.Id) != null);
            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(DetailsBarrio), new
            {
                Id = barrio.Id
            });
        }



    }
}
