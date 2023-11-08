﻿using Database;
using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ContactRepository : IContactRepository
    {
        public readonly AppDbContext _context;
        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ContactEntity> Create(ContactEntity contact)
        {
            _context.Contacts.Add(contact);
            
            return contact;
        }

        public async Task Delete(Guid uuid)
        {
            var contactDelete = await _context.Contacts.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.Contacts.Remove(contactDelete);

        }

        public async Task<IEnumerable<ContactEntity>> Get()
        {
            try
            {
                var teste = await _context.Contacts.ToListAsync();
                return await _context.Contacts.ToListAsync();
            }
            catch (Exception ex) { return null; }
        }

        public async Task<ContactEntity> Get(Guid uuid)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Uuid == uuid);
            return contact;
        }

        public async Task<ContactEntity> Update(ContactEntity contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            return contact;
        }
    }
}
