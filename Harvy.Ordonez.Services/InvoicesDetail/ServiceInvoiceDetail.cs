using Harvy.Ordonez.Model;
using Harvy.Ordonez.Model.Error;
using Harvy.Ordonez.Model.InvoicesDetail;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Harvy.Ordonez.Services.InvoicesDetail
{
    public class ServiceInvoiceDetail
    {
        public static InvoceDetailVM ReadInvoicesDetail(int idnvoicesdetailId)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var InvoicesDetaiList = db.InvoiceDetail
                                        .Where(i => i.Active == Constants._ACTIVE_
                                               && i.IdInvoiceDetail == idnvoicesdetailId)
                                        .Select(i => new InvoceDetailVM
                                        {
                                            IdInvoiceDetail = i.IdInvoiceDetail,
                                            IdItem = (int) i.IdItem,
                                            IdInvoice = (int) i.IdInvoice,
                                            TaxValue = (decimal) i.TaxValue,
                                            Quantity = (decimal) i.Quantity,
                                            Price = (decimal) i.Price
                                        });

                    return InvoicesDetaiList.First();

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
        public static IList<InvoceDetailVM> ReadInvoicesDetail()
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var InvoicesDetaiList = db.InvoiceDetail
                                        .Where(i => i.Active == Constants._ACTIVE_)
                                        .Select(i => new InvoceDetailVM
                                        {
                                            IdInvoiceDetail = i.IdInvoiceDetail,
                                            IdItem = (int)i.IdItem,
                                            IdInvoice = (int)i.IdInvoice,
                                            TaxValue = (decimal)i.TaxValue,
                                            Quantity = (decimal)i.Quantity,
                                            Price = (decimal)i.Price
                                        });

                    return InvoicesDetaiList.ToList();
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement Logger

                throw ex;
            }
        }

        public static IList<InvoceDetailVM> ReadInvoicesDetailbyInvoice(int idinvoice)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var InvoicesDetaiList = db.InvoiceDetail
                                        .Where(i => i.Active == Constants._ACTIVE_
                                               && i.IdInvoice == idinvoice)
                                        .Select(i => new InvoceDetailVM
                                        {
                                            IdInvoiceDetail = i.IdInvoiceDetail,
                                            IdItem = (int)i.IdItem,
                                            IdInvoice = (int)i.IdInvoice,
                                            TaxValue = (decimal)i.TaxValue,
                                            Quantity = (decimal)i.Quantity,
                                            Price = (decimal)i.Price
                                        });

                    return InvoicesDetaiList.ToList();
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement Logger

                throw ex;
            }
        }

        public static int Update(int id, InvoceDetailVM data)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    DateTime localDate = DateTime.Now;
                    var vInvoicesDetail = db.InvoiceDetail.Find(id);

                    if (vInvoicesDetail == null)
                    {
                        throw new ArgumentNullException("id");
                    }

                    //Update columns
                    vInvoicesDetail.IdItem = data.IdItem;
                    vInvoicesDetail.IdInvoice = data.IdInvoice;
                    vInvoicesDetail.IdInvoice = data.IdInvoice;
                    vInvoicesDetail.TaxValue = data.TaxValue;
                    vInvoicesDetail.Quantity = data.Quantity;
                    vInvoicesDetail.Price = data.Price;
                    vInvoicesDetail.UpadteAt = localDate;
                    //Change State
                    db.Entry(vInvoicesDetail).State = EntityState.Modified;
                    db.SaveChanges();


                    return vInvoicesDetail.IdInvoiceDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Save(InvoceDetailVM data)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    InvoiceDetail newInvoceDetail = new InvoiceDetail
                    {
                        IdItem = data.IdItem,
                        IdInvoice = data.IdInvoice,
                        TaxValue = data.TaxValue,
                        Quantity = data.Quantity,
                        Price = data.Price,
                        Active = Constants._ACTIVE_,
                        CreatedAt = DateTime.Now
                    };
                    db.InvoiceDetail.Add(newInvoceDetail);
                    db.SaveChanges();
                    return newInvoceDetail.IdInvoiceDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int Delete(int invoicesdetailId)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    DateTime localDate = DateTime.Now;
                    var vInvoiceDetail = db.InvoiceDetail.Find(invoicesdetailId);
                    //Update status
                    vInvoiceDetail.Active = Constants._INACTIVE_;
                    vInvoiceDetail.DeleteAt = localDate;
                    //Change State
                    db.Entry(vInvoiceDetail).State = EntityState.Modified;
                    db.SaveChanges();

                    return vInvoiceDetail.IdInvoiceDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

