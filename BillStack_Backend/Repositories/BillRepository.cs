﻿using BillStack_Backend.Data;
using BillStack_Backend.Models.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BillStack_Backend.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly BillStackDbContext dbContext;

        public BillRepository(BillStackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BillStackDbContext DbContext { get; }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            await dbContext.Bills.AddAsync(bill);
            await dbContext.SaveChangesAsync();

            return bill;
        }

        public async Task<List<Bill>> GetAllBillAsync()
        {
            return await dbContext.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillByIdAsync(Guid id)
        {
            var bill = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);

            return bill;
        }

        public async Task<Bill> UpdateBillByIdAsync(Guid id, Bill bill)
        {
            var existingBill = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBill == null)
                return null;
            
            existingBill.Name = bill.Name;
            existingBill.ImageUrl = bill.ImageUrl;
            existingBill.Type = bill.Type;
            existingBill.Info = bill.Info;
            existingBill.Description = bill.Description;
            existingBill.Price  = bill.Price;
            existingBill.DueDate = bill.DueDate;

            await dbContext.SaveChangesAsync();

            return existingBill;
        }

        public async Task<Bill> UpdateBillStateByIdAsync(Guid id, Bill bill)
        {
            var existingBill = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBill == null)
                return null;

            existingBill.IsPaid = true;
            existingBill.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return existingBill;
        }

        public async Task<Bill> DeleteBillByIdAsync(Guid id)
        {
            var existingBill = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBill == null)
                return null;

            dbContext.Bills.Remove(existingBill);
            await dbContext.SaveChangesAsync();

            return existingBill;
        }

        public async Task<Bill> GetIdenticalBillAsync(Bill bill)
        {
            var identicalBill = await dbContext.Bills.FirstOrDefaultAsync(
                x =>
                x.Name == bill.Name &&
                x.ImageUrl == bill.ImageUrl &&
                x.Type == bill.Type &&
                x.Info == bill.Info &&
                x.Description == bill.Description &&
                x.Price == bill.Price &&
                x.DueDate == bill.DueDate
                );

            return identicalBill;
        }

        public async Task<Bill> GetIdenticalBillAsync(Bill bill, Guid id)
        {
            return await dbContext.Bills.FirstOrDefaultAsync(x =>
                x.Id != id &&
                x.Name == bill.Name &&
                x.Type == bill.Type &&
                x.BillType == bill.BillType &&
                x.Info == bill.Info &&
                x.Description == bill.Description &&
                x.Price == bill.Price &&
                x.DueDate == bill.DueDate
            );
        }
    }
}
