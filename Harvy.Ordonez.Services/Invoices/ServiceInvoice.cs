using Harvy.Ordonez.Model;
using Harvy.Ordonez.Model.Error;
using Harvy.Ordonez.Model.Invoices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Harvy.Ordonez.Services.Invoices
{
    public class ServiceInvoice
    {
        public static InvoceVM ReadInvoices(int invoicesId)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var InvoiceList = db.Invoice
                                        .Where(i => i.Active == Constants._ACTIVE_
                                               && i.IdInvoice == invoicesId)
                                        .Select(i => new InvoceVM
                                        {
                                            IdInvoice = i.IdInvoice,
                                            InvoiceDate = (DateTime)i.InvoiceDate,
                                            Amount = (decimal) i.Amount,
                                            TotalAmount = (decimal) i.TotalAmount,
                                            TotalTax = (decimal) i.TotalTax
                                        });

                    return InvoiceList.First();

                }
            }
            catch (Exception ex)
            {
                //TODO: Implement Logger

                throw ex;
            }
        }

        /// <summary>
        /// This method read all the data.
        /// </summary>
        /// <returns></returns>
        public static IList<InvoceVM> ReadInvoices()
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var InvoiceList = db.Invoice
                                        .Where(i => i.Active == Constants._ACTIVE_)
                                        .Select(i => new InvoceVM
                                        {
                                            IdInvoice = i.IdInvoice,
                                            InvoiceDate = (DateTime)i.InvoiceDate,
                                            Amount = (decimal)i.Amount,
                                            TotalAmount = (decimal)i.TotalAmount,
                                            TotalTax = (decimal)i.TotalTax
                                        });

                    return InvoiceList.ToList();
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement Logger

                throw ex;
            }
        }

        public static int Update(int id, InvoceVM data)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    DateTime localDate = DateTime.Now;
                    var vInvoice = db.Invoice.Find(id);

                    if (vInvoice == null)
                    {
                        throw new ArgumentNullException("id");
                    }

                    //Update columns
                    vInvoice.InvoiceDate = data.InvoiceDate;
                    vInvoice.Amount = data.Amount;
                    vInvoice.TotalAmount = data.TotalAmount;
                    vInvoice.TotalTax = data.TotalTax;
                    vInvoice.UpadteAt = localDate;
                    //Change State
                    db.Entry(vInvoice).State = EntityState.Modified;
                    db.SaveChanges();


                    return vInvoice.IdInvoice;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Save(InvoceVM data)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    Invoice newInvoice = new Invoice
                    {
                        InvoiceDate = data.InvoiceDate,
                        Amount = data.Amount,
                        TotalAmount = data.TotalAmount,
                        TotalTax = data.TotalTax,
                        Active = Constants._ACTIVE_,
                        CreatedAt = DateTime.Now
                    };
                    db.Invoice.Add(newInvoice);
                    db.SaveChanges();
                    return newInvoice.IdInvoice;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Solo para generar registro de prueba
        public static int RecordGenerator(int key)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    Random rnd = new Random();

                    //Invoice
                    Invoice newInvoice = new Invoice
                    {
                        InvoiceDate = DateTime.Now,
                        Amount = rnd.Next(key),
                        TotalAmount = rnd.Next(key),
                        TotalTax = rnd.Next(key),
                        Active = Constants._ACTIVE_,
                        CreatedAt = DateTime.Now
                    };
                    db.Invoice.Add(newInvoice);
                    db.SaveChanges();

                    //Item
                    Item newItem = new Item
                    {
                        TypeItem = Constants._SomethingToShow_,
                        Name = Constants._SomethingToShow_,
                        Quantity = rnd.Next(key),
                        SalePrice = rnd.Next(key),
                        Photo = Constants._SomethingToShow_,
                        IsTax = Constants._ACTIVE_,
                        IsInventory = Constants._ACTIVE_,
                        Active = Constants._ACTIVE_,
                        CreatedAt = DateTime.Now
                    };
                    db.Item.Add(newItem);
                    db.SaveChanges();

                    //Invoice Detail
                    InvoiceDetail newInvoceDetail = new InvoiceDetail
                    {
                        IdItem = newItem.IdItem,
                        IdInvoice = newInvoice.IdInvoice,
                        TaxValue = rnd.Next(key),
                        Quantity = rnd.Next(key),
                        Price = rnd.Next(key),
                        Active = Constants._ACTIVE_,
                        CreatedAt = DateTime.Now
                    };
                    db.InvoiceDetail.Add(newInvoceDetail);
                    db.SaveChanges();

                    return newInvoice.IdInvoice;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int Delete(int invoiceId)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    DateTime localDate = DateTime.Now;
                    var vInvoice = db.Invoice.Find(invoiceId);
                    //Update status
                    vInvoice.Active = Constants._INACTIVE_;
                    vInvoice.DeleteAt = localDate;
                    //Change State
                    db.Entry(vInvoice).State = EntityState.Modified;
                    db.SaveChanges();

                    return vInvoice.IdInvoice;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
