using Harvy.Ordonez.Model.Error;
using Harvy.Ordonez.Model.InvoicesDetail;
using Harvy.Ordonez.Services.InvoicesDetail;
using System.Web.Http;
using System.Web.Http.Description;

namespace Harvy.Ordonez.API.Controllers.InvoicesDetail
{
    [RoutePrefix("api/InvoicesDetail")]

    [ApiExplorerSettings(IgnoreApi = false)]
    public class InvoicesDetailController : ApiController
    {
        // GET: api/InvoiceDetail
        /// <summary>
        /// Get All Data.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var InvoicesDetail = ServiceInvoiceDetail.ReadInvoicesDetail();
            return Ok(new
            {
                count = InvoicesDetail.Count,
                data = InvoicesDetail
            });
        }

        public IHttpActionResult Get(int id)
        {
            var InvoicesDetail = ServiceInvoiceDetail.ReadInvoicesDetailbyInvoice(id);
            return Ok(new
            {
                count = InvoicesDetail.Count,
                data = InvoicesDetail
            });
        }

        /*
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest(MessageConstant.Invalid_Id);

            var invoicedetail = ServiceInvoiceDetail.ReadInvoicesDetail(id);
            return Ok(invoicedetail);
        }*/


        public IHttpActionResult Post(InvoceDetailVM data)
        {
            if (data == null) return BadRequest(MessageConstant.Invalid_Data);

            var id = ServiceInvoiceDetail.Save(data);

            return Ok(new
            {
                id,
                message = MessageConstant.InvoiceDetail_Create_Successfully
            });
        }

        public IHttpActionResult Put(int id, InvoceDetailVM data)
        {
            if (data == null) return BadRequest(MessageConstant.Invalid_Data);

            var invoiceDetailId = ServiceInvoiceDetail.Update(id, data);

            return Ok(new
            {
                invoiceDetailId,
                message = MessageConstant.InvoiceDetail_Updated_Successfully
            });
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(MessageConstant.Invalid_Id);

            var invoiceDetailId = ServiceInvoiceDetail.Delete(id);

            return Ok(new
            {
                invoiceDetailId,
                message = MessageConstant.InvoiceDetail_Deleted_Successfully
            });

        }
    }
}