using Harvy.Ordonez.Model.Error;
using Harvy.Ordonez.Model.Invoices;
using Harvy.Ordonez.Services.Invoices;
using System.Web.Http;
using System.Web.Http.Description;

namespace Harvy.Ordonez.API.Controllers.Invoices
{
    [RoutePrefix("api/Invoices")]

    [ApiExplorerSettings(IgnoreApi = false)]
    public class InvoicesController : ApiController
    {
        // GET: api/Invoice
        /// <summary>
        /// Get All Data.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var invoice = ServiceInvoice.ReadInvoices();
            return Ok(new
            {
                count = invoice.Count,
                data = invoice
            });
        }

        // GET: api/Invoice/5
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest(MessageConstant.Invalid_Id);

            var invoice = ServiceInvoice.ReadInvoices(id);
            return Ok(invoice);
        }

        // POST: api/Invoice
        public IHttpActionResult Post(InvoceVM data)
        {
            if (data == null) return BadRequest(MessageConstant.Invalid_Data);

            var id = ServiceInvoice.Save(data);

            return Ok(new
            {
                id,
                message = MessageConstant.Invoice_Create_Successfully
            });
        }

        /// <summary>
        /// RecordGenerator
        /// </summary>
        // POST: api/Invoice
        public IHttpActionResult Post(int key)
        { 
            var id = ServiceInvoice.RecordGenerator(key);

            return Ok(new
            {
                id,
                message = MessageConstant.Invoice_Create_Successfully
            });
        }

        // PUT: api/Invoice/5
        public IHttpActionResult Put(int id, InvoceVM data)
        {
            if (data == null) return BadRequest(MessageConstant.Invalid_Data);

            var invoiceId = ServiceInvoice.Update(id, data);

            return Ok(new
            {
                invoiceId,
                message = MessageConstant.Invoice_Updated_Successfully
            });
        }

        // DELETE: api/Invoice/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(MessageConstant.Invalid_Id);

            var invoiceId = ServiceInvoice.Delete(id);

            return Ok(new
            {
                invoiceId,
                message = MessageConstant.Invoice_Deleted_Successfully
            });

        }
    }
}