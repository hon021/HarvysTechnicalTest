using Harvy.Ordonez.Model;
using Harvy.Ordonez.Model.Error;
using Harvy.Ordonez.Model.Items;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;



namespace Harvy.Ordonez.Services.Items
{
    public class ServiceItem
    {

        public static ItemVM ReadItem(int itemId)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var itemsList = db.Item
                                        .Where(i => i.Active == Constants._ACTIVE_
                                                    && i.IdItem == itemId)
                                        .Select(i => new ItemVM
                                        {
                                            IdItem = i.IdItem,
                                            IsInventory = (bool)i.IsInventory
                                        });

                    return itemsList.First();

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
        public static IList<ItemVM> ReadItem()
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    var itemsList = db.Item
                                        .Where(i => i.Active == Constants._ACTIVE_)
                                        .Select(i => new ItemVM
                                        {
                                            IdItem = i.IdItem,
                                            IsInventory = (bool)i.IsInventory
                                        });

                    return itemsList.ToList();
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement Logger

                throw ex;
            }
        }

        public static int Update(int id, ItemVM data)
        {
            using (TechnicaltestEntities db = new TechnicaltestEntities())
            {
                DateTime localDate = DateTime.Now;
                var vItem = db.Item.Find(id);

                if (vItem == null)
                {
                    throw new ArgumentNullException("id");
                }

                //Update columns
                vItem.TypeItem = data.TypeItem;
                vItem.Name = data.Name;
                vItem.Quantity = data.Quantity;
                vItem.SalePrice = data.SalePrice;
                vItem.Photo = data.Photo;
                vItem.IsTax = data.IsTax;
                vItem.IsInventory = data.IsInventory;
                vItem.UpadteAt = localDate;
                //Change State
                db.Entry(vItem).State = EntityState.Modified;
                db.SaveChanges();


                return vItem.IdItem;
            }
        }

        public static int Save(ItemVM data)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    Item newItem = new Item
                    {
                        TypeItem = data.TypeItem,
                        Name = data.Name,
                        Quantity = data.Quantity,
                        SalePrice = data.SalePrice,
                        Photo = data.Photo,
                        IsTax = data.IsTax,
                        IsInventory = data.IsInventory,
                        Active = Constants._ACTIVE_,
                        CreatedAt = DateTime.Now
                    };
                    db.Item.Add(newItem);
                    db.SaveChanges();
                    return newItem.IdItem;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static int Delete(int nIdItem)
        {
            try
            {
                using (TechnicaltestEntities db = new TechnicaltestEntities())
                {
                    DateTime localDate = DateTime.Now;
                    var vItem = db.Item.Find(nIdItem);
                    //Update status
                    vItem.Active = Constants._INACTIVE_;
                    vItem.DeleteAt = localDate;
                    //Change State
                    db.Entry(vItem).State = EntityState.Modified;
                    db.SaveChanges();

                    return vItem.IdItem;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
