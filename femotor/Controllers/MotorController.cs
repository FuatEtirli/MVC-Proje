using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using femotor.Data;
using femotor.Models;
using Microsoft.AspNetCore.Authorization;

namespace femotor.Controllers
{

    [Authorize(Roles = "Admin")]
    public class MotorController : Controller
    {
        private readonly FeMotorDBContext _context;

        public MotorController(FeMotorDBContext context)
        {
            _context = context;
        }

        // GET: Motor
        public async Task<IActionResult> Liste()
        {
            return View(await _context.Motors.ToListAsync());
        }

        // GET: Motor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motors == null)
            {
                return NotFound();
            }

            var motor = await _context.Motors
                .Include(c => c.BodyType)
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.GearType)
                .FirstOrDefaultAsync(m => m.MotorID == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // GET: Motor/Create
        public IActionResult Ekle()
        {   
            
            ViewData["BodyType"] = new SelectList(_context.BodyTypes, "BodyTypeName", "BodyType");
            ViewData["Brand"] = new SelectList(_context.Brands, "BrandID", "BrandName");
            ViewData["Color"] = new SelectList(_context.Colors, "ColorID", "ColorName");
            ViewData["GearType"] = new SelectList(_context.GearTypes, "GearTypeID", "GearTypeName");
            
            return View();
        }

        // POST: Motor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle([Bind("MotorID,Color,Brand,MotorModel,ModelYear,BodyType,BodyTypeID,BodyTypeName,GearType,EngineVolume,Price,")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Liste));

            }
            ViewData["BodyType"] = new SelectList(_context.BodyTypes, "BodyTypeID", "BodyTypeName", motor.BodyTypeID);
            ViewData["Brand"] = new SelectList(_context.Brands, "BrandID", "BrandName", motor.Brand);
            ViewData["Color"] = new SelectList(_context.Colors, "ColorID", "ColorName", motor.Color);            
            ViewData["GearType"] = new SelectList(_context.GearTypes, "GearTypeID", "GearTypeName", motor.GearType);
           
            return View(motor);

        }

        // GET: Motor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motors == null)
            {
                return NotFound();
            }

            var motor = await _context.Motors.FindAsync(id);
            if (motor == null)
            {
                return NotFound();
            }
            ViewData["BodyType"] = new SelectList(_context.BodyTypes, "BodyTypeName", "BodyType", motor.BodyType);
            ViewData["Brand"] = new SelectList(_context.Brands, "BrandID", "BrandName", motor.Brand);
            ViewData["Color"] = new SelectList(_context.Colors, "ColorID", "ColorName", motor.Color);
            ViewData["GearType"] = new SelectList(_context.GearTypes, "GearTypeID", "GearTypeName", motor.GearType);
            
            return View(motor);
        }

        // POST: Motor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotorID,Color,Brand,MotorModel,ModelYear,BodyType,GearType,EngineVolume,Price")] Motor motor)
        {
            if (id != motor.MotorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(motor.MotorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Liste));
            }
            ViewData["BodyType"] = new SelectList(_context.BodyTypes, "BodyType", "BodyType", motor.BodyType);
            ViewData["Brand"] = new SelectList(_context.Brands, "BrandID", "BrandName", motor.Brand);
            ViewData["Color"] = new SelectList(_context.Colors, "ColorID", "ColorName", motor.Color);
            ViewData["GearType"] = new SelectList(_context.GearTypes, "GearTypeID", "GearTypeName", motor.GearType);
            
            return View(motor);
        }

        // GET: Motor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motors == null)
            {
                return NotFound();
            }

            var motor = await _context.Motors.ToListAsync();

            foreach (var item in motor)
            {
                if (item.MotorID == id)
                {
                    _context.Motors.Remove(item);
                    await _context.SaveChangesAsync();  
                }
            }
            if (motor == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Motor));
        }

        // POST: Motor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motors == null)
            {
                return Problem("Entity set 'feMotorDBContext.Motors'  is null.");
            }
            var motor = await _context.Motors.FindAsync(id);
            if (motor != null)
            {
                _context.Motors.Remove(motor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return _context.Motors.Any(e => e.MotorID == id);
        }
    }
}
