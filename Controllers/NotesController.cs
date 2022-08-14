using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PixyDeltaApi.Models;

namespace PixyDeltaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetNotes")]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _context.Notes.OrderByDescending(c => c.AddedDate).ToListAsync();
            if (notes == null)
            {
                return NotFound();
            }
            return Ok(notes);
        }

        [HttpPost]
        [Route("AddNote")]
        public async Task<IActionResult> AddNote(AddNoteBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Notes notes = new Notes
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Content = model.Content,
                Created = model.Created,
                Modified = model.Modified,
                AddedBy = model.AddedBy,
                AddedDate = model.AddedDate,
                UpdateddBy = model.UpdateddBy,
                UpdatedDate = model.UpdatedDate
            };
            _context.Notes.Add(notes);
            await _context.SaveChangesAsync();
            return Ok(notes);
        }

        [HttpPut]
        [Route("UpdateNote")]
        public async Task<IActionResult> UpdateNote(UpdateNoteBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Notes notes = await _context.Notes.FindAsync(model.Id);
            if (notes == null)
            {
                return NotFound();
            }
            notes.Title = model.Title;
            notes.Content = model.Content;
            notes.Modified = model.Modified;
            notes.UpdateddBy = model.UpdateddBy;
            notes.UpdatedDate = model.UpdatedDate;
            _context.Notes.Update(notes);
            await _context.SaveChangesAsync();
            return Ok(notes);
        }

        [HttpDelete]
        [Route("DeleteNote")]
        public async Task<IActionResult> DeleteNote(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Notes notes = await _context.Notes.FindAsync(id);
            if (notes == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(notes);
            await _context.SaveChangesAsync();
            return Ok(notes);
        }

    }
}