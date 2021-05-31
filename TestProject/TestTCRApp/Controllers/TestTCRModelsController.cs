using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Geidea.TCR.Model.Data;
using Geidea.TCR.Model.Data.Enum;
using Geidea.TCR.Service.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCRServiceTestClient.Framework;
using TCRServiceTestClient.FrameworkInterface;
using TestTCRApp.Models;

namespace TestTCRApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTCRModelsController : ControllerBase
    {
        private readonly TestTCRModelContext _context;

        public TestTCRModelsController(TestTCRModelContext context)
        {
            _context = context;
        }

        // GET: api/TestTCRModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTCRModel>>> GettestTCRModels()
        {
            return await _context.testTCRModels.ToListAsync();
        }

        // GET: api/TestTCRModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestTCRModel>> GetTestTCRModel(long id)
        {
            var testTCRModel = await _context.testTCRModels.FindAsync(id);

            if (testTCRModel == null)
            {
                return NotFound();
            }

            return testTCRModel;
        }

        // PUT: api/TestTCRModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestTCRModel(long id, TestTCRModel testTCRModel)
        {
            if (id != testTCRModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(testTCRModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTCRModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestTCRModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestTCRModel>> PostTestTCRModel(TestTCRModel testTCRModel)
        {
            _context.testTCRModels.Add(testTCRModel);
            await _context.SaveChangesAsync();

            OpenTCR();
            //var isReachable = await IsServerReachable();
            //return CreatedAtAction("GetTestTCRModel", new { id = testTCRModel.Id }, testTCRModel);
            return CreatedAtAction(nameof(GetTestTCRModel), new { id = testTCRModel.Id }, testTCRModel);
        }

        // DELETE: api/TestTCRModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestTCRModel(long id)
        {
            var testTCRModel = await _context.testTCRModels.FindAsync(id);
            if (testTCRModel == null)
            {
                return NotFound();
            }

            _context.testTCRModels.Remove(testTCRModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestTCRModelExists(long id)
        {
            return _context.testTCRModels.Any(e => e.Id == id);
        }

        public Task<bool> IsServerReachable()
        {

            TimeSpan timeout = new TimeSpan(0, 0, 30);


            var baseAddress = "http://192.168.1.30:80/request";
            var url = baseAddress.Replace("http:", "");
            url = url.Replace("request", "");
            url = url.Replace("/", "");
            var ipChunks = url.Split(':');



            try
            {
                var host = ipChunks[0];

                var port = Convert.ToInt32(ipChunks[1]);

                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(host, port, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(timeout);
                    client.EndConnect(result);
                    return Task.FromResult(success);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"NetworkObserver IP or the port number missing Error [Exception] Result: {ex.Message}");
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NetworkObserver Server not reachable Error [Exception] Result: {ex.Message}");
                return Task.FromResult(false);
            }
        }

        private async void OpenTCR()
        {
            var tcr = TCRFactory.Instance.getTcr1;
            IConnectionManager conMgr = ConnectionManager.Instance;
            conMgr.Register(tcr);
            var connClient = ConnectionManager.Instance.GetConnectionClient(tcr);

            await connClient.Connect();


            OpenRequestMessage rMsg = new OpenRequestMessage();
            OpenReqData rData = new OpenReqData();
            rData.Operation = COMMAND_REQUEST.OpenRequest.ToString();
            rData.BranchNo = AppConfiguration.BranchNo;
            rData.DeviceNo = AppConfiguration.DeviceNo;
            rData.IPAddress = AppConfiguration.Tcr_Ip;
            rData.Password = AppConfiguration.Passowrd;
            rData.PortNumber = AppConfiguration.Tcr_Port.ToString();
            rData.Side = AppConfiguration.Side; //L-Left R-Right
            rData.TellerID = AppConfiguration.TellerId;

            rMsg.ClientID = tcr.TcrId;
            rMsg.Data = rData;
            rMsg.Command = COMMAND_REQUEST.OpenRequest.ToString();

            //WriteMsg(rMsg);

            connClient.Open(rMsg);
        }
    }
}
