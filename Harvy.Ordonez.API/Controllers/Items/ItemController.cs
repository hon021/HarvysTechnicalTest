using Harvy.Ordonez.Model.Error;
using Harvy.Ordonez.Model.Items;
using Harvy.Ordonez.Services.Items;
using System.Web.Http;
using System.Web.Http.Description;

namespace Harvy.Ordonez.API.Controllers.Items
{
    [RoutePrefix("api/Item")]

    [ApiExplorerSettings(IgnoreApi = false)]
    public class ItemController : ApiController
    {
        // GET: api/Item
        /// <summary>
        /// Get All Data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var items = ServiceItem.ReadItem();
            return Ok(new
            {
                count = items.Count,
                data = items
            });
        }

        // GET: api/Item/5
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest(MessageConstant.Invalid_Id);

            var item = ServiceItem.ReadItem(id);
            return Ok(item);
        }

        // POST: api/Item
        public IHttpActionResult Post(ItemVM data)
        {
            if (data == null) return BadRequest(MessageConstant.Invalid_Data);

            var id = ServiceItem.Save(data);

            return Ok(new
            {
                id,
                message = MessageConstant.Item_Create_Successfully
            });
        }

        // PUT: api/Item/5
        public IHttpActionResult Put(int id, ItemVM data)
        {
            if (data == null) return BadRequest(MessageConstant.Invalid_Data);

            var itemId = ServiceItem.Update(id, data);

            return Ok(new
            {
                itemId,
                message = MessageConstant.Item_Updated_Successfully
            });
        }

        // DELETE: api/Item/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(MessageConstant.Invalid_Id);

            var itemId = ServiceItem.Delete(id);

            return Ok(new
            {
                itemId,
                message = MessageConstant.Item_Deleted_Successfully
            });

        }
    }
}